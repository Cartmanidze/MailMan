using AutoMapper;
using MailMan.Dal.Entities;
using MailMan.Domain.Mail;

namespace MailMan.Dal.Profiles;

/// <inheritdoc />
public class MailMessageProfile : Profile
{
    /// <inheritdoc />
    public MailMessageProfile()
    {
        CreateMap<MailMessageDomain, MailMessage>()
            .ForMember(d => d.Body, opt => opt.MapFrom(s => s.Body))
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.Subject, opt => opt.MapFrom(s => s.Subject))
            .ForMember(d => d.CreateDate, opt => opt.MapFrom(s => DateTime.UtcNow))
            .ForMember(d => d.Recipients, opt => opt.MapFrom(s => s.Recipients))
            .ForMember(d => d.Result, opt => opt.MapFrom(s => s.SendResult))
            .ForMember(d => d.FailedMessage, opt => opt.MapFrom(s => s.FailedMessage));
    }
}