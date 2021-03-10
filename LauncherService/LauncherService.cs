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

        public LauncherService(string name="")
        {
            //Runs once when the service is started the first time
            InitializeComponent();
            /* Todo:
             * 1. Take command line parameter for installer to set service name; use TransactedInstaller to install and uninstall?
             * 2. Take command line parameter on service for the name
             * 3. Store startup and shutdown commands, either in registry or ini file, based on service name
             * 4. Include the code to start the child process
             * 5. Create named pipes for interprocess communication
             * 6. Get rid of launchercontrol?  Should be able to detect between runnig as service and running interactively, using Environment.UserInteractive
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
            this.WriteLog("Launcher service starting, servicename: " + this.ServiceName + ", name: " + name);

            NamedPipeServerStream opstream = new NamedPipeServerStream("LauncherService" + name + "_output", PipeDirection.Out, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            NamedPipeServerStream ipstream = new NamedPipeServerStream("LauncherService" + name + "_input", PipeDirection.In, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);

            opstream.WaitForConnectionAsync();
            ipstream.WaitForConnectionAsync();

            //Next, create ChildProc and loop somehow to link ChildProc streams to ipstream and opstream
            //Child process and command line args, plus startup commands will probably be taken from an ini file in %localappdata%\LauncherService\{name}
        }

        protected override void OnStop()
        {
            //Runs every time the service stops
            this.WriteLog("Launcher service stopping");
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
