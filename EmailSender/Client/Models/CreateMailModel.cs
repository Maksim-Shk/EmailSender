namespace EmailSender.Client.Models
{
    public class CreateMailModel
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
