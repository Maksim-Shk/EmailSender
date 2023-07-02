using MediatR;

namespace EmailSender.Application.Mails.Queries.GetAllMail
{
    /// <summary>
    /// запрос на получение всех писем из базы
    /// </summary>
    public class GetAllMailQuery : IRequest<MailListVm>
    {
    }
}
