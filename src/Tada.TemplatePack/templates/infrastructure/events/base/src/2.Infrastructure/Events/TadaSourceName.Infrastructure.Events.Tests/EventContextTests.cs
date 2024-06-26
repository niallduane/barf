using System;
using TadaSourceName.Infrastructure.Event;

namespace TadaSourceName.Infrastructure.Database.Tests;

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
