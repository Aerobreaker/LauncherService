using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace LauncherService
{
    [RunInstaller(true)]
    public partial class LauncherInstaller : System.Configuration.Install.Installer
    {
        public LauncherInstaller(string name="")
        {
            InitializeComponent();
            this.LauncherServiceInstaller.ServiceName = name;
        }
    }
}
