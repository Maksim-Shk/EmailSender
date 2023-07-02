namespace EmailSender.Domain
{
    public class SentMail
    {
        public string SentMailId { get; set; }
        public string MailId { get; set; }
        public string Recipient { get; set; }
        public ResultEnum Result { get; set; }
        public string? ResultDescription { get; set; }
        public virtual Mail Mail { get; set; }
        //public virtual User Recipient { get; set; }
        //public virtual User Sender { get; set; }
    }
}
