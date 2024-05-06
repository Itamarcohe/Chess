
using Chess_Backend.Models;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services;
using Chess_Backend.Services.Validators;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Chess_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IBoardHolder, BoardHolder>();
            builder.Services.AddSingleton<MovementFactory>();
            builder.Services.AddSingleton<IPieceFactory, PieceFactory>();
            builder.Services.AddSingleton<IBoardParserService, BoardParserService>();
            builder.Services.AddSingleton<IBoardFactory, BoardFactory>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Register individual validators as singletons
            builder.Services.AddSingleton<KingCheckValidator>();
            builder.Services.AddSingleton<CaptureSameColorValidator>();
            builder.Services.AddSingleton<ICompositeValidator>(serviceProvider =>
            {
                var kingCheckValidator = serviceProvider.GetRequiredService<KingCheckValidator>();
                var captureSameColorValidator = serviceProvider.GetRequiredService<CaptureSameColorValidator>();
                var validators = new List<IMovementValidator> { kingCheckValidator, captureSameColorValidator };
                return new CompositeValidator(validators);
            });


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            // Use CORS policy
            app.UseCors("AllowAll");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
