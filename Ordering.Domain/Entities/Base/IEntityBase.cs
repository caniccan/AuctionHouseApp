using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities.Base
{
    /// <summary>
    /// IEntityBase
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        int Id { get; }
    }
}
