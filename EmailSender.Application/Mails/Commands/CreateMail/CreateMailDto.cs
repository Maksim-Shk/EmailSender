using AutoMapper;
using EmailSender.Application.Common.Mappings;

namespace EmailSender.Application.Mails.Commands.CreateMail
{
    public class CreateMailDto : IMapWith<CreateMailCommand>
    {
        public string Subject { get; set; }
        public string? Body { get; set; }
        public List<string> Recipients { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMailDto, CreateMailCommand>()
                     .ForMember(mail => mail.Subject,
                   opt => opt.MapFrom(dto => dto.Subject))
                     .ForMember(mail => mail.Body,
                   opt => opt.MapFrom(dto => dto.Body))
                     .ForMember(mail => mail.Recipients,
                   opt => opt.MapFrom(dto => dto.Recipients));
        }
    }
}
