using Microsoft.EntityFrameworkCore;
using MochiApi.Dtos.Settings;
using MochiApi.Extensions;
using MochiApi.Middlewares;
using MochiApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureCors();

// Add services to the container.
builder.Services.AddControllers().AddCustomOptions();

builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ConfigureSwaggerOptions();
    c.EnableAnnotations();
});
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DbContext"));
}
);
builder.Services.ConfigureRepository();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.ConfigureExceptionHandler(app.Logger);
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();


app.UseMiddleware<JwtMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
