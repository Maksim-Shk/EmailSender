namespace EmailSender.Domain
{
    public class Mail
    {
        public string MailId { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate {  get; set; }
        
    }
}
