using System.Collections.Generic;

namespace MongoDB.Utilities.Model
{
    public class Result
    {
        public Result() => Success = true;

        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class GetOneResult<T> : Result where T : class, new()
    {
        public T Entity { get; set; }
    }

    public class GetManyResult<T> : Result where T : class, new()
    {
        public IEnumerable<T> Result { get; set; }
    }
}
