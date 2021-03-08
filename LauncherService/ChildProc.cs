using System.IO;
using System.Text;
using System.Diagnostics;


namespace ProcessLauncher
{
    class ChildProc
    {
        //Should this be public maybe?  It would simplify the class because anything that's not being manipulated here could be accessed directly
        private Process _proc { get; set; }
        public StreamWriter Input { get => this._proc.StandardInput; }
        //StreamReaders are used for synchronous output...which I couldn't figure out anyway
        //Stringbuilders are used for asynchrounous output.  Better than strings because they're mutable
        //For some reason, building them as properties with auto generated getters and setters didn't work...
        public StringBuilder Output = null;
        public StringBuilder Error = null;

        public ChildProc(string path, string args = "", string workingDir = "")
        {
            this._proc = new Process
            {
                StartInfo = new ProcessStartInfo(path, args)
                {
                    //Don't create a separate window for the child
                    CreateNoWindow = true,
                    //Don't execute using the shell (so that we can redirect stdout and stderr)
                    UseShellExecute = false,
                    //Don't give an error dialog if the child can't be started
                    ErrorDialog = false,
                    //Redirect standard streams
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    //Start in the provided working directory
                    WorkingDirectory = workingDir
                }
            };

            //Need to instantiate new stringbuilders; cap size to 2048 bytes (this can probably be expanded, but 2k characters should be plenty)
            this.Output = new StringBuilder(1, 2048);
            this.Error = new StringBuilder(1, 2048);

            //Add our custom event handlers to the output and error data received events for async reading from the streams
            this._proc.OutputDataReceived += ChildOutputHandler;
            this._proc.ErrorDataReceived += ChildErrorHandler;
        }

        public bool Start()
        {
            //So first actually start the process, duh.  Can't be last because the async stream reading has to start after the process starts
            bool outp = this._proc.Start();
            //Then begin async reading of output and error streams
            this._proc.BeginOutputReadLine();
            this._proc.BeginErrorReadLine();
            //Return the output from starting the process
            return outp;
        }

        //Forward some properties and methods from the process
        public int Id { get => this._proc.Id; }
        public bool HasExited { get => this._proc.HasExited; }
        public void WaitForExit(int timeout = -1)
        {
            this._proc.WaitForExit(timeout);
        }
        public bool WaitForInputIdle(int timeout = -1)
        {
            return this._proc.WaitForInputIdle(timeout);
        }

        //Event handlers for async reading output and error streams
        private void ChildOutputHandler(object sendingProcess, DataReceivedEventArgs outp)
        {
            if (!string.IsNullOrEmpty(outp.Data))
            {
                this.Output.Append(outp.Data);
            }
        }
        private void ChildErrorHandler(object sendingProcess, DataReceivedEventArgs outp)
        {
            if (!string.IsNullOrEmpty(outp.Data))
            {
                this.Error.Append(outp.Data);
            }
        }
    }
}
