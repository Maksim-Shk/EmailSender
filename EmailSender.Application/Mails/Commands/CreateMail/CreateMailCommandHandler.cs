using MediatR;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using EmailSender.Application.Interfaces;
using EmailSender.Domain;
using MailKit;

namespace EmailSender.Application.Mails.Commands.CreateMail
{
    public class CreateMailCommandHandler
        : IRequestHandler<CreateMailCommand, string>
    {
        private readonly IMailContext _dbContext;
        private readonly IConfiguration _configuration;

        public CreateMailCommandHandler(IMailContext dbContext, IConfiguration configuration)
            => (_dbContext, _configuration) = (dbContext, configuration);
        private async Task<SentMail> SentMime(Mail mailDto, string recipient)
        {
            var sentMail = new SentMail();
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(mailDto.Sender));
                email.To.Add(MailboxAddress.Parse(recipient));
                email.Subject = mailDto.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = mailDto.Body };

                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration.GetSection("EmailUsername").Value, _configuration.GetSection("EmailPassword").Value);
                smtp.Send(email);
                await smtp.DisconnectAsync(true);

                sentMail.MailId = mailDto.MailId;
                sentMail.Recipient = recipient;
                sentMail.Result = ResultEnum.OK;
                sentMail.FailedMessage = null;

            }
            catch(Exception ex) 
            {
                sentMail.MailId = mailDto.MailId;
                sentMail.Recipient = recipient;
                sentMail.Result = ResultEnum.Failed;
                sentMail.FailedMessage = ex.Message;
            }
            return sentMail;
        }

        public async Task<string> Handle(CreateMailCommand request,
            CancellationToken cancellationToken)
        {

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var mail = new Mail
                    {
                        Sender = _configuration.GetSection("EmailUsername").Value,
                        Subject = request.Subject,
                        Body = request.Body,
                        CreatedDate = DateTime.Now
                    };
                    await _dbContext.Mails.AddAsync(mail, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    foreach (var recipient in request.Recipients)
                    {
                        var sentMail = await SentMime(mail, recipient);
                        await _dbContext.SentMails.AddAsync(sentMail, cancellationToken);
                    }
                    await _dbContext.SaveChangesAsync(cancellationToken);

                    transaction.Commit();
                    return mail.MailId;
                }
                catch
                {
                    transaction?.Rollback();
                    throw new Exception();
                }
            }
        }
    }
}
