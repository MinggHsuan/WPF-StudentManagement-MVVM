using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementMVVM.Model
{
    public class Student : ViewModelBase
    {
        public string Id { get; set; }
        public string Class { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Score { get; set; }
        public string EditContent => _isClick ? "儲存" : "編輯";
        private bool _isClick { get; set; }
        public bool IsClick
        {
            get { return _isClick; }
            set
            {
                _isClick = value;
                OnPropertyChanged(nameof(EditContent));
                OnPropertyChanged(nameof(Class));
                OnPropertyChanged(nameof(Number));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Score));
                OnPropertyChanged(nameof(IsClick));
            }
        }
        public Student(string guid, string Class, string number, string name, string score)
        {
            this.Id = guid;
            this.Class = Class;
            this.Number = number;
            this.Name = name;
            this.Score = score;
        }
        public Student(string guid, string Class, string number, string name, string score, bool isclick)
        {
            this.Id = guid;
            this.Class = Class;
            this.Number = number;
            this.Name = name;
            this.Score = score;
            this.IsClick = isclick;
        }
    }
}
