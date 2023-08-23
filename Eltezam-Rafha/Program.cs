using Eltezam_Coded.DomainModels;
using Eltezam_Coded.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSoapCore();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IDropDownsService, DropDownsService>();
//builder.Services.AddDbContext<CodedContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);

builder.Services.AddScoped<DbContext,CodedContext>();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IEmployeeService>("/Service.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
   endpoints.UseSoapEndpoint<IEmployeeService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
    endpoints.UseSoapEndpoint<IDropDownsService>("/DropDownService.svc", new SoapEncoderOptions(), SoapSerializer.DataContractSerializer);
   endpoints.UseSoapEndpoint<IDropDownsService>("/DropDownService.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});
app.MapGet("/", () => "Hello World!");


app.Run();