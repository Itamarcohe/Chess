using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Chess_Backend.Models.Validation
{
    public class ValidPromotionPieceAttribute : ValidationAttribute
    {
        private readonly char[] _validPieces = { 'q', 'r', 'b', 'n' };

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) 
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is char piece && _validPieces.Contains(piece))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Promotion piece is not valid. Valid pieces are: 'q', 'r', 'b', 'n'.");
        }
    }
}
