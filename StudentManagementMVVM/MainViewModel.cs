using StudentManagementMVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagementMVVM
{
    public class MainViewModel : ViewModelContract.IView
    {
        public string InputClass { get; set; }
        public string InputNumber { get; set; }
        public string InputName { get; set; }
        public string InputScore { get; set; }
        public ObservableCollection<Student> StudentList { get; set; } = new ObservableCollection<Student>();

        public ViewModelContract.IPresenter presenter;
        public ICommand Button_Click { get; set; }
        public ICommand RemoveData { get; set; }
        public ICommand EditData { get; set; }

        public MainViewModel()
        {
            presenter = new ViewModelPresenter(this);
            presenter.GetData();
            Button_Click = new RelayCommand(() => presenter.Add(new StudentsDTO(Guid.NewGuid().ToString(), InputClass, InputNumber, InputName, InputScore)));
            RemoveData = new GenericsRelayCommand<Student>((x) => presenter.Remove(new StudentsDTO(x.Id, x.Class, x.Number, x.Name, x.Score)));
            EditData = new GenericsRelayCommand<Student>((x) =>
            {
                if (x.IsClick == true)
                {
                    presenter.Update(new StudentsDTO(x.Id, x.Class, x.Number, x.Name, x.Score));
                }
                x.IsClick = !x.IsClick;
            });
        }
        public void OnAdd(StudentsDTO studentsDTO)
        {
            StudentList.Add(new Student(studentsDTO.Id, studentsDTO.Class, studentsDTO.Number, studentsDTO.Name, studentsDTO.Score));

        }

        public void OnRemove(string Id)
        {
            StudentList.Remove(StudentList.FirstOrDefault(x => x.Id == Id));
        }

        public void OnUpdate(StudentsDTO studentDTO)
        {
            var upDateData = StudentList.FirstOrDefault(x => x.Id == studentDTO.Id);
            upDateData.Class = studentDTO.Class;
            upDateData.Number = studentDTO.Number;
            upDateData.Name = studentDTO.Name;
            upDateData.Score = studentDTO.Score;
        }
        public void OnGetData(List<StudentsDTO> studentsDTOs)
        {
            foreach (var student in studentsDTOs)
            {
                StudentList.Add(new Student(student.Id, student.Class, student.Number, student.Name, student.Score));
            }
        }
    }
}
