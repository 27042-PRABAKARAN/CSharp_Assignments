using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryHandler.Enums
{
    /// <summary>
    /// Options to choose the task
    /// </summary>
    internal enum TaskOptions
    {
        /// <summary>
        /// Memory out of bound
        /// </summary>
        ExplodeMemory,

        /// <summary>
        /// handles memory out of bound exception
        /// </summary>
        ManageMemory,
    }
}
