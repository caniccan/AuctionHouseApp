using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse.Core.ResultModels
{
    /// <summary>
    /// IResult
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// IsSuccess
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
