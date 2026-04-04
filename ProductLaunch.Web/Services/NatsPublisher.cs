using ProductLaunch.Messaging;
using ProductLaunch.Messaging.Messages.Events;
using ProductLaunch.Entities;
using System;

namespace ProductLaunch.Web.Services
{
    public class NatsPublisher
    {
        public void PublishProspect(Prospect prospect)
        {
            var evt = new ProspectSignedUpEvent
            {
                Prospect    = prospect,
                SignedUpAt  = DateTime.UtcNow
            };
            MessageQueue.Publish(evt);
        }
    }
}
