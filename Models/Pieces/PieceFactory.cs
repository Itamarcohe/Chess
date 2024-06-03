using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;

namespace Chess_Backend.Models.Pieces
{
    public class PieceFactory : IPieceFactory
    {
        private static readonly Dictionary<char, Func<Color, Tile, Piece>> promotionDictonary = new Dictionary<char, Func<Color, Tile, Piece>>
        {
            { 'r', ( color, tile ) => new Rook(color, tile) },
            { 'n', ( color, tile ) => new Knight(color, tile) },
            { 'b', ( color, tile) => new Bishop(color, tile) },
            { 'q', ( color, tile) => new Queen(color, tile) },
        };
        public Piece CreateMovedPiece(Piece piece, Tile newTile)
        {
            Type type = piece.GetType();
            var constructor = type.GetConstructor([type, typeof(Tile)]) ?? throw new InvalidOperationException($"No constructor found for type {type.Name} with parameters (Piece, Tile)");
            return (Piece)constructor.Invoke([piece, newTile]);
        }
        public Piece CreatePiece(Piece piece)
        {
            Type type = piece.GetType();
            var constructor = type.GetConstructor([type]) ?? throw new InvalidOperationException($"No cloning constructor found for type {type.Name}");
            return (Piece)constructor.Invoke([piece]);
        }
        public Piece CreatePieceColor(char symbol, Tile tile, Color color)
        {
            if (promotionDictonary.TryGetValue(symbol, out var createPiece))
            {
                return createPiece(color, tile);
            }
            else
            {
                throw new ArgumentException("Invalid piece type.");
            }
        }
    }
}
