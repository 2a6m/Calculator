using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SuperComputer;

namespace Calculator
{
    class LoadFunction
    {
        private List<IFunction> FunctionList = new List<IFunction>();
        private readonly string path;

        private LoadFunction(string path)
        {
            this.path = path;
            LoadFunctions(this.path);
        }

        static void LoadFunctions(string path)
        {
            Console.WriteLine(path);
            Dictionary<string, object> foo = new Dictionary<string, object>();
            Assembly dll = Assembly.LoadFile(path + @"C:\Users\Arnaud\Desktop\Super Calculator\DLL\Functions\Functions\bin\Debug\Functions.dll");
            Type[] types = dll.GetExportedTypes();
            foreach (Type type in types)
            {
                Function<string> fct = (Function<string>)Activator.CreateInstance(type);
                string name = (string)type.InvokeMember("get_Name", BindingFlags.InvokeMethod, null, fct, null);
                Console.WriteLine("name = " + name);
                
                }
            }
        }
    }
}
    }
}
