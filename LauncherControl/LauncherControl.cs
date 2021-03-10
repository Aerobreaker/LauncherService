using System;
using ProcessLauncher;

/*
 * Todo:
 * 1. Open named pipes for foreground communication
 * 2. Forward input and output from child using named pipes
 * 3. Use pid of child to detect opened ports (optional)
 * 4. Open ports via upnp (either via step 5 or input parameters) (see Device Host API)
 */

namespace ServiceLauncher
{
    class LauncherControl
    {
        static void Main(string[] args)
        {
            Func<string, string> Unescape = System.Text.RegularExpressions.Regex.Unescape;

            Console.Write("Number of arguments:");
            Console.WriteLine(args.Length);

            Console.WriteLine("\nArguments:");

            for (int i = 0; i < args.Length; i++)
            {
                Console.Write(i);
                Console.Write(": ");
                Console.WriteLine(Unescape(args[i]));
            }

            return;

            //Instantiate new child
            ChildProc child = new ChildProc("cmd", "/k echo/test_cmdline", "C:\\Users\\Erik\\");
            //Start the child
            //I thought about including this step in the constructor but decided I wanted to keep them separate in case more manipulation needs to be done first
            child.Start();
            //Get output from the child asynchronously via event handler on the child class
            Console.WriteLine(child.Output);
            //Send input to the child; include trailing newline
            child.Input.WriteLine("echo/test_file>childtest.txt");
            child.Input.WriteLine("exit");
            //This is here for cleanup; I like this for sending a command to terminate the child and then waiting for it to exit cleanly
            child.WaitForExit();
        }
    }
}
