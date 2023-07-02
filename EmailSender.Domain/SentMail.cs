namespace EmailSender.Domain
{
    public class SentMail
    {
        /// <summary>
        /// ID записи
        /// </summary>
        public string SentMailId { get; set; }
        /// <summary>
        /// ID письма
        /// </summary>
        public string MailId { get; set; }
        /// <summary>
        /// Электронный ящик получателя
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
        /// <summary>
        /// Письмо, которому соответствует данная запись
        /// </summary>
        public virtual Mail Mail { get; set; }
    }
}
