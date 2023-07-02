using EmailSender.Domain;

namespace EmailSender.Application.Mails.Queries.GetAllMail
{
    public class SentMailDto
    {
        /// <summary>
        /// почтовый ящик получателя
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Результат отправки
        /// </summary>
        public ResultEnum Result { get; set; }
        /// <summary>
        /// Описание ошибки в случае её возникновения
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}
