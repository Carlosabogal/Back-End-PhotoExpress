using ApiPhotoExpress.Model.Entity;
using ApiPhotoExpress.Repository;
using ApiPhotoExpress.Service;

using ApiPhotoExpress;

var builder = WebApplication.CreateBuilder(args);

// Configure the app settings
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers();
builder.Services.AddCors(); // Agrega Cors al servicio

var mySqlConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));
builder.Services.AddSingleton(mySqlConfiguration);

builder.Services.AddScoped<RegisterRepository>();
builder.Services.AddScoped<RegisterService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();