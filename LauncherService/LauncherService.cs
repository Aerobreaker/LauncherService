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

namespace LauncherService
{
    public partial class LauncherService : ServiceBase
    {
        private int _eventID = 1;

        public LauncherService()
        {
            InitializeComponent();
            //TODO: Add event logging
            //Maybe create a registry key to loop through with subnodes for each thing to launch?
            //Then each subnode can have startup and shutdown subnodes
            //Then, in the startup and shutdown subnodes could be a bunch of values to be executed on startup and shutdown for each child process

            //turn off logging into the application logs
            this.AutoLog = false;
            if (!EventLog.SourceExists(this.appEventLog.Source))
            {
                EventLog.CreateEventSource(this.appEventLog.Source, this.appEventLog.Log);
            }
        }

        protected override void OnStart(string[] args)
        {
            this.WriteLog("Launcher service starting");
            //Start a ChildProc here, hook input and output
            //Command line arguments via...registry?
        }

        protected override void OnStop()
        {
            this.WriteLog("Launcher service stopping");
            //Stop the ChildProc here
            //Take commands via...registry?
        }

        private void WriteLog(string logMessage, EventLogEntryType type = EventLogEntryType.Information)
        {
            this.appEventLog.WriteEntry(logMessage, type, this._eventID++);
        }
    }
}
