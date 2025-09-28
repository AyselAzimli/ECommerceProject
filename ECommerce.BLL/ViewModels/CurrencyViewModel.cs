namespace ECommerce.BLL.ViewModels
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string? CurrencyIconClass { get; set; } 
        public string? CurrencyCode { get; set; }
        public string? Symbol { get; set; } 
        public string? Country { get; set; }
    }

    public class CreateCurrencyViewModel { }
    public class UpdateCurrencyViewModel { }
}