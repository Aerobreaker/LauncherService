using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace LauncherService
{
    class LauncherControl
    {
        public LauncherControl(string name = "")
        {
            //Create the named pipes
            NamedPipeClientStream servop = new NamedPipeClientStream(".", "LauncherService" + name + "_output", PipeDirection.In, PipeOptions.Asynchronous);
            NamedPipeClientStream servip = new NamedPipeClientStream(".", "LauncherService" + name + "_input", PipeDirection.Out, PipeOptions.Asynchronous);

            servop.ConnectAsync();
            servip.ConnectAsync();

            //Do...something with them
        }

        //Maybe connect in another method and interact with the service there?
    }
}
