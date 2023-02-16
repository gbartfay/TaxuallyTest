using Taxually.TechnicalTest.Components.Clients;
using Taxually.TechnicalTest.Components.Clients.Interfaces;
using Taxually.TechnicalTest.Components.Services;
using Taxually.TechnicalTest.Components.Services.Interfaces;
using Taxually.TechnicalTest.Components.Services.Options;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddOptions<VatRegistrationServiceOptions>().Bind(config.GetSection(VatRegistrationServiceOptions.Name));

// Add services to the container.
builder.Services.AddSingleton<ICsvGeneratorService, CsvGeneratorService>();
builder.Services.AddSingleton<IXmlGeneratorService, XmlGeneratorService>();
builder.Services.AddSingleton<ITaxuallyHttpClient, TaxuallyHttpClient>();
builder.Services.AddSingleton<ITaxuallyQueueClient, TaxuallyQueueClient>();
builder.Services.AddSingleton<IVatRegistrationService, VatRegistrationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
