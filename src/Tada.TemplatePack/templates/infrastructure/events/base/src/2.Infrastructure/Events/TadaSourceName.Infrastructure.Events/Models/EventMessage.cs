using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TadaSourceName.Infrastructure.Event.Types;

namespace TadaSourceName.Infrastructure.Event.Models
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