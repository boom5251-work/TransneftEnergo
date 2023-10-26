
using TransneftEnergo.DataAccess.Extensions;


var builder = WebApplication.CreateBuilder(args);

// ���������� �������� � ���������.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApiVersioning();

string connection = builder.Configuration.GetConnectionString("TransneftEnergo")!;
builder.Services.AddDbContext(connection);


var app = builder.Build();

// ��������� ��������� HTTP-��������.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();