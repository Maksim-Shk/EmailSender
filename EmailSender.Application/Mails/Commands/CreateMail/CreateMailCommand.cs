using MediatR;

namespace EmailSender.Application.Mails.Commands.CreateMail
{
    /// <summary>
    /// Команда для отправки письма.
    /// </summary>
    public class CreateMailCommand : IRequest<string>
    {
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело письма
        /// </summary>
        public string? Body { get; set; }
        /// <summary>
        /// Получатели письма
        /// </summary>
        public List<string> Recipients { get; set; }
    }
}
