using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(op =>
{
    op.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
    op.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
    op.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddGoogleOpenIdConnect(op =>
    {
        op.ClientId = builder.Configuration.GetValue<string>("GoogleLogIn:clientID");
        op.ClientSecret = builder.Configuration.GetValue<string>("GoogleLogIn:clientSecret");
    })
    .AddFacebook(op =>
    {
        op.AppId = builder.Configuration.GetValue<string>("FacebookLogIn:appID")!;
        op.AppSecret = builder.Configuration.GetValue<string>("FacebookLogIn:appSecret")!;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
