using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeServer
{
    internal class Logger
    {
        public Logger() 
        { }

        public void Log(string logMsg)
        {
            Console.WriteLine(logMsg);
        }
    }    
}
