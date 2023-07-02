namespace EmailSender.Client.Models
{
    public class GetAllMailsModel
    {
        /// <summary>
        /// ID письма
        /// </summary>
        public string MailId { get; set; }
        /// <summary>
        /// Отправитель (исходя из appsettings)
        /// </summary>
        public string Sender { get; set; }
        /// <summary>
        /// Тема письма
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Тело письма
        /// </summary>
        public string? Body { get; set; }
        /// <summary>
        /// Дата создания (отправки)
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Список получателей и результатов отправки по ним
        /// </summary>
        public List<SentMailModel> SentMails { get; set; }
    }
}
