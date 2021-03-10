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
        public NamedPipeClientStream ServOP;
        public NamedPipeClientStream ServIP;
        
        public LauncherControl(string name = "")
        {
            //Create the named pipes
            this.ServOP = new NamedPipeClientStream(".", "LauncherService" + name + "_output", PipeDirection.In, PipeOptions.Asynchronous);
            this.ServIP = new NamedPipeClientStream(".", "LauncherService" + name + "_input", PipeDirection.Out, PipeOptions.Asynchronous);
        }

        //Maybe connect in another method and interact with the service there?
        public void Control()
        {
            //Connect the streams
            this.ServIP.Connect(10);
            this.ServOP.Connect(10);

            if (!this.ServIP.IsConnected)
            {
                Console.WriteLine("Unable to connect to service input stream!");
                return;
            }
            if (!this.ServOP.IsConnected)
            {
                Console.WriteLine("Unable to connect to service output stream!");
            }


        }
    }
}
