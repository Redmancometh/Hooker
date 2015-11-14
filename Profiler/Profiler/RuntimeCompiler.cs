using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;

namespace Profiler
{
    class RuntimeCompiler
    {
        public RuntimeCompiler()
        {

        }

        public CompilerResults compileCode(String className, String code, String file)
        {
            code = appendCode(className, code);
            Console.Write(code);
            Console.Write("\n\n\n");
            System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = file;
            return CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromSource(parameters, code);
            //Console.WriteLine(Assembly.LoadFrom(file).GetType("B").GetField("k").GetValue(null));
        }

        public String appendCode(String className, String code)
        {
           return "namespace Profiler\n{\nclass "+className+"\n{\n" + code + "\n}\n}";
        }

    }
}
