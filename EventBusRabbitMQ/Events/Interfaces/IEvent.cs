using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Events.Interfaces
{
    /// <summary>
    /// IEvent abstract class
    /// </summary>
    public abstract class IEvent
    {
        /// <summary>
        /// Gets or private inits the Requset Id
        /// </summary>
        public Guid RequestId { get; private init; }

        /// <summary>
        /// Gets or private sets the Creation Date
        /// </summary>
        public DateTime CreationDate { get; private set; }

        /// <summary>
        /// IEvent Constructor
        /// </summary>
        public IEvent()
        {
            RequestId = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }
    }
}
