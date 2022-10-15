using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using RockGym.Controllers;
using RockGym.Database;
using RockGym.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Configuration.AddAzureKeyVault(new SecretClient(new Uri(builder.Configuration.GetValue<string>("KeyVaultUri")), new DefaultAzureCredential()), new KeyVaultSecretManager());
builder.Services.AddDbContext<RockDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("rockgym").Value.ToString());
});
builder.Services.AddScoped<SubscriptionController>();
builder.Services.AddScoped<GroupTrainingController>();
builder.Services.AddScoped<GroupTrainingFeedbackController>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
builder.Services.AddScoped<IGroupTrainingRepository, GroupTrainingRepository>();
builder.Services.AddScoped<IGroupTrainingFeedbackRepository, GroupTrainingFeedbackRepository>();



var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
