namespace Scholt.Api.Domain
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string[] Messages { get; set; } = [];
    }
}