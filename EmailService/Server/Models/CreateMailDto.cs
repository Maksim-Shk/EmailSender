using AutoMapper;
using EmailSender.Application.Common.Mappings;
using EmailSender.Application.Mails.Commands.CreateMail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Server.Models
{
    public class CreateMailDto : IMapWith<CreateMailCommand>
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string? Body { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMailDto, CreateMailCommand>()
                .ForMember(mailCommand => mailCommand.Subject,
                    opt => opt.MapFrom(mailDto => mailDto.Subject))
                .ForMember(mailCommand => mailCommand.Body,
                    opt => opt.MapFrom(mailDto => mailDto.Body));
        }
    }
}
