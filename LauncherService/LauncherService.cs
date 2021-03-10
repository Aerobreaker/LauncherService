using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ProcessLauncher;
using System.IO.Pipes;

namespace LauncherService
{
    public partial class LauncherService : ServiceBase
    {
        private int _eventID = 1;
        public string InstanceName = "";
        public NamedPipeServerStream OPStream;
        public NamedPipeServerStream IPStream;

        public LauncherService(string name="")
        {
            //Runs once when the service is started the first time
            InitializeComponent();
            /* Todo:
             * 1. Create callback functions for async connections and reads
             * 2. Change the connection waits to use BeginWaitForConnection
             * 3. In LauncherControl.cs, create callback function async reads
             * 4. Figure out how to read and write using the pipes
             * 5. Store startup and shutdown commands, either in registry or ini file, based on service name
             * 6. Include the code to start the child process
             * 7. Use named pipes to facilitate comms with ChildProc
             * 8. Use pid of ChildProc to detect open ports (optional)
             * 9. Open ports via UPnP (either via open ports on child pid or via input parameters) (see Device Host API)
             */

            //Turn off logging into the application logs
            this.AutoLog = false;
            this.ServiceName = name;
            if (!EventLog.SourceExists(this.appEventLog.Source))
            {
                EventLog.CreateEventSource(this.appEventLog.Source, this.appEventLog.Log);
            }
        }

        protected override void OnStart(string[] args)
        {
            //Runs every time the service starts
            string name = args[0];
            this.InstanceName = name;
            this.WriteLog("Launcher service starting, servicename: " + this.ServiceName + ", name: " + name);

            this.OPStream = new NamedPipeServerStream("LauncherService" + name + "_output", PipeDirection.Out, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            this.IPStream = new NamedPipeServerStream("LauncherService" + name + "_input", PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);

            this.OPStream.WaitForConnectionAsync();
            this.IPStream.WaitForConnectionAsync();

            //Next, create ChildProc and loop somehow to link ChildProc streams to ipstream and opstream
            //Child process and command line args, plus startup commands will probably be taken from an ini file in %localappdata%\LauncherService\{name}
        }

        protected override void OnStop()
        {
            //Runs every time the service stops
            this.WriteLog("Launcher service stopping, servicename: " + this.ServiceName + ", name: " + this.InstanceName);
            this.OPStream.Close();
            this.IPStream.Close();
            //Stop the ChildProc here
            //Take commands via...registry?
        }

        protected override void OnShutdown()
        {
            //Respond to an OS shutdown event
            //Maybe OnStop with a timeout?
            base.OnShutdown();
        }

        private void WriteLog(string logMessage, EventLogEntryType type = EventLogEntryType.Information)
        {
            this.appEventLog.WriteEntry(logMessage, type, this._eventID++);
        }
    }
}
