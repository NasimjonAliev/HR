using Hr.Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer();
builder.Services.AddApplicationContextLayer();

builder.Services.AddCors(option => option.AddPolicy("MyBlogPolicy",
                        builder => 
                        {
                            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                        }));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("MyBlogPolicy");
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();



