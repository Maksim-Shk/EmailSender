using EmailSender.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Mails.Queries.GetAllMail
{
    public class GetAllMailQueryHandler
        : IRequestHandler<GetAllMailQuery, MailListVm>
    {
        private readonly IMailContext _dbContext;

        public GetAllMailQueryHandler(IMailContext dbContext)
            => (_dbContext) = (dbContext);


        public async Task<MailListVm> Handle(GetAllMailQuery request,
            CancellationToken cancellationToken)
        {
            var mails = await _dbContext.Mails.Include(m => m.Recipients).ToListAsync();
            List<MailDto> mailDtos = new List<MailDto>();

            foreach (var mail in mails)
            {
                var MailDto = new MailDto
                {
                    MailId = mail.MailId,
                    Subject = mail.Subject,
                    Body = mail.Body,
                    Sender = mail.Sender,
                    CreatedDate = mail.CreatedDate
                };
                MailDto.SentMails = new();

                foreach (var recipient in mail.Recipients)
                {
                    var sentMailDto = new SentMailDto
                    {
                        Recipient = recipient.Recipient,
                        Result = recipient.Result.ToString(),
                        FailedMessage = recipient.FailedMessage
                    };
                    MailDto.SentMails.Add(sentMailDto);
                }
                mailDtos.Add(MailDto);
            }

            return new MailListVm { Mails = mailDtos };
        }
    }
}
