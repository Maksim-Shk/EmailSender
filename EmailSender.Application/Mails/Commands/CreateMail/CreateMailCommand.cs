using MediatR;

namespace EmailSender.Application.Mails.Commands.CreateMail
{
    public class CreateMailCommand : IRequest<string>
    {
        public string Subject { get; set; }
        public string? Body { get; set; }
        public string Sender { get; set; }
        public List<string> Recipients { get; set; }
    }
}
