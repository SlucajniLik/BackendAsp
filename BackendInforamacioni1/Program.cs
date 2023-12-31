using BackendInforamacioni1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbCon>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("stringCon")); });


builder.Services.AddCors(options => {options.AddPolicy("myPolicy", policy =>
{
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
});


}); 





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
app.UseCors("myPolicy");
app.Run();
