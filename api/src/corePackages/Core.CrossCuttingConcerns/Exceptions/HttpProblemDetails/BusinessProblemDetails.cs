using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class BusinessProblemDetails : ProblemDetailsExtend
    {
        public BusinessProblemDetails(string detail)
        {
            Title = "Rule violation";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/business";
            Instance = "";
            IsSuccess = false;
        }
    }
}
