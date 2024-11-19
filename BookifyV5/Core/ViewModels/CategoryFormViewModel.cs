namespace BookifyV5.Core.ViewModels
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage ="Max Length is 100 characters")]
        public string Name { get; set; } = string.Empty;
    }
}
