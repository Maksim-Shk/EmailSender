using EmailSender.Domain;

namespace EmailSender.Application.Mails.Queries.GetAllMail
{
    public class SentMailDto
    {
        public string Recipient { get; set; }
        public ResultEnum Result { get; set; }
        public string? ResultDescription { get; set; }
    }
}
