using System;
//binary
using System.Runtime.Serialization.Formatters.Binary;
//XML
using System.Xml.Serialization;
//SOAP
using System.Runtime.Serialization.Formatters.Soap;
//JSON
using System.Text.Json;
//file
using System.IO;
using System.Windows.Forms;

namespace SerializationDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for binary write button
            try
            { 
                //step 1-- store data in the object
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(txtID.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                //step 2
                FileStream fs=new FileStream(@"D:\emp.dat", FileMode.Create, FileAccess.Write);
                //step 3
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //code fopr SOAP write button
            try
            {
                //step 1-- store data in the object
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(txtID.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                //step 2
                FileStream fs = new FileStream(@"D:\emp.Soap", FileMode.Create, FileAccess.Write);
                //step 3
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1- read data from file
                FileStream fs = new FileStream(@"D:\emp.dat", FileMode.Open, FileAccess.Read);
                //step 2- deserilized 
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Employee employee = new Employee();
                employee = (Employee)binaryFormatter.Deserialize(fs);
                //step3-display
                txtID.Text = employee.ID.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-- store data in the object
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(txtID.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                //step 2
                FileStream fs = new FileStream(@"D:\emp.Xml", FileMode.Create, FileAccess.Write);
                //step 3
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                xmlSerializer.Serialize(fs, employee);
                fs.Close();
                MessageBox.Show("Done");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1- read data from file
                FileStream fs = new FileStream(@"D:\emp.Xml", FileMode.Open, FileAccess.Read);
                //step 2- deserilized 
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
                Employee employee = new Employee();
                employee = (Employee)xmlSerializer.Deserialize(fs);
                //step3-display
                txtID.Text = employee.ID.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1- read data from file
                FileStream fs = new FileStream(@"D:\emp.Soap", FileMode.Open, FileAccess.Read);
                //step 2- deserilized 
                SoapFormatter sf = new SoapFormatter();
                Employee employee = new Employee();
                employee = (Employee)sf.Deserialize(fs);
                //step3-display
                txtID.Text = employee.ID.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1-- store data in the object
                Employee employee = new Employee();
                employee.ID = Convert.ToInt32(txtID.Text);
                employee.Name = txtName.Text;
                employee.Salary = Convert.ToDouble(txtSalary.Text);
                //step 2
                FileStream fs = new FileStream(@"D:\emp.json", FileMode.Create, FileAccess.Write);
                //step 3
                JsonSerializer.Serialize<Employee>(fs, employee);
                fs.Close();
                MessageBox.Show("Done");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {
                //step 1- read data from file
                FileStream fs = new FileStream(@"D:\emp.Json", FileMode.Open, FileAccess.Read);
                //step 2- deserilized 
               
                Employee employee = new Employee();
                employee = JsonSerializer.Deserialize<Employee>(fs);
                 //step3-display
                txtID.Text = employee.ID.ToString();
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
