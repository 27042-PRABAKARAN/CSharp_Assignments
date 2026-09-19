using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConcepts.Tasks
{
    internal class Notifier
    {
        internal delegate void Notify(string message);

        internal event Notify? OnAction;

        internal void Execute(string message)
        {
            this.OnAction?.Invoke(message);
        }
    }
}
