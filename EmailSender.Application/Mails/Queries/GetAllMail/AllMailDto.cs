namespace EmailSender.Application.Mails.Queries.GetAllMail
{
    public class MailDto 
    {
        public string MailId { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<SentMailDto> SentMails { get; set; }
    }
}
