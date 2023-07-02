namespace EmailSender.Client.Models
{
    public class SentMailModel
    {
        /// <summary>
        /// почтовый ящик получателя
        /// </summary>
        public string Recipient { get; set; }
        /// <summary>
        /// Результат отправки
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        /// Описание ошибки в случае её возникновения
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}
