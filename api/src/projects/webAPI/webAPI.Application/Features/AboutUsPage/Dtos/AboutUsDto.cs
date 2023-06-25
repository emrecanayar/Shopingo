namespace webAPI.Application.Features.AboutUsPage.Dtos
{
    public class AboutUsDto
    {
        public Guid Id { get; set; }
        public string TitleKey { get; set; }
        public string Title { get; set; }
        public string ContentKey { get; set; }
        public string Content { get; set; }
    }
}
