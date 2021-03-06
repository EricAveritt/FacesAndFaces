using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingInterfacesConstants.Events
{
    public interface IOrderProcessedEvent
    {
        Guid OrderId { get; }
        string PictureUrl { get; }
        List<byte[]> Faces { get; }
        string UserEmail { get; }
    }
}
