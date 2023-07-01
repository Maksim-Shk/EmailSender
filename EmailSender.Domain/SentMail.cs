namespace EmailSender.Domain
{
    public class SentMail
    {
        public string MailId { get; set; }
        public string RecipientId { get; set; }
        public string SenderId { get; set; }
        public ResultEnum Result { get; set; }
        public string? ResultDescription { get; set; }
    }
}
