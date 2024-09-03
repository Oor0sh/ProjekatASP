using aspPopravni.API.Extensions;
using aspPopravni.API.JWT.TokenStorage;
using aspPopravni.API.JWT;
using aspPopravni.API.Middleware;
using aspPopravni.API;
using aspPopravni.Application.Commands;
using aspPopravni.Application.Queries;
using aspPopravni.Application.Upload;
using aspPopravni.Application.UseCase;
using aspPopravni.Implementation.Logging;
using aspPopravni.Implementation.Upload;
using aspPopravni.Implementation.UseCases.Commands;
using aspPopravni.Implementation.UseCases.Queries;
using aspPopravni.Implementation.Validators;
using aspPopravni.Implementation;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using aspPopravni.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();

builder.Configuration.Bind(settings);
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddLogger();
builder.Services.AddTransient<popravniContext>(x => new popravniContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));

builder.Services.AddTransient<CreateBookValidator>();
builder.Services.AddTransient<CreateLoanValidator>();
builder.Services.AddTransient<CreateUserValidator>();
builder.Services.AddTransient<UpdateBookValidator>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();
builder.Services.AddTransient<IBase64Uploader, Base64Uploader>();
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<popravniContext>();
    var tokenStorage = x.GetService<ITokenStorage>();
    return new JwtManager(context, settings.Jwt.Issuer, settings.Jwt.SecretKey, settings.Jwt.DurationSeconds, tokenStorage);
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ASP Popravni Projekat - Sistem Biblioteke", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                });
});



builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IUserUseCaseProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<popravniContext>();

    return new AuthorizationUserProvider(authHeader, context);
});
builder.Services.AddScoped<IUserUseCase>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    var header = accessor.HttpContext.Request.Headers["Authorization"];
    var data = header.ToString().Split("Bearer ");
    if (data.Length < 2)
    {
        return new UnauthorizedUser();
    }
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedUser();
    }
    var handler = new JwtSecurityTokenHandler();

    var tokenObj = handler.ReadJwtToken(data[1].ToString());

    var claims = tokenObj.Claims;

    var email = claims.First(x => x.Type == "Email").Value;
    var id = claims.First(x => x.Type == "Id").Value;
    var useCases = claims.First(x => x.Type == "UseCases").Value;
    List<int> useCaseIds = JsonConvert.DeserializeObject<List<int>>(useCases);

    return new UserImplementation
    {
        Id = int.Parse(id),
        AllowedUseCases = useCaseIds,
        Email = email
    };
});
builder.Services.AddTransient<UseCaseHandler>(x =>
{
    var user = x.GetService<IUserUseCase>();
    var logger = x.GetService<IUseCaseLogger>();
    var decoration = new UseCaseHandler(user, logger);

    return decoration;
});
builder.Services.AddTransient<ICreateUser, EfRegisterUser>();
builder.Services.AddTransient<IUseCaseLogger, EFUseCaseLogger>();
builder.Services.AddTransient<IGetBooks, EFGetBooks>();
builder.Services.AddTransient<IGetUsers, EFGetUsers>();
builder.Services.AddTransient<IGetUserLoans, EFGetUserLoans>();
builder.Services.AddTransient<IBookAvailabilityCheck, EFBookAvailabilityCheck>();
builder.Services.AddTransient<ICreateBook, EFCreateBook>();
builder.Services.AddTransient<ICreateLoan, EFCreateLoan>();
builder.Services.AddTransient<IUpdateBook, EFUpdateBook>();
builder.Services.AddTransient<IDeleteLoan, EFDeleteLoan>();
builder.Services.AddJwt(settings);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(x =>
{
    x.AllowAnyOrigin();
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();


app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
