using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            // When you have a "Solution" that has a web app project AND a console app project, 
            // configure the console app to be the startup project - how?
            // In Solution Explorer, right-click the console app project, and select
            // "Set as StartUp Project"
            // That way it will run when you run and debug (F5) or run without debug (Ctrl+F5)

            // When you want to run your web app project in a browser, 
            // right-click the web app project (in Solution Explorer), and select
            // View > View in Browser

            // Use the Console.WriteLine() method for output; for example...
            Console.WriteLine("Hello, world!");

        }
    }
}
