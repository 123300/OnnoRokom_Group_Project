using StackOverflow.Web.Enums;

namespace StackOverflow.Web.Models
{
    public class ResponseModel
    {
        public string? Message { get; set; }
        public ResponseTypes Type { get; set; }
    }
}
