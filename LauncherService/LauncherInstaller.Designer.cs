
namespace LauncherService
{
    partial class LauncherInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LauncherService = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // LauncherService
            // 
            this.LauncherService.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.LauncherService.Password = null;
            this.LauncherService.Username = null;
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "Service used to launch other processes as services and interact with them";
            this.serviceInstaller1.DisplayName = "Launcher Service";
            this.serviceInstaller1.ServiceName = "LauncherService";
            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // LauncherInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LauncherService,
            this.serviceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LauncherService;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}