using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializationDemo
{
    [Serializable]
    public class Employee
    {
        // this inform to CLR that class can be serialized-->allow class serialized
       
        public int ID { get; set; }
        public string Name { get; set; }    

        public double Salary { get; set; }
    }
}
