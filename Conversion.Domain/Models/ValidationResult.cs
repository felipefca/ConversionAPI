namespace Conversion.Domain.Models
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
    }
}