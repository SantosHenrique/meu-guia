﻿
using FluentValidation.Results;


namespace HFS.MeuGuia.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("Uma ou mais validações falharam.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
       : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }

    }
}
