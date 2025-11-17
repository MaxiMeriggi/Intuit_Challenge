namespace Intuit.Domain.Entities
{
    public class Error
    {
        public int Id { get; private set; }

        public string? Module { get; private set; } = null;

        public string ErrorText { get; private set; } = null!;

        public DateTime? Date { get; private set; }

        public Error()
        {
        }

        public static Error Create(string module, string errorText)
        {
            return new Error
            {
                Module = module,
                ErrorText = errorText,
                Date = DateTime.Now
            };
        }
    }
}
