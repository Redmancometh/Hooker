using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agent
{
    public partial class ProfilerWindow : Form
    {
        private List<Control> createdControls = new List<Control>();
        public ProfilerWindow()
        {
            InitializeComponent();
        }

        public void addToList()
        {

        }

        public void checkClasses()
        {
            Dictionary<Type, List<object>> objectMap = Agent.classDictionary;
            objectList.Items.Clear();
            foreach (Type type in objectMap.Keys)
            {
                foreach (object o in objectMap[type])
                {
                    objectList.Items.Add(o);
                }
            }
        }

        private void ProfilerWindow_Load(object sender, EventArgs e)
        {

        }

        private void objectListChanged(object sender, EventArgs e)
        {
            methodList.Items.Clear();
            Type type = objectList.SelectedItem.GetType();
            foreach (MethodInfo method in type.GetMethods())
            {
                methodList.Items.Add(method);
            }
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            checkClasses();
        }

        private void removeLabels()
        {
            foreach (Control label in createdControls)
            {
                this.Controls.Remove(label);
            }
            createdControls.Clear();
        }

        private void methodListUpdated(object sender, EventArgs e)
        {
            removeLabels();
            object obj = methodList.SelectedItem;
            if (obj != null)
            {
                MethodInfo method = obj as MethodInfo;
                int index = 0;
                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    int xOffset = 0;
                    if (index % 8 == 0 && index != 0)
                    {
                        xOffset += 120;
                    }
                    Label label = new Label();
                    TextBox paramField = new TextBox();
                    paramField.Location = new Point(xOffset + 62, 235 + (40 * index));
                    paramField.Name = "param" + index;
                    paramField.Size = new Size(100, 13);
                    paramField.Text = "Value ";
                    label.Location = new Point(12 + xOffset, 240 + (40 * index));
                    label.Name = "arg" + index;
                    label.Size = new Size(40, 13);
                    label.Text = parameter.ParameterType.Name;
                    this.createdControls.Add(label);
                    this.createdControls.Add(paramField);
                    this.Controls.Add(label);
                    this.Controls.Add(paramField);
                    Console.WriteLine(index);
                    index++;
                }
            }
        }

        private void invokeClick(object sender, EventArgs e)
        {
            MethodInfo method = methodList.SelectedItem as MethodInfo;
            object returnValue = null;
            int paramCount = method.GetParameters().Count();
            if (paramCount > 0)
            {
                List<object> paramsList = new List<object>();
                for (int x = 0; x < paramCount; x++)
                {
                    foreach (Control control in createdControls)
                    {
                        if (control.Name == "param" + x)
                        {
                            paramsList.Add(getParamObject(control.Text, method.GetParameters()[x].ParameterType));
                        }
                    }
                }
                returnValue = method.Invoke(objectList.SelectedItem, paramsList.ToArray());
                MessageBox.Show("Invoked Method!");
            }
            else
            {
                returnValue = method.Invoke(objectList.SelectedItem, new object[] { });
            }
            if (returnValue != null)
            {
                Console.WriteLine(returnValue);
            }

        }

        private object getParamObject(String param, Type paramClass)
        {
            switch (Type.GetTypeCode(paramClass))
            {
                case TypeCode.Byte:
                    return byte.Parse(param);
                case TypeCode.SByte:
                    return sbyte.Parse(param);
                case TypeCode.UInt16:
                    return ushort.Parse(param);
                case TypeCode.UInt32:
                    return uint.Parse(param);
                case TypeCode.UInt64:
                    return ulong.Parse(param);
                case TypeCode.Int16:
                    return short.Parse(param);
                case TypeCode.Int32:
                    Console.WriteLine("int32");
                    return int.Parse(param);
                case TypeCode.Int64:
                    return long.Parse(param);
                case TypeCode.Decimal:
                    return decimal.Parse(param);
                case TypeCode.Double:
                    return double.Parse(param);
                case TypeCode.Single:
                    return float.Parse(param);
                case TypeCode.Boolean:
                    return Boolean.Parse(param.Replace(" ", String.Empty));
                default:
                    return param;
            }
        }

        private void methodList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkStatic_Click(object sender, EventArgs e)
        {
            
        }
    }
}
