
using Chess_Backend.Controllers;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Services.MoveGenerators;
using Chess_Backend.Services.MoveGenerators.SubGenerators;
using Chess_Backend.Services.Validators;

namespace Chess_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IChessManagerService, ChessManagerService>();
            builder.Services.AddSingleton<IBoardHolder, BoardHolder>();
            builder.Services.AddSingleton<MovementFactory>();
            builder.Services.AddSingleton<IPieceFactory, PieceFactory>();
            builder.Services.AddSingleton<IBoardParserService, BoardParserService>();
            builder.Services.AddSingleton<IBoardFactory, BoardFactory>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Register individual validators as singletons
            builder.Services.AddSingleton<IMovementValidator, KingCheckValidator>();
            builder.Services.AddSingleton<IMovementValidator, CaptureSameColorValidator>();
            builder.Services.AddSingleton<IMovementValidator, PlayerTurnValidator>();
            builder.Services.AddSingleton<IMovementValidator, MoveInPossibleMovesValidator>();
            builder.Services.AddSingleton<ICompositeValidator, CompositeValidator>();

            // Register individual validators as singletons for the CompositeMoveGenerator
            builder.Services.AddSingleton<IMoveToTilesGenerator, RookTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, BishopTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, KnightTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, PawnTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, KingTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, QueenTilesGenerator>();
            builder.Services.AddSingleton<ICompositeTileGenerator, CompositeMovesGenerator>();

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
