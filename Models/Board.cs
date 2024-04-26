using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Positions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_Backend.Models
{
    public class Board : IBoard
    {
        public List<Piece> Pieces { get; private set; }
        public Dictionary<Tile, Piece> Position { get; private set; }

        public Board(List<Piece> pieces)
        {
            this.Pieces = pieces;
            Position = MapPiecesToDictionary();
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
            Position.TryGetValue(tile, out Piece piece);
            return piece;
        }
        public Piece? GetPieceByTilePosition(int row, int column)
        {
            return GetPieceByTilePosition(new Tile(row, column));
        }

        public bool IsTileOccupied(Tile tile)
        {
            return Position.ContainsKey(tile);
        }
        public bool IsTileOccupied(int row, int column)
        {
            return Position.ContainsKey(new Tile(row, column));
        }
    }
}
