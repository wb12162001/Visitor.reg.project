using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Reg.Core.RabbitMQ
{
    public interface IProcessMessage
    {
        void ProcessMsg(Message msg);

        void Notice();
    }
}
