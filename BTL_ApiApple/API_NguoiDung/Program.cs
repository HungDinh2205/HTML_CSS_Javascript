
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL;
using DTO;
using DAL.Interfaces;
using BLL.Interfaces;
using BLL;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<ISanPham_DAL, SanPham_DAL>();
builder.Services.AddTransient<ISanPham_BLL, SanPham_BLL>();
builder.Services.AddTransient<IHoaDon_DAL, HoaDon_DAL>();
builder.Services.AddTransient<IHoaDon_BLL, HoaDon_BLL>();
builder.Services.AddTransient<ILoai_DAL, Loai_DAL>();
builder.Services.AddTransient<ILoai_BLL, Loai_BLL>();
builder.Services.AddTransient<IUser_BLL, User_BLL>();
builder.Services.AddTransient<IUser_DAL, User_DAL>();
builder.Services.AddTransient<IGioHang_DAL, GioHang_DAL>();
builder.Services.AddTransient<IGioHang_BLL, GioHang_BLL>();
//builder.Services.AddTransient<IFeedbackCustomersRepository, FeedbackCustomersRepository>();
//builder.Services.AddTransient<IFeedbackCustomersBusiness, FeedbackCustomersBusiness>();
//builder.Services.AddTransient<IDatHang_DAL, DatHang_DAL>();
//builder.Services.AddTransient<IDatHang_BLL, DatHang_BLL>();



// configure strongly typed settings objects
IConfiguration configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);

// configure jwt authentication
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

// Add services to the container.
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
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
