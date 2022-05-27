
namespace WAD_DATABASE.ViewModels
{
    public class EditBlogViewModel
    {
        public int Id { get; set; }
        public string? BlogName { get; set; }
        public string? Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
    }
}