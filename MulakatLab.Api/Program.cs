using MulakatLab.Application;
using MulakatLab.Application.Tickets.CreateTicket;
using MulakatLab.Application.Tickets.GetTicket;
using MulakatLab.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5001);
    options.ListenLocalhost(5002);
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseHttpsRedirection();

app.MapPost("/tickets", async (CreateTicketRequest request, CreateTicketHandler handler, CancellationToken ct) =>
{
    var id = await handler.Handle(new CreateTicketCommand(request.Title), ct);
    return Results.Created($"/tickets/{id}", new { id });
});

app.MapGet("/tickets/{id:guid}", async (Guid id, GetTicketHandler handler, CancellationToken ct) =>
{
    var dto = await handler.Handle(new GetTicketQuery(id), ct);
    return dto is null ? Results.NotFound() : Results.Ok(dto);
});

app.Run();

record CreateTicketRequest(string Title);
