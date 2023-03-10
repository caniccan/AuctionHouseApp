using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities.Base
{
    /// <summary>
    /// Entity
    /// </summary>
    public abstract class Entity : IEntityBase
    {
        /// <summary>
        /// Id
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; protected set; }

        /// <summary>
        /// Clone
        /// </summary>
        /// <returns></returns>
        public Entity Clone()
        {
            return (Entity)this.MemberwiseClone();
        }
    }
}
