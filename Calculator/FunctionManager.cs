using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using SuperComputer;
using System.IO;
using static SuperComputer.Function<string>;

namespace Calculator
{
    public class FunctionManager
    {

    //Attributes

        private List<string> pathList = new List<string>();
        public List<Function<string>> FunctionList { get; private set; }


    //Constructor

        public FunctionManager()
        {
            this.FunctionList = new List<Function<string>>();
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


    // Getter - Setter - and other attribute managing functions

        private void AddFunction(Function<string> fct)
        {
            List<Function<string>> functionlist = this.FunctionList;
            functionlist.Add(fct);
            this.FunctionList = functionlist;
        }
    
        public List<Function<string>> SearchFunction(string name)
        {
            //Return a list of IFunctions whose name equals the given 'name' parameter;

            List<Function<string>> fctlist = new List<Function<string>>();
            foreach(Function<string> foo in this.FunctionList)
            {
                if(foo.Name.Equals(name))
                {
                    fctlist.Add(foo);
                }
            }
            return fctlist;
        }


    // Other Methods

        public void LoadDLL(string path)
        {
            this.AddPath(path);
            this.LoadFunctions(path);
        }

        private void LoadFunctions(string path)
        {
            //Load functions from a DLL specified with the path
            Assembly dll = Assembly.LoadFile(path);
            Type[] types = dll.GetExportedTypes();
            foreach (Type type in types)
            {
                Function<string> fct = (Function<string>)Activator.CreateInstance(type);
                string name = (string)type.InvokeMember("get_Name", BindingFlags.InvokeMethod, null, fct, null);
                Console.WriteLine("fct = " + fct.ToString());
                this.AddFunction(fct);                
                
            }
        }

        private void AddPath(string path)
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


    //Exceptions 

    public class FunctionManagerException : Exception
    {
        public FunctionManagerException(string msg) : base(msg)
        {
        }
    }
}

