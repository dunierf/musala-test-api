using Musala.Gateways.Domain.Common;
using System.Collections.Generic;

namespace Musala.Gateways.Domain.Entities.Sample
{
    public class Todo : BaseEntity
    {
        public string Name { set; get; }        
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
