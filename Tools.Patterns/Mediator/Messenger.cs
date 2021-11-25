using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Patterns.Mediator
{
    public class Messenger<TMessage>
    {
        private static Messenger<TMessage> _default;
        public static Messenger<TMessage> Default
        {
            get { return _default ??= new Messenger<TMessage>(); }
        }

        public event Action<TMessage> OnMessage;

        public void Send(TMessage message)
        {
            OnMessage?.Invoke(message);
        }
    }
}
