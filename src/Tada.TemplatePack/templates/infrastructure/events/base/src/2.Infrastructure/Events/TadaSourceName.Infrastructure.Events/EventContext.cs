using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TadaSourceName.Infrastructure.Event.Models;

namespace TadaSourceName.Infrastructure.Event;

//todo: implement functionality to use your choosen message queue service here
public class EventContext : IEventContext
{
    public Task BroadCast<T>(EventMessage<T> eventMessage)
    {
        return Task.CompletedTask;
    }
}