using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;
using System.Reflection;

namespace LauncherService
{
    static class LauncherServiceControl
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                //Run interactively - installer goes here
                //Parse command line args
                string action = args[0].ToLower();
                if (action == "install" || action == "uninstall")
                {
                    //Create the dynamic installer
                    string name = args[1];
                    string logfile = name.ToLower() + "_installer.log";
                    TransactedInstaller dynInstaller = new TransactedInstaller
                    {
                        Context = new InstallContext(logfile, new string[] { "assemblyPath", Assembly.GetExecutingAssembly().Location+ " " + name })
                    };
                    dynInstaller.Installers.Add(new LauncherInstaller(name));
                    
                    if (action == "install")
                    {
                        //Install a service
                        dynInstaller.Install(new Hashtable());
                    }
                    else
                    {
                        //Uninstall a service
                        dynInstaller.Uninstall(null);
                    }
                }
                else if (action == "interact")
                {
                    //Interact with a running service

                }
                else
                {
                    //GUI

                }
            }
            else
            {
                string name = args[1];
                //Run as service - service stuff goes here
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new LauncherService(name)
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
