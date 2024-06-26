
using Chess_Backend.Controllers;
using Chess_Backend.Models.Movements;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Services.MoveComposite;
using Chess_Backend.Services.MoveGenerators;
using Chess_Backend.Services.MoveGenerators.SubGenerators;
using Chess_Backend.Services.MovementHistory;
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
            builder.Services.AddSingleton<IMovementValidator, CastlingValidator>();
            builder.Services.AddSingleton<IMovementValidator, EnPassantValidator>();
            builder.Services.AddSingleton<IMovementValidator, PawnTwoSquareMoveValidator>();
            builder.Services.AddSingleton<IMovementValidator, PawnAttackValidator>();
            builder.Services.AddSingleton<ICompositeValidator, CompositeValidator>();

            //Attempt to add validator provider to get hte list of the whole other validators
            builder.Services.AddSingleton<IValidatorProvider, ValidatorProvider>();
            builder.Services.AddSingleton<Lazy<IValidatorProvider>>(sp =>
            {
                return new Lazy<IValidatorProvider>(() => sp.GetRequiredService<IValidatorProvider>());
            });


            // Register individual validators as singletons for the CompositeMoveGenerator
            builder.Services.AddSingleton<IMoveToTilesGenerator, RookTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, BishopTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, KnightTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, PawnTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, KingTilesGenerator>();
            builder.Services.AddSingleton<IMoveToTilesGenerator, QueenTilesGenerator>();
            builder.Services.AddSingleton<ICompositeTileGenerator, CompositeMovesGenerator>();

            //  Register individual movers as singletons for the MoveLogicComposite
            builder.Services.AddSingleton<IMoveLogic, NormalMoveLogic>();
            builder.Services.AddSingleton<IMoveLogic, AttackMoveLogic>();
            builder.Services.AddSingleton<IMoveLogic, PawnPromotionMoveLogic>();
            builder.Services.AddSingleton<IMoveLogic, QueenCastlingMoveLogic>();
            builder.Services.AddSingleton<IMoveLogic, KingCastlingMoveLogic>();
            builder.Services.AddSingleton<IMoveLogic, EnPassantMoveLogic>();
            builder.Services.AddSingleton<IMoveLogic, PawnTwoSquareMoveLogic>();
            builder.Services.AddSingleton<ICompositeMoveLogic, CompositeMoveLogic>();


            builder.Services.AddSingleton<MovementHistoryService>();
            builder.Services.AddSingleton<IOnMovementFinshedListener>(provider => provider.GetRequiredService<MovementHistoryService>());
            builder.Services.AddSingleton<IMovementHistoryService>(provider => provider.GetRequiredService<MovementHistoryService>());

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
