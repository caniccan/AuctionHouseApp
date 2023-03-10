namespace AuctionHouse.Core.ResultModels
{
    /// <summary>
    /// Result
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : IResult
    {
        /// <summary>
        /// IsSuccess
        /// </summary>
        public bool IsSuccess { get ; set ; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get ; set ; }

        /// <summary>
        /// Data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// TotalCount
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Result Constructor
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        public Result(bool isSuccess, string message) : this(isSuccess,message,default(T))
        {

        }

        /// <summary>
        /// Result Constructor
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public Result(bool isSuccess, string message, T data) : this(isSuccess, message,data,0)
        {

        }

        /// <summary>
        /// Result Constructor
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <param name="totalCount"></param>
        public Result(bool isSuccess, string message, T data, int totalCount)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            TotalCount = totalCount;
        }
    }
}
