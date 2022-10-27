using DrawingGame.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder =>
{
    builder
        .AllowAnyOrigin()
    //.WithOrigins("http://localhost:5106", "https://localhost:7209", "http://localhost:5006")
        .AllowAnyHeader()
        .AllowAnyMethod();
        //.WithMethods("GET", "POST")
        //.AllowCredentials();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();

}


app.MapHub<GameHub>("Game");

app.Run();