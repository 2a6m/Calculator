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

    //Attributes

        private List<string> pathList = new List<string>();
        public List<IFunction> FunctionList { get; private set; }


    //Constructor

        public FunctionManager()
        {
            this.FunctionList = new List<IFunction>();
            //string pathtest = Directory.GetCurrentDirectory() + @"\FunctionFramework.dll";
            string pathtest = @"C:\Users\Arnaud\source\repos\Calculator\FunctionFramework\bin\Debug\FunctionFramework.dll";
            Console.WriteLine("Origin path = " + pathtest);
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

        private void AddFunction(IFunction fct)
        {
            List<IFunction> functionlist = this.FunctionList;
            functionlist.Add(fct);
            this.FunctionList = functionlist;
        }
    
        public List<IFunction> SearchFunction(string name)
        {
            //Return a list of IFunctions whose name equals the given 'name' parameter;

            List<IFunction> fctlist = new List<IFunction>();
            foreach(IFunction foo in this.FunctionList)
            {
                if(foo.Name.Equals(name))
                {
                    fctlist.Add(foo);
                }
            }
            return fctlist;
        }


        // Evaluate

        public string Evaluate(string name, string[] args)
        {
            IFunction fct = this.SearchFunction(name)[0];
            //[TODO]: What should it do if searchfunction returns a list longer than 1 or emty?
            Type type = fct.GetType();
            var result = type.InvokeMember("Evaluate", BindingFlags.InvokeMethod, null, fct, new object[] { args });
            string ans = result.ToString();
            Console.WriteLine(ans);
            return ans;
        }

    // DLL Manager

        public void LoadDLL(string path)
        {
            /*
            [TODO]: if AddPath fails because the path already exists,
            LoadDLL should not execute LoadFunctions(path)
            */

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
                IFunction fct = (IFunction)Activator.CreateInstance(type);

                this.AddFunction(fct);

                //[TODO] Create an instance and cast it immediately into Function<T>
                
                /* FIRST ATTEMPT to cast 'fct' into its original type
                
                //[ISSUE]: 't' is a variable but used as a type
                              
                MethodInfo methodinfo = type.GetMethod("Evaluate");
                var returntype = methodinfo.ReturnType;
                //dynamic t;
                //t = (dynamic)returntype;
                Function<returntype> fct = (Function<returntype>)Activator.CreateInstance(type);
                
                Console.WriteLine(fct.Name + " is returning " + returntype);
                */


                /* SECOND ATTEMPT
                
                [SOURCE]: stackoverflow.com/questions/9140873/how-to-use-activator-to-create-an-instance-of-a-generic-type-and-casting-it-back
                [ISSUE]: One must know the object that implements Function<T>...

                Type classType = typeof(Function<>);
                Type[] typeParams = new Type[] { type };
                Type constructedType = classType.MakeGenericType(typeParams);
                var fct = (object) Activator.CreateInstance(constructedType, new object[] { });
                var method = constructedType.GetMethod("Evaluate");
                var res = method.Invoke(fct, new object[] { } );
                */
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

