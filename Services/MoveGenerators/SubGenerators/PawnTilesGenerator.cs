using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;
using Chess_Backend.Utils;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class PawnTilesGenerator : BaseTileGenerator
    {


        private readonly (int, int)[] WhitePawnInitialMoves = new[] { (0, 1), (-1, 1), (1, 1), (0, 2) };
        private readonly (int, int)[] BlackPawnInitialMoves = new[] { (0, -1), (-1, -1), (1, -1), (0, -2) };

        private readonly (int, int)[] WhitePawnStandardMoves = new[] { (0, 1), (-1, 1), (1, 1) };
        private readonly (int, int)[] BlackPawnStandardMoves = new[] { (0, -1), (-1, -1), (1, -1) };
        public override (int, int)[] MoveVectors => Array.Empty<(int, int)>();
        public PawnTilesGenerator(IBoardHolder boardHolder) : base(boardHolder) { }
        public override bool AppliesTo(Piece piece) => piece is Pawn;
        public override List<Tile> GetPossibleMoves(Piece piece)
        {
            IBoard board = boardHolder.GetBoard();
            var moves = new List<Tile>();

            (int, int)[] moveVectors = piece.Color == Color.White
                ? piece.HasMoved ? WhitePawnStandardMoves : WhitePawnInitialMoves
                : piece.HasMoved ? BlackPawnStandardMoves : BlackPawnInitialMoves;

            foreach (var moveVector in moveVectors)
            {
                int newX = piece.TilePosition.Column + moveVector.Item1;
                int newY = piece.TilePosition.Row + moveVector.Item2;
                if (!BoardUtils.IsWithinBoardBounds(newX, newY))
                    continue;

                Tile newTile = new Tile(newX, newY);
                Piece? pieceOnTile = board.GetPieceByTilePosition(newTile);
                // Checking if the move is a forward move by the X 
                if (moveVector.Item1 == 0)
                {
                    if (pieceOnTile == null)
                    {
                        moves.Add(newTile);
                        // Special case for the two-square move, check the square in between
                        if (Math.Abs(moveVector.Item2) == 2)
                        {
                            int midY = piece.TilePosition.Row + moveVector.Item2 / 2;
                            Tile midTile = new Tile(newX, midY);
                            if (board.GetPieceByTilePosition(midTile) != null)
                            {
                                moves.Remove(newTile); // Remove the move if the intermediate tile is blocked
                            }
                        }
                    }
                }
                else // Diagonal moves for captures
                {
                    if (pieceOnTile != null && pieceOnTile.Color != piece.Color)
                    {
                        moves.Add(newTile);
                    }
                }
            }

            return moves;
        }
    }
}

