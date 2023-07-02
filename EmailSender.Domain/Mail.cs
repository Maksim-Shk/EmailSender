namespace EmailSender.Domain
{
    public class Mail
    {
        /// <summary>
        /// ID письма
        /// </summary>
        public string MailId { get; set; }
        /// <summary>
        /// почтовый ящик отправителя
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
        public DateTime CreatedDate {  get; set; }
        /// <summary>
        /// Получатели, включая статус отправки письма
        /// </summary>
        public virtual ICollection<SentMail> Recipients { get; set; }
    }
}
