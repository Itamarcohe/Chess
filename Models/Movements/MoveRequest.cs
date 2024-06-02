using Chess_Backend.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Chess_Backend.Models.Movements
{
    public class MoveRequest
    {
        [Required]
        [RegularExpression(@"^[a-h][1-8]$", ErrorMessage = "From position is not valid.")]
        public required string From { get; set; }

        [Required]
        [RegularExpression(@"^[a-h][1-8]$", ErrorMessage = "To position is not valid.")]
        public required string To { get; set; }

        [ValidPromotionPiece]
        public char? Promotion { get; set; }
    }
}
