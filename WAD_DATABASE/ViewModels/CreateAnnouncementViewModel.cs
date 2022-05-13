namespace WAD_DATABASE.ViewModels
{
    public class CreateAnnouncementViewModel
    {
        public int Id { get; set; }
        public string? AnnouncementName { get; set; }

        public string? Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
