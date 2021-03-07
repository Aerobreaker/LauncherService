using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace LauncherService
{
    public partial class LauncherService : ServiceBase
    {
        public LauncherService()
        {
            InitializeComponent();
            //TODO: Add event logging
            //Maybe create a registry key to loop through with subnodes for each thing to launch?
            //Then each subnode can have startup and shutdown subnodes
            //Then, in the startup and shutdown subnodes could be a bunch of values to be executed on startup and shutdown for each child process
        }

        protected override void OnStart(string[] args)
        {
            //Start a ChildProc here, hook input and output
            //Command line arguments via...registry?
        }

        protected override void OnStop()
        {
            //Stop the ChildProc here
            //Take commands via...registry?
        }
    }
}
