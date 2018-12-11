namespace Sample.WebApi.Application.Responses
{
    public abstract class Response
    {
        [Newtonsoft.Json.JsonIgnore]
        public bool Successfull { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string ErrorId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public string Message { get; set; }

    }
}
