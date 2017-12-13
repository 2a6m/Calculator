using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SuperComputer;
using System.IO;

namespace Calculator
{
    public class FunctionManager
    {
        private List<IFunction> FunctionList = new List<IFunction>();
        private List<string> pathList = new List<string>();

        public FunctionManager()
        {
            string pathtest = Directory.GetCurrentDirectory() + "/FunctionFramework.dll";
            Console.WriteLine(pathtest);
            this.AddPath(pathtest);
            foreach(string path in this.pathList)
            {
                try
                {
                    LoadFunctions(path);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            
        }

        void LoadFunctions(string path)
        {
            //Load functions from a DLL specified with the path
            Assembly dll = Assembly.LoadFile(path);
            Type[] types = dll.GetExportedTypes();
            foreach (Type type in types)
            {
                Function<string> fct = (Function<string>)Activator.CreateInstance(type);
                string name = (string)type.InvokeMember("get_Name", BindingFlags.InvokeMethod, null, fct, null);
                Console.WriteLine("name = " + name);
                this.FunctionList.Add(fct);                
                
            }
        }

        public void AddPath(string path)
        {
            //add a path to the path list of all existing DLL containing functions
            bool ans = true;
            int i = 0;
            while (ans && i < this.pathList.Count())
            {
                string pathtocheck = this.pathList[i];
                if (pathtocheck.Equals(path)) {ans = false;}
                i++;
            }
            if(ans) { this.ForceAddPath(path); }
            else{ throw new FunctionManagerException("Tried to add an already existing path"); }
        }

        private void ForceAddPath(string path)
        {
            this.pathList.Add(path);
        }
    }

    public class FunctionManagerException : Exception
    {
        public FunctionManagerException(string msg) : base(msg)
        {
        }
    }
}

