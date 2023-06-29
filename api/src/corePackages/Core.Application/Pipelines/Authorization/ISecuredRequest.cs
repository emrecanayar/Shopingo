namespace Core.Application.Pipelines.Authorization
{
    public interface ISecuredRequest
    {
        public string[] Roles { get; }
        public bool RequiresAuthorization { get; set; }
    }
}
