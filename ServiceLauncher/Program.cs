using System;

/*
 * Todo:
 * 1. Spawn a child process, take parameters for the process and it's parameters
 * 2. Redirect child's stdin and stdout
 *      see https://www.codeproject.com/Articles/18577/How-to-redirect-Standard-Input-Output-of-an-applic
 * 3. Open named pipes for foreground communication
 * 4. Forward input and output from child using named pipes
 * 5. Use pid of child to detect opened ports (optional)
 * 6. Open ports via upnp (either via step 5 or input parameters)
 */

namespace ServiceLauncher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
