using System.Net;
using System.Text.Json;

namespace MyTrade.Domain
{
    public class ApiErrorResponse
    {
        public ApiError Error { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
