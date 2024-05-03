
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

            // Add services to the container.
            //builder.Services.AddTransient<IBoard, Board>();


            // Dor in case u want to make it singleton uncomment it and comment the line 28
            //builder.Services.AddSingleton<IBoard, Board>();


            // Scoped lifecycle for the Board

            builder.Services.AddScoped<IBoard, Board>();

            builder.Services.AddTransient<MovementFactory>();
            builder.Services.AddTransient<IPieceFactory, PieceFactory>();
            builder.Services.AddTransient<IBoardParserService, BoardParserService>();
            builder.Services.AddTransient<IBoardFactory, BoardFactory>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Register validators
            builder.Services.AddTransient<KingCheckValidator>();
            builder.Services.AddTransient<CaptureSameColorValidator>();
            // Register the CompositeValidator with a factory to inject the list of validators
            builder.Services.AddSingleton<CompositeValidator>(serviceProvider =>
            {
                var kingCheckValidator = serviceProvider.GetRequiredService<KingCheckValidator>();
                var captureSameColorValidator = serviceProvider.GetRequiredService<CaptureSameColorValidator>();
                var validators = new List<IMovementValidator> { kingCheckValidator, captureSameColorValidator };
                return new CompositeValidator(validators);
            });
            // Configure CORS to allow any origin, method, and header. Adjust for production.
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
