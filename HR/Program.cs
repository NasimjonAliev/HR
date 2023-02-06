using Hr.Application;
using IdentityServer4.AccessTokenValidation;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationLayer();
builder.Services.AddApplicationContextLayer();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();



builder.Services.AddCors(option => option.AddPolicy("MyBlogPolicy",
                        builder => 
                        {
                            builder.AllowAnyOrigin()
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                        }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseCors("MyBlogPolicy");

app.MapControllers();

app.Run();