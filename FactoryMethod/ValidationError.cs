using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.FactoryMethod
{
    public class ValidationError
    {
        private static readonly List<ValidationError> _validationerror = new List<ValidationError>();
        public int FeedId { get; }
        public string ErrorMessage { get; }
        public ValidationError(int id,string message)
        {
            FeedId = id;
            ErrorMessage = message;
        }
        public static void  AddValidationError(ValidationError error)
        {
            _validationerror.Add(error);
        }
        public static IEnumerable<ValidationError> GetValidationError()
        {
            return _validationerror;
        }
    }
}