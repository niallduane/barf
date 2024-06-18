using System;
using BarfSourceName.Infrastructure.Event;

namespace BarfSourceName.Infrastructure.Database.Tests;

public class EventContextTests
{
    private readonly IEventContext context;

    public EventContextTests()
    {
        context = new EventContext();
    }

    [Fact]
    public void SendMessage_Success()
    {
    }

}
