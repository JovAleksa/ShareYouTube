using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ShareYouTube.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add application services.
builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddMvc();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyNames.AdministratorPolicy, policy => policy.Requirements.Add(new AuthorizationNameRequirement(PolicyNames.AdministratorPolicy)));
    options.AddPolicy(PolicyNames.SupervisorPolicy, policy => policy.Requirements.Add(new AuthorizationNameRequirement(PolicyNames.SupervisorPolicy)));
    options.AddPolicy(PolicyNames.EmployeePolicy, policy => policy.Requirements.Add(new AuthorizationNameRequirement(PolicyNames.EmployeePolicy)));
});

builder.Services.AddSingleton<IAuthorizationHandler, AuthorizationNameHandler>();


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
