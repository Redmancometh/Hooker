using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Mono.Cecil.Rocks;
namespace Profiler
{
    public class ProcessHook
    {
        public ProcessHook()
        {

        }
        // Will be re-used for exe support private AssemblyDefinition sourceAssembly;
        private ModuleDefinition sourceAssembly;
        private AssemblyDefinition targetAssembly;
        private MethodDefinition sourceMethod;
        //  private Thread hookThread;
        private String fileName;
        private Regex ldRegex = new Regex("ldloc[.]\\d+");
        private Regex stRegex = new Regex("stloc[.]\\d+");
        private Regex numRegex = new Regex("\\d+");
        public bool replaceEntry = false;
        public String dllEntry { get; set; }
        enum HookType { DLL, EXE, UNSUPPORTED };
        public List<Type> getTypes()
        {
            return null;
        }

        public void setReplaceEntry(bool replaceEntry)
        {
            this.replaceEntry = replaceEntry;
        }

        private static HookType getHookType(String fileName)
        {
            if (fileName.EndsWith(".dll"))
            {
                return HookType.DLL;
            }
            else if (fileName.EndsWith(".exe"))
            {
                return HookType.EXE;
            }
            return HookType.UNSUPPORTED;
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
                Console.WriteLine("trying to load " + fileName);
                this.targetAssembly = AssemblyDefinition.ReadAssembly(fileName + ".bak");
            }
        }

        public virtual void attemptHook(bool constructorHooks)
        {
            HookType type = getHookType(fileName);
            switch (type)
            {
                case HookType.DLL:
                    MessageBox.Show("DLL");
                    processHooks(constructorHooks);
                    targetAssembly.Write(fileName.Replace(".dll", "") + "mod.dll");
                    break;
                case HookType.EXE:
                    insertEXEHookInstructions();
                    processHooks(constructorHooks);
                    targetAssembly.Write(fileName.Replace(".exe", "") + "mod.exe");
                    break;
                case HookType.UNSUPPORTED:
                    MessageBox.Show("Unsupported assembly type");
                    return;
            }
        }

        public void processHooks(bool constructorHooks)
        {
            importMethods();
            if (constructorHooks)
            {
                hookConstructors();
            }
        }

        public virtual void insertEXEHookInstructions()
        {
            MethodDefinition targetMethod = targetAssembly.EntryPoint;
            int index = 0;
            removeReturns(sourceMethod);
            removeReturns(targetMethod);
            if (replaceEntry)
            {
                targetMethod.Body.Instructions.Clear();
            }
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
                    targetMethod.Body.Instructions.Insert(targetMethod.Body.Instructions.Count, Instruction.Create(OpCodes.Ret));
                    break;
                }
                targetMethod.Body.Instructions.Insert(index++, instruction);
            }
            targetAssembly.MainModule.Kind = ModuleKind.Console;
        }

        public virtual void importMethods()
        {
            ModuleDefinition module = targetAssembly.MainModule;
            foreach (TypeDefinition type in sourceMethod.Module.Types)
            {
                if (type.Name == "<Module>") continue;
                TypeDefinition newType = new TypeDefinition(type.Namespace, type.Name, type.Attributes, module.Import(typeof(object)));
                module.Types.Add(newType);
                foreach (MethodDefinition method in type.Methods)
                {
                    if (!method.HasBody)
                    {
                        continue;
                    }
                    MethodDefinition newMethod = new MethodDefinition(method.Name, method.Attributes, module.Import(method.ReturnType));
                    newMethod.Body.InitLocals = true;
                    registerVars(method, newMethod);
                    foreach (Instruction instruction in method.Body.Instructions)
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
                            newMethod.Body.GetILProcessor().Append(Instruction.Create(OpCodes.Ret));
                            break;
                        }
                        newMethod.Body.GetILProcessor().Append(instruction);
                    }
                    newType.Methods.Add(newMethod);
                }
            }
        }

        public virtual void hookConstructors()
        {
            MethodDefinition sourceMethodBegin = getMethodFromTypeCollection(sourceAssembly.Types, "beginConstructorHook");
            MethodDefinition sourceMethodEnd = getMethodFromTypeCollection(sourceAssembly.Types, "endConstructorHook");
            foreach (ModuleDefinition module in targetAssembly.Modules)
            {
                foreach (TypeDefinition type in module.Types)
                {
                    foreach (MethodDefinition method in type.Methods)
                    {
                        if (!method.HasBody || method == null)
                        {
                            continue;
                        }
                        if (method.IsConstructor)
                        {
                            removeReturns(method);
                            if (sourceMethodBegin.HasBody)
                            {
                                removeReturns(sourceMethodBegin);
                                registerVars(sourceMethodBegin, method);
                                foreach (Instruction instruction in sourceMethodBegin.Body.Instructions)
                                {
                                    method.Body.Instructions.Insert(0, instruction);
                                }
                            }
                            if (sourceMethodEnd.HasBody)
                            {
                                removeReturns(sourceMethodEnd);
                                registerVars(sourceMethodEnd, method);
                                foreach (Instruction instruction in sourceMethodEnd.Body.Instructions)
                                {
                                    method.Body.Instructions.Insert(method.Body.Instructions.Count - 1, instruction);
                                }
                            }
                            method.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
                        }
                    }
                }
            }
        }

        public void removeReturns(MethodDefinition method)
        {
            List<int> removalIndexes = new List<int>();
            for (int x = 0; x<method.Body.Instructions.Count; x++)
            {
                if(method.Body.Instructions[x].OpCode.ToString().Contains("ret"))
                {
                    removalIndexes.Add(x);
                }
            }
            foreach(int index in removalIndexes)
            {
                try
                {
                    Console.WriteLine("Removed: " + method.Body.Instructions[index]);
                    method.Body.Instructions.RemoveAt(index);
                }
                catch(Exception e)
                {

                }
            }
        }

        public virtual void registerVars(MethodDefinition oldMethod, MethodDefinition newMethod)
        {
            if (oldMethod.Body.HasVariables)
            {
                foreach (VariableDefinition variable in oldMethod.Body.Variables)
                {
                    try
                    {
                        object typeRef = newMethod.Module.Import(variable.VariableType);
                        newMethod.Body.GetILProcessor().Append(typeRef as Instruction);
                        newMethod.Body.Variables.Add(new VariableDefinition(variable.VariableType));
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            }
        }

        public int getStlocStart(MethodDefinition method)
        {
            int stLoc = 0;
            foreach (Instruction instruction in method.Body.Instructions)
            {
                foreach (Match match in stRegex.Matches(instruction.ToString()))
                {
                    Console.WriteLine(match.Value + " Match");
                    try
                    {
                        int stBuffer = Int32.Parse(numRegex.Match(match.Value).Value);
                        if (stBuffer > stLoc)
                        {
                            stLoc = stBuffer;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        continue;
                    }

                }
            }
            Console.WriteLine("Returning stloc at " + stLoc);
            return stLoc;
        }

        public int getLdlocStart(MethodDefinition method)
        {
            int ldloc = 0;
            foreach (Instruction instruction in method.Body.Instructions)
            {
                foreach (Match match in ldRegex.Matches(instruction.ToString()))
                {
                    Console.WriteLine(match.Value + " Match");
                    try
                    {
                        int stBuffer = Int32.Parse(numRegex.Match(match.Value).Value);
                        if (stBuffer > ldloc)
                        {
                            ldloc = stBuffer;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.StackTrace);
                        continue;
                    }
                }
            }
            Console.WriteLine("Returning stloc at " + ldloc);
            return ldloc;
        }

        public virtual void importMethods(MethodDefinition targetMethod)
        {
            ModuleDefinition module = targetMethod.Module;
            foreach (TypeDefinition type in sourceAssembly.Types)
            {
                targetAssembly.MainModule.Import(type);
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
                if (method.Name == methodName && method.HasBody)
                {
                    Console.WriteLine("Found: " + method);
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
