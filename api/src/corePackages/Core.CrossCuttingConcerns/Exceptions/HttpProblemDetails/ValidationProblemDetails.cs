﻿using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails : ProblemDetailsExtend
    {
        public object Failures { get; init; }

        public ValidationProblemDetails(object failures)
        {
            Title = "Validation error(s)";
            Failures = failures;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/validation";
            Detail = "";
            Instance = "";
            IsSuccess = false;
        }
    }
}
