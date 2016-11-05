using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using System.Reflection;
using System.IO;

namespace Application
{
    class Application
    {
        static void Main(string[] args)
        {
            string directory = "C:\\Users\\all\\Documents\\Visual Studio 2015\\Projects\\Plug-ins\\Plugins\\";
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            foreach (FileInfo file in directoryInfo.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                foreach (var type in assembly.GetTypes())
                    if (type.GetInterface("IPlugin") != null)
                        Console.WriteLine((Activator.CreateInstance(type) as IPlugin).Name);
            }
            Console.ReadKey();
        }
    }
}
