using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace Profiler
{
    public class ProcessHook
    {
        // Will be re-used for exe support private AssemblyDefinition sourceAssembly;
        private ModuleDefinition sourceAssembly;
        private AssemblyDefinition targetAssembly;
        private MethodDefinition sourceMethod;
        //  private Thread hookThread;
        private String fileName;
        public List<Type> getTypes()
        {
            return null;
        }

        public void setSourceAssembly(ModuleDefinition assembly)
        {
            this.sourceAssembly = assembly;
            sourceMethod = getMethodFromTypeCollection(sourceAssembly.Types, "jumpMethod");
            Console.WriteLine(sourceMethod.Module);
        }

        public Boolean hasFileName()
        {
            if (fileName != null)
            {
                return true;
            }
            return false;
        }

        public void setTargetAssembly(String fileName)
        {
            this.fileName = fileName;
            if (System.IO.File.Exists(fileName))
            {
                checkBackup();
                this.targetAssembly = AssemblyDefinition.ReadAssembly(fileName + ".bak");
            }
        }

        public void attemptHook()
        {
            insertHookInstructions();
        }

        public void insertHookInstructions()
        {
            MethodDefinition targetMethod = targetAssembly.EntryPoint;
            Console.WriteLine(targetMethod.FullName);
            foreach (Instruction instruction in sourceMethod.Body.Instructions)
            {
                if (instruction.Operand is TypeReference)
                {
                    instruction.Operand = targetAssembly.MainModule.Import((TypeReference)instruction.Operand);
                }
                if (instruction.Operand is MethodReference)
                {
                    instruction.Operand = targetAssembly.MainModule.Import((MethodReference)instruction.Operand);
                }
                if (instruction.Operand is FieldReference)
                {
                    instruction.Operand = targetAssembly.MainModule.Import((FieldReference)instruction.Operand);
                }
                if (instruction.Next == null)
                {
                    break;
                }
                targetMethod.Body.Instructions.Insert(targetMethod.Body.Instructions.Count - 1, instruction);
            }
            targetAssembly.MainModule.Kind = ModuleKind.Console;
            importMethods(targetMethod);
            targetAssembly.Write(fileName.Replace(".exe", "") + "mod.exe");
            foreach (Instruction instruction in targetMethod.Body.Instructions)
            {
                Console.WriteLine(instruction);
            }
        }

        public void insertMethodInstructions(MethodDefinition oldMethod, ModuleDefinition module)
        {

        }


        public void importMethods(MethodDefinition targetMethod)
        {
            /* ModuleDefinition module = targetMethod.Module;
             var type = new TypeDefinition("Profiler","Agent",Mono.Cecil.TypeAttributes.Public | Mono.Cecil.TypeAttributes.Abstract | Mono.Cecil.TypeAttributes.Sealed,module.Import(typeof(object)));
             module.Types.Add(type);
             var method = new MethodDefinition("Start",Mono.Cecil.MethodAttributes.Public | Mono.Cecil.MethodAttributes.Static,module.Import(typeof(void)));

             type.Methods.Add(method);

             method.Parameters.Add(new ParameterDefinition(module.Import(typeof(string))));*/

            ModuleDefinition module = targetMethod.Module;
            foreach (TypeDefinition type in sourceAssembly.Types)
            {
                Console.WriteLine("Attributes" + type.Attributes);
                var newType = new TypeDefinition(type.Namespace, type.Name, type.Attributes, module.Import(typeof(object)));
                module.Types.Add(newType);
                foreach (MethodDefinition method in type.Methods)
                {
                    var newMethod = new MethodDefinition(method.Name, method.Attributes, module.Import(method.ReturnType));
                    newType.Methods.Add(newMethod);
                    foreach (ParameterDefinition paramDef in method.Parameters)
                    {
                        newMethod.Parameters.Add(paramDef);
                    }
                }
            }
        }

        public Boolean doSkipImport(TypeReference type)
        {
            switch (type.Name.ToLower())
            {
                case "<module>":
                    return true;
                default: return false;
            }
        }

        public void checkBackup()
        {
            if (!System.IO.File.Exists(fileName + ".bak"))
            {
                System.IO.File.Copy(fileName, fileName + ".bak");
            }
        }

        public static MethodDefinition getMethod(TypeDefinition type, String methodName)
        {
            foreach (MethodDefinition method in type.Methods)
            {
                if (method.Name == methodName)
                {
                    return method;
                }
            }
            return null;
        }

        public static MethodDefinition getMethodFromTypeCollection(Collection<TypeDefinition> types, String methodName)
        {
            foreach (TypeDefinition type in types)
            {
                MethodDefinition method = getMethod(type, methodName);
                if (method != null)
                {
                    return method;
                }
            }
            return null;
        }

    }
}
