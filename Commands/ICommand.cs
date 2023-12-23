using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogamePersonalProject.Commands
{
    /// <summary>
    /// Interface for all commands
    /// </summary>
    internal interface ICommand
    {
        /// <summary>
        /// Simply executes a single command, all variables are dependent on Constructor
        /// </summary>
        public void Execute();
    }
}
