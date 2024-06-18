using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BarfSourceName.Infrastructure.Event.Models;

namespace BarfSourceName.Infrastructure.Event;

public interface IEventContext
{
    ///<summary>
    /// Sends a message to a message queue
    ///<summary>
    Task BroadCast<T>(EventMessage<T> eventMessage);
}