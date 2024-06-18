using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarfSourceName.Infrastructure.Event.Types;

namespace BarfSourceName.Infrastructure.Event.Models
{
    public class EventMessage<T>
    {
        public T Message { get; }
        public EventTypes Type { get; }
        public EventMessage(EventTypes type, T message)
        {
            Type = type;
            Message = message;

        }
    }
}