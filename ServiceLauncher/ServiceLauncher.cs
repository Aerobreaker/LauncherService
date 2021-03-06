using System;

/*
 * Todo:
 * 1. Open named pipes for foreground communication
 * 2. Forward input and output from child using named pipes
 * 3. Use pid of child to detect opened ports (optional)
 * 4. Open ports via upnp (either via step 5 or input parameters)
 */

namespace ServiceLauncher
{
    class ServiceLauncher
    {
        static void Main(string[] args)
        {
            ChildProc child = new ChildProc("cmd", "/k echo/test_cmdline", "C:\\Users\\Erik\\");
            child.Start();
            //Console.WriteLine("Hello World!");
            //child.WaitForInputIdle(10);
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(child.Output);
            child.Input.WriteLine("echo/test_file>childtest.txt");
            child.Input.WriteLine("exit");
            child.WaitForExit();
        }
    }
}
