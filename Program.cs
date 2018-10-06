using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MethodInfoDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly myAssembly = Assembly.LoadFrom("ReflectionLibrary.dll");

            Type t = myAssembly.GetType("ReflectionLibrary.Calculate");

            MethodInfo[] methods = t.GetMethods();
            Console.WriteLine("Number of Methods : " + methods.Length);

            foreach (MethodInfo m in methods)
            {
                Console.WriteLine("**************Method Name : " + m.Name);
                Console.WriteLine("Is Abstract : " + m.IsAbstract);
                Console.WriteLine("Is Constructor : " + m.IsConstructor);
                Console.WriteLine("Is Final : " + m.IsFinal);
                Console.WriteLine("Is Generic Method : " + m.IsGenericMethod);
                Console.WriteLine("Is Private : " + m.IsPrivate);
                Console.WriteLine("Is Public : " + m.IsPublic);
                Console.WriteLine("Is Static : " + m.IsStatic);
                Console.WriteLine("Is Virtual : " + m.IsVirtual);
                Console.WriteLine("Return Parameter : " + m.ReturnParameter);
                Console.WriteLine("Return Type : " + m.ReturnType);

                ParameterInfo[] para = m.GetParameters();
                Console.WriteLine("Number of Parameters : " + para.Length);
                foreach (ParameterInfo p in para)
                {
                    Console.WriteLine("\tParameter Name : " + p.Name);
                    Console.WriteLine("\tParameter Type : " + p.ParameterType);
                }
                Console.WriteLine();
            }

            object calObj = myAssembly.CreateInstance("ReflectionLibrary.Calculate");
            MethodInfo addMethod = t.GetMethod("Add");
            int sum = (int)addMethod.Invoke(calObj, new object[] { 23, 67 });
            Console.WriteLine("Addition : " + sum);

            MethodInfo subtractMethod = t.GetMethod("Subtract");
            int sub = (int)subtractMethod.Invoke(null, new object[] { 67, 23 });
            Console.WriteLine("Subtraction : " + sub);

            Console.ReadKey();
        }
    }
}
