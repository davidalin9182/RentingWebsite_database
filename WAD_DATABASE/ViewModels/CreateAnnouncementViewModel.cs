namespace WAD_DATABASE.ViewModels
{
    public class CreateAnnouncementViewModel
    {
        public int Id { get; set; }
        public string? AnnouncementName { get; set; }

        public string? Description { get; set; }
        public IFormFile Image { get; set; }

        public string? AppUserId { get; set; }

        public string? Location { get; set; }

        public string? PropertyType { get; set; }
        public int? Price { get; set; }

        public int? Phone { get; set; }

        public int? Surface { get; set; }
    }
}
