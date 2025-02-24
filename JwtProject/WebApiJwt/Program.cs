using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; //https'in gerekli olup olmamas�
    opt.TokenValidationParameters = new TokenValidationParameters() 
    {
        ValidIssuer = "http://localhost", //Bu Jwt'nin kim taraf�ndan yay�nland���
        ValidAudience = "http://localhost", //Bu Jwt'nin kim taraf�ndan dinlendi�i
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapiaspnetcoreapiapi")), //Jwt nin i�erisine gelen kullan�c� aspnetcoreapiapi key'ine sahip olursa o zaman i�lemi ger�ekle�tirebilecek
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
