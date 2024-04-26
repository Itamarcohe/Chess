using System.ComponentModel.DataAnnotations;

namespace Chess_Backend.Models.Movements
{
    public class MoveRequest
    {
        [Required]
        [RegularExpression(@"^[a-h][1-8]$", ErrorMessage = "From position is not valid.")]
        public string From { get; set; }

        [Required]
        [RegularExpression(@"^[a-h][1-8]$", ErrorMessage = "To position is not valid.")]
        public string To { get; set; }

    }
}
