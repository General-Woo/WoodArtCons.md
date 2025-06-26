using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;
using WoodArtCons;
using WoodArtCons.Interfaces;
using WoodArtCons.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new HttpClient()
{
    BaseAddress = new Uri("http://backend:5001/")
});

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddMudServices();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IAuthProfileService, AuthProfileService>();
builder.Services.AddScoped<ICategoryManagerService, CategoryManagerService>();
builder.Services.AddScoped<ICategoryProductManagerService, CategoryProductManagerService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<WoodArtCons.Services.CrmLeadService>();

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddOptions();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("role", "Admin"));
});

builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Configure(context.Configuration.GetSection("Kestrel"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
//app.UseCors("AllowSpecificOrigin");
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorComponents<WoodArtCons.Components.App>()
    .AddInteractiveServerRenderMode();
app.Run();

