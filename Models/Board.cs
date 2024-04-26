using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using System;
using System.Collections.Generic;
using System.Text;
using Chess_Backend.Models.Movements;
namespace Chess_Backend.Models
{
    public class Board : IBoard
    {
        public List<Piece> Pieces { get; private set; }
        public Dictionary<Tile, Piece> Positions { get; private set; }

        public Board(List<Piece> pieces)
        {
            this.Pieces = pieces;
            Positions = MapPiecesToDictionary();
        }
        public Dictionary<Tile, Piece> MapPiecesToDictionary()
        {
            Dictionary<Tile, Piece> positions = [];
            foreach (Piece piece in Pieces)
            {
                positions[piece.TilePosition] = piece;
            }
            return positions;
        }
        public Piece? GetPieceByTilePosition(Tile tile)
        {
            Positions.TryGetValue(tile, out Piece piece);
            return piece;
        }
        public Piece? GetPieceByTilePosition(int row, int column)
        {
            return GetPieceByTilePosition(new Tile(row, column));
        }

        public bool IsTileOccupied(Tile tile)
        {
            return Positions.ContainsKey(tile);
        }
        public bool IsTileOccupied(int row, int column)
        {
            return Positions.ContainsKey(new Tile(row, column));
        }

        public void ApplyMove(Movement move)
        {
            // Retrieve the moving piece
            var movingPiece = Positions[move.From];

            // Remove the piece from the old position
            Positions.Remove(move.From);
            Pieces.Remove(movingPiece);

            // Check if there is a capture
            if (Positions.ContainsKey(move.To))
            {
                var capturedPiece = Positions[move.To];
                Pieces.Remove(capturedPiece); // Remove the captured piece from the list
                Positions.Remove(move.To); // Remove the captured piece from the map
            }

            // Handle special cases like pawn promotion
            if (move is PawnPromotionMovement promotionMove)
            {
                // Create a new promoted piece instead of moving the pawn
                var promotedPiece = PieceFactory.CreatePiece(promotionMove.PromotionPieceSymbol, move.To);
                Pieces.Add(promotedPiece);
                Positions[move.To] = promotedPiece;
            }
            else
            {
                // Create a new piece of the same type at the new position
                var newPiece = PieceFactory.CreatePiece(movingPiece.GetSymbol(), move.To);
                Pieces.Add(newPiece);
                Positions[move.To] = newPiece;
            }
        }

    }
}
