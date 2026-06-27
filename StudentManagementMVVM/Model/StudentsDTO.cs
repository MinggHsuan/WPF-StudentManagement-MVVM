using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementMVVM.Model
{
    public class StudentsDTO
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }

        public StudentsDTO(string guid, string Class, string number, string name, string score)
        {
            this.Id = guid;
            this.Class = Class;
            this.Number = number;
            this.Name = name;
            this.Score = score;
        }

    }
}
