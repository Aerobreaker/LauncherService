
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
            this.LauncherServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.LauncherServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // LauncherServiceProcessInstaller
            // 
            this.LauncherServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.LauncherServiceProcessInstaller.Password = null;
            this.LauncherServiceProcessInstaller.Username = null;
            // 
            // LauncherServiceInstaller
            // 
            this.LauncherServiceInstaller.Description = "Service used to launch other processes as services and interact with them";
            this.LauncherServiceInstaller.DisplayName = "Launcher Service";
            this.LauncherServiceInstaller.ServiceName = "LauncherService";
            this.LauncherServiceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // LauncherInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LauncherServiceProcessInstaller,
            this.LauncherServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LauncherServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller LauncherServiceInstaller;
    }
}