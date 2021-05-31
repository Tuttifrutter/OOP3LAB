using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Reflection;
using OOP3LAB;
using System.Text;
using System.CodeDom;

namespace OOP3LAB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }
        public List<Automobile> transports = new List<Automobile>();
       
        public Automobile[] transportclasses = { new Truck(), new FireTruck(), new TankerTruck(), new GarbageTruck(), new ArmoredCar(), new PassengerCar(), new TaxiCar(), new PoliceCar(), new Bus(), new Trolleybus(), };
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0;i<transportclasses.Length;i++)
            {
                comboBox1.Items.Add(transportclasses[i].Type);
            }

        }

        private void ShowDataGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Automobile tr in transports)
            {
                string driverinform="";
                if (tr.Driver != null)
                {
                    driverinform = "Имя: " + tr.Driver.firstName + "; Фамилия: " + tr.Driver.secondName + "; Возраст: " + tr.Driver.age + "; Профессия: " + tr.Driver.profession+";";
                }
                
                dataGridView1.Rows.Add(tr.Type, tr.Mark, tr.Model, driverinform, tr.Color, tr.Add, tr.status);
            }
        }
        private void BtnNew_Click(object sender, EventArgs e)
        {
            Automobile transport=new Truck();
            string trType = (string)comboBox1.SelectedItem;
            foreach(Automobile tr in transportclasses)
            {
                if(tr.Type == trType)
                {
                    transport = (Automobile)tr.Clone();
                    break;
                }
            }

            if((transport.Color = Interaction.InputBox("Введите цвет:", "Цвет", "Синий"))!="")
            {
                if((transport.Mark = Interaction.InputBox("Введите марку:", "Марка", "ВАЗ"))!="")
                {
                    if ((transport.Model = Interaction.InputBox("Введите модель:", "Модель", "2109"))!="")
                    {
                        string firstName, secondName, age, profession;
                        if ((firstName = Interaction.InputBox("Введите имя водителя:", "Имя", "Иван"))!="")
                        {
                            if ((secondName = Interaction.InputBox("Введите фамилию водителя:", "Фамилия", "Иванов"))!="")
                            {
                                if((age = Interaction.InputBox("Введите возраст водителя:", "Возраст", "18"))!="")
                                {
                                    if((profession = Interaction.InputBox("Введите профессию водителя:", "Профессия", "Таксист"))!="")
                                    {
                                        transport.Driver = new DriverInfo()
                                        { 
                                            firstName = firstName, secondName = secondName, age = age, profession = profession 
                                        };
                                        transports.Add(transport);
                                        ShowDataGrid();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog FBD = new SaveFileDialog();
            FBD.Filter = "Files(*.TXT; *.XML; *.BIN)| *.TXT; *.XML; *.BIN; | All files(*.*) | *.*";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                DataGridToList();
                SaveShapes(FBD.FileName);
                MessageBox.Show("Сохранено");
            }
        }

        private void DataGridToList()
        {
            transports.Clear();
            for(int i=0; i<dataGridView1.RowCount-1; i++)
            {
                string trtype = dataGridView1.Rows[i].Cells[0].Value.ToString();
                if(trtype.Contains("."))
                {
                    trtype = new string(trtype.Reverse().ToArray());
                    trtype = trtype.Substring(0, trtype.IndexOf("."));
                    trtype = new string(trtype.Reverse().ToArray());
                }
                 trtype = "OOP3LAB.Form1+" + trtype;
                Assembly asm = Assembly.GetEntryAssembly();
                Type classType = asm.GetType(trtype);
                var tr = (Automobile)Activator.CreateInstance(classType);
                tr.Mark = dataGridView1.Rows[i].Cells[1].Value.ToString();
                tr.Model = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string driverstring = dataGridView1.Rows[i].Cells[3].Value.ToString();
                if(driverstring!="")
                {
                        tr.Driver = new DriverInfo();
                        tr.Driver.firstName = driverstring.Substring(driverstring.IndexOf(':') + 1, driverstring.IndexOf(';') - driverstring.IndexOf(':') - 1).Trim();
                        driverstring = driverstring.Remove(0, driverstring.IndexOf(';') + 1);
                        tr.Driver.secondName = driverstring.Substring(driverstring.IndexOf(':') + 1, driverstring.IndexOf(';') - driverstring.IndexOf(':') - 1).Trim();
                        driverstring = driverstring.Remove(0, driverstring.IndexOf(';') + 1);
                        tr.Driver.age = driverstring.Substring(driverstring.IndexOf(':') + 1, driverstring.IndexOf(';') - driverstring.IndexOf(':') - 1).Trim();
                        driverstring = driverstring.Remove(0, driverstring.IndexOf(';') + 1);
                        tr.Driver.profession = driverstring.Substring(driverstring.IndexOf(':') + 1, driverstring.IndexOf(';') - driverstring.IndexOf(':') - 1).Trim();
                }
                tr.Color = dataGridView1.Rows[i].Cells[4].Value.ToString();
                if(dataGridView1.Rows[i].Cells[5].Value!=null)
                tr.SetAdd(dataGridView1.Rows[i].Cells[5].Value.ToString());
                transports.Add(tr);
                if(dataGridView1.Rows[i].Cells[6].Value!=null)
                tr.status = dataGridView1.Rows[i].Cells[6].Value.ToString();
            }
            
        }

        public void SaveShapes(string filePath)
        {
            string h= filePath.Substring(filePath.LastIndexOf('.'),filePath.Length - filePath.LastIndexOf('.'));
            if (h == ".bin")
            {
                IFormatter formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, transports);
                }
            }
            else if (h == ".xml")
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Automobile>));
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, transports);
                }           
            }
            else if (h == ".txt")
            {
                using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    for(int i = 0; i<transports.Count; i++)
                    {
                        byte[] array = Encoding.Default.GetBytes("\n"+transports[i].Type + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].Mark + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].Model + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].Color + "\n");
                        stream.Write(array, 0, array.Length);
                        if (transports[i].Driver == null)
                            transports[i].Driver = new DriverInfo();
                        array = Encoding.Default.GetBytes(transports[i].Driver.firstName + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].Driver.secondName + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].Driver.age + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].Driver.profession + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].Add + "\n");
                        stream.Write(array, 0, array.Length);
                        array = Encoding.Default.GetBytes(transports[i].status + "\n");
                        stream.Write(array, 0, array.Length);
                    }
                }
            }
            else
                MessageBox.Show("Неподдерживаемый тип файла");
        }

        public void LoadShapes(string filePath)
        {
            string h = filePath.Substring(filePath.LastIndexOf('.'), filePath.Length- filePath.LastIndexOf('.'));
            if (h == ".bin")
            {
                IFormatter formatter = new BinaryFormatter();
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    transports.Clear();
                    transports.AddRange((List<Automobile>)formatter.Deserialize(stream));
                }
            }
            else if (h == ".xml")
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Automobile>));
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    transports.Clear();
                    transports.AddRange((List<Automobile>)formatter.Deserialize(stream));
                }
            }
            else if (h == ".txt")
            {
                transports.Clear();
                string[] arStr = File.ReadAllLines(filePath, Encoding.GetEncoding("windows-1251"));
                for (int i = 1; i < arStr.Length; i += 11)
                {
                    string trtype = arStr[i];
                    if (trtype.Contains("."))
                    {
                        trtype = new string(trtype.Reverse().ToArray());
                        trtype = trtype.Substring(0, trtype.IndexOf("."));
                        trtype = new string(trtype.Reverse().ToArray());
                    }
                    trtype = "OOP3LAB.Form1+" + trtype;
                    Assembly asm = Assembly.GetEntryAssembly();
                    Type classType = asm.GetType(trtype);
                    var tr = (Automobile)Activator.CreateInstance(classType);
                    tr.Mark = arStr[i + 1];
                    tr.Model = arStr[i + 2];
                    tr.Color = arStr[i + 3];
                    tr.Driver = new DriverInfo()
                    {
                        firstName = arStr[i + 4],
                        secondName = arStr[i + 5],
                        age = arStr[i + 6],
                        profession = arStr[i + 7]
                    };

                    tr.Add = arStr[i + 8];
                    transports.Add(tr);
                    tr.status = arStr[i + 9];
                }
            }
            else
                MessageBox.Show("Неподдерживаемый тип файла");
        }
        private void BtnLoad_Click(object sender, EventArgs e)
        {

            OpenFileDialog FBD = new OpenFileDialog();
            FBD.Filter = "Files(*.TXT; *.XML; *.BIN)| *.TXT; *.XML; *.BIN; | All files(*.*) | *.*";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                LoadShapes(FBD.FileName);
                ShowDataGrid();
            }
        }
        public List<string> dllpath = new List<string>();
        private void BtnDLL_Click(object sender, EventArgs e)
        {
            OpenFileDialog FBD = new OpenFileDialog();
            FBD.Filter = "Dynamic Link Library(*.dll)|*.dll|All files(*.*|*.*)";
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                Assembly asm = Assembly.LoadFrom(FBD.FileName);
                dllpath.Add(FBD.FileName);
                Console.WriteLine(asm.FullName);
                Type[] types = asm.GetTypes();
                foreach (Type t in types)
                {
                    comboBox2.Items.Add(t.Name);
                }
            }
            comboBox2.Visible = true;
            comboBox2.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Assembly asm = Assembly.LoadFrom(dllpath[comboBox2.SelectedIndex]);
            string dllname = dllpath[comboBox2.SelectedIndex].Substring(dllpath[comboBox2.SelectedIndex].LastIndexOf("\\") + 1, dllpath[comboBox2.SelectedIndex].LastIndexOf(".") - dllpath[comboBox2.SelectedIndex].LastIndexOf("\\") - 1);
            Type t = asm.GetType(dllname + "." + comboBox2.SelectedItem.ToString(), true, true);
            object obj = Activator.CreateInstance(t);
            string sft = t.GetProperty("sourceFileType").GetValue(obj).ToString();
            string oft = t.GetProperty("outputFileType").GetValue(obj).ToString();
            OpenFileDialog FBD = new OpenFileDialog();
            string filter = "Files(*" + sft + "; *" + oft + ")| *" + sft + "; *" + oft + "; | All files(*.*) | *.*";
            FBD.Filter = filter;
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                string inputfile = FBD.FileName;
                if(inputfile.Substring(inputfile.LastIndexOf(".")) == sft)
                    filter = "Files(*" + oft + ")| *" + oft + "; | All files(*.*) | *.*";
                else if (inputfile.Substring(inputfile.LastIndexOf(".")) == oft)
                    filter = "Files(*" + sft + ")| *" + sft + "; | All files(*.*) | *.*";
                SaveFileDialog FBD2 = new SaveFileDialog();
                FBD2.Filter = filter;
                if (FBD2.ShowDialog() == DialogResult.OK)
                {
                    string outputfile = FBD2.FileName;
                    
                    if((sft == ".*" || (inputfile.Substring(inputfile.LastIndexOf(".")) == sft)) && (outputfile.Substring(outputfile.LastIndexOf(".")) == oft))
                    {
                        MethodInfo method = t.GetMethod("Transform");
                        method.Invoke(obj, new object[] { inputfile, outputfile });
                        MessageBox.Show("Transform");
                    }
                    else if(inputfile.Substring(inputfile.LastIndexOf(".")) == oft)
                    {
                        MethodInfo method = t.GetMethod("Retransform");
                        method.Invoke(obj, new object[] { inputfile, outputfile });
                        MessageBox.Show("Retransform");
                    }
                    else
                    {
                        MessageBox.Show("Неподдерживаемые типы файлов");
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                string statusinfo = new TechnicalInspectionFacade(new HeadOfTheComission(), new Electrician(), new Mechanic()).MakeTechnicalInspection();
                transports[dataGridView1.CurrentRow.Index].status = statusinfo;
                ShowDataGrid();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                transports[dataGridView1.CurrentRow.Index] = new ReservedAutomobile(transports[dataGridView1.CurrentRow.Index]).automobile;
                ShowDataGrid();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                transports[dataGridView1.CurrentRow.Index] = new SpecialPurposeAutomobile(transports[dataGridView1.CurrentRow.Index]).automobile;
                ShowDataGrid();
            }
        }
    }
}
