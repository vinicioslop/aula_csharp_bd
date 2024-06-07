// using Microsoft.AspNetCore.Mvc;

// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddSwaggerGen();
// builder.Services.AddEndpointsApiExplorer();

// var app = builder.Build();

// app.UseSwagger();
// app.UseSwaggerUI();

// app.UseDefaultFiles();
// app.UseStaticFiles();

// app.MapGet("/api/{x}/abc/{y}", ([FromRoute] int x, [FromRoute] string y) =>
// {
//     // return $"Recebidos x={x} e y={y}.";
//     return Results.Ok(
//         new {
//             mensagem = "Dados inseridos com sucesso",
//             x = x,
//             y = y
//         }
//     );
// });

// app.MapPost("/api", ([FromBody] Dados dadosEntrada) =>
// {
//     return $"{dadosEntrada.x} + {dadosEntrada.y} = {dadosEntrada.x + dadosEntrada.y}";
// });

// app.MapPut("/api", () => "Resposta ao método PUT");
// app.MapDelete("/api", () => "Resposta ao método DELETE");
// app.MapMethods("/api", new[] { "PATCH" }, () => "Resposta ao método PATCH");

// app.Run();

// public class Dados
// {
//     public int x { get; set; }
//     public int y { get; set; }
// }

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/hello-world", () =>
{
    return Results.Ok(new
    {
        mensagem = "Hello, World!"
    });
});

app.Run();