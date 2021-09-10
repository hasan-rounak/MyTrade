namespace MyTrade.Domain
{
    public class ApiError
    {
        public string ErrorId { get; set; }

        public string Exception { get; set; }

        public string Message { get; set; }

        public string Path { get; set; }

        public string Type { get; set; }
    }
}
