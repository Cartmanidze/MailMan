using AutoMapper;
using MailMan.Application;
using MailMan.Application.Services;
using MailMan.Dal.Context;
using MailMan.Dal.Repositories;
using MailMan.Extensions;
using MailMan.Views;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<MailManContext>();
    
    dataContext.Database.Migrate();
}

app.MapPost("/api/mails", async (MailSendView view, IMailService mailService, CancellationToken token) =>
{
    var mailMessage = view.ToDomain();

    await mailService.SendAsync(mailMessage, token).ConfigureAwait(false);
})
    .Accepts<MailSendView>("application/json");
    
app.MapGet("/api/mails", async (IMapper mapper, IMailMessageRepository repository, CancellationToken token) =>
{
    var mailMessages = await repository.GetAllAsync(token).ConfigureAwait(false);

    var views = mapper.Map<MailListView[]>(mailMessages);

    return Results.Ok(views);
});

app.Run();