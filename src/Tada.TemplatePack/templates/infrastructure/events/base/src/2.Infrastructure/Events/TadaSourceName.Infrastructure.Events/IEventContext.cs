using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TadaSourceName.Infrastructure.Event.Models;

namespace TadaSourceName.Infrastructure.Event;

public interface IEventContext
{
    ///<summary>
    /// Sends a message to a message queue
    ///<summary>
    Task BroadCast<T>(EventMessage<T> eventMessage);
}