using AutoMapper;
using MailMan.Dal.Entities;
using MailMan.Domain.Mail;

namespace MailMan.Dal.Profiles;

/// <inheritdoc />
public class RecipientProfile : Profile
{
    /// <inheritdoc />
    public RecipientProfile()
    {
        CreateMap<RecipientDomain, Recipient>()
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email.Value));
    }
}