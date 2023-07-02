using MediatR;

namespace EmailSender.Application.Mails.Queries.GetAllMail
{
    public class GetAllMailQuery : IRequest<MailListVm>
    {
    }
}
