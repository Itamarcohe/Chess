using Chess_Backend.Models;
using Chess_Backend.Models.Enums;
using Chess_Backend.Models.Pieces;
using Chess_Backend.Models.Pieces.SubPieces;
using Chess_Backend.Models.Positions;
using Chess_Backend.Services.BoardServices;

namespace Chess_Backend.Services.MoveGenerators.SubGenerators
{
    public class KingTilesGenerator : BaseTileGenerator
    {
        public override (int, int)[] MoveVectors { get; } =
            [(0, 1), (0, -1), (1, 0), (-1, 0), (1, 1), (1, -1), (-1, 1), (-1, -1), (2, 0), (-2, 0)
];

        public override bool AppliesTo(Piece piece) => piece is King;

        public override List<Tile> GetPossibleMoves(Piece piece, IBoard board)
        {
            var moves = base.GetPossibleMoves(piece, board);

            if (piece.HasMoved)
            {
                int kingSideIndex = moves.FindIndex(m => m.Column == piece.TilePosition.Column + 2 && m.Row == piece.TilePosition.Row);
                if (kingSideIndex != -1) 
                {
                    moves.RemoveAt(kingSideIndex); 
                }

                int queenSideIndex = moves.FindIndex(m => m.Column == piece.TilePosition.Column - 2 && m.Row == piece.TilePosition.Row);
                if (queenSideIndex != -1)
                {
                    moves.RemoveAt(queenSideIndex);
                }
            }
            return moves;
        }

        //private bool CanCastle(Piece king, int direction)
        //{
        //    var board = boardHolder.GetBoard();
        //    int kingCurrentColumn = king.TilePosition.Column;
        //    int kingRow = king.TilePosition.Row;

        //    // Determine the columns for the rook depending on castling direction
        //    int rookColumn = direction == 2 ? 7 : 0; // Assuming standard positions for rooks at start of game

        //    Rook rook = (Rook)board.GetPieceByTilePosition(new Tile(kingRow, rookColumn));
        //    if (rook == null || rook.HasMoved || king.HasMoved)
        //        return false; // Either no rook, rook has moved, or king has moved
        //                      // Check that all squares between the king and rook are empty
        //    int step = Math.Abs(direction) / 2; // Either 1 step (king-side) or 2 steps (queen-side)
        //    for (int i = 1; i <= step; i++)
        //    {
        //        int colOffset = direction > 0 ? i : -i;
        //        if (board.GetPieceByTilePosition(new Tile(kingRow, kingCurrentColumn + colOffset)) != null)
        //            return false;
        //    }

        //    // Ensure king does not pass through check
        //    for (int i = 0; i <= step; i++)
        //    {
        //        int colOffset = direction > 0 ? i : -i;
        //        Tile checkTile = new Tile(kingRow, kingCurrentColumn + colOffset);
        //        if (IsSquareUnderAttack(checkTile, king.Color, board))
        //            return false;
        //    }

        //    return true; // All conditions are satisfied for castling
        //}

        //// Helper method to determine if a specific square is under attack
        //private bool IsSquareUnderAttack(Tile tile, Color kingColor, IBoard board)
        //{
        //    // Check if any opponent's piece can attack the 'tile'
        //    foreach (Piece piece in board.Pieces.Where(p => p.Color != kingColor))
        //    {
        //        var possibleAttacks = tilesGenerator.GetPossibleMoves(piece); // Assumes this method gives all attack moves
        //        if (possibleAttacks.Any(move => move.Row == tile.Row && move.Column == tile.Column))
        //            return true;
        //    }
        //    return false;
        //}


    }
}



