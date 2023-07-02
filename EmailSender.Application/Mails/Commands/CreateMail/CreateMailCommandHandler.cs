using MediatR;
using System.Threading.Tasks;
using System.Threading;
using EmailSender.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using EmailSender.Domain;

namespace EmailSender.Application.Mails.Commands.CreateMail
{
    public class CreateMailCommandHandler
        : IRequestHandler<CreateMailCommand, string>
    {
        public readonly IMailContext _dbContext;

        public CreateMailCommandHandler(IMailContext dbContext) =>
            _dbContext = dbContext;

        public async Task<string> Handle(CreateMailCommand request,
            CancellationToken cancellationToken)
        {

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var mail = new Mail
                    {
                        Sender = request.Sender,
                        Subject = request.Subject,
                        Body = request.Body,
                        CreatedDate = DateTime.Now
                    };
                    await _dbContext.Mails.AddAsync(mail, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    foreach (var recipient in request.Recipients)
                    {
                        var sentMail = new SentMail
                        {
                            MailId = mail.MailId,
                            Recipient = recipient,
                            Result = ResultEnum.OK,
                            ResultDescription = null
                        };
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
