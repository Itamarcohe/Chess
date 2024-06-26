﻿using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
namespace Chess_Backend.Models
{
    public class Board : IBoard
    {
        public List<Piece> Pieces { get; private set; }
        public Dictionary<Tile, Piece> Positions { get; private set; }
        public Color CurrentTurnColor { get; private set; }
        public Board(List<Piece> pieces, Color currentTurnColor)
        {
            this.Pieces = pieces;
            this.CurrentTurnColor = currentTurnColor;
            Positions = new Dictionary<Tile, Piece>();
            MapPiecesToDictionary();
        }
        public Piece? GetPieceByTilePosition(int column, int row) => GetPieceByTilePosition(new Tile(column, row));
        public bool IsTileOccupied(Tile tile) => Positions.ContainsKey(tile);
        public bool IsTileOccupied(int column, int row) => Positions.ContainsKey(new Tile(column, row));
        private void MapPiecesToDictionary()
        {
            foreach (Piece piece in Pieces)
            {
                Positions[piece.TilePosition] = piece;
            }
        }
        public Piece? GetPieceByTilePosition(Tile tile)
        {
            Positions.TryGetValue(tile, out Piece? piece);
            return piece;
        }
        public Tile? FindOpponentKingPosition()
        {
            foreach (Piece piece in Pieces.Where(p => p.Color != CurrentTurnColor))
            {
                if (piece.GetType() == typeof(King))
                {
                    return piece.TilePosition;
                }
            }
            return null;
        }
}
}
