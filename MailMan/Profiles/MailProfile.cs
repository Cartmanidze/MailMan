using AutoMapper;
using MailMan.Dal.Entities;
using MailMan.Views;

namespace MailMan.Profiles;

/// <inheritdoc />
public class MailProfile : Profile
{
    /// <inheritdoc />
    public MailProfile()
    {
        CreateMap<MailMessage, MailListView>()
            .ForMember(d => d.Body, opt => opt.MapFrom(s => s.Body))
            .ForMember(d => d.Subject, opt => opt.MapFrom(s => s.Subject))
            .ForMember(d => d.SendResult, opt => opt.MapFrom(s => s.Result))
            .ForMember(d => d.FailedMessage, opt => opt.MapFrom(s => s.FailedMessage))
            .ForMember(d => d.CreateDate, opt => opt.MapFrom(s => s.CreateDate))
            .ForMember(d => d.Recipients, opt => opt.MapFrom(s => s.Recipients.Select(x => x.Email)));
    }
}