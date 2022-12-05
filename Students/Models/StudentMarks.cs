using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Models
{
    public class StudentMarks
    {
        public int Std_Id { get; set; }
        public String Roll_No { get; set; }
        public String Name { get; set; }
        public int Tamil { get; set; }
        public int English { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int Social { get; set; }
        public int Total { get; set; }
        public int  Average { get; set; }
        public bool Is_Delete { get; set; }
        public System.DateTime create_Time_Stamp { get; set; }
        public System.DateTime Upadate_Time_Stamp { get; set; }

        }
    }
