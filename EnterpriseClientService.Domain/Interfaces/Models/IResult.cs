namespace EnterpriseClientService.Domain.Interfaces.Models
{
    public interface IResult
    {
        bool Succeeded { get; set; }
        IDictionary<string, string> Errors { get; set; }
        string Message { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
