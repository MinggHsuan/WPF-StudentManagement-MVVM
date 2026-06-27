using StudentManagementMVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementMVVM
{
    public class ViewModelPresenter : ViewModelContract.IPresenter
    {
        public ViewModelContract.IView _view;
        public IRepository repository;

        public List<StudentsDTO> studentDTOs = new List<StudentsDTO>();
        public ViewModelPresenter(ViewModelContract.IView view)
        {
            _view = view;
            repository = new CSVRepository();
        }
        public void Add(StudentsDTO studentDTO)
        {
            repository.CreateRecord(new StudentsDAO(studentDTO.Id, studentDTO.Class, studentDTO.Number, studentDTO.Name, studentDTO.Score));
            studentDTOs.Add(studentDTO);
            _view.OnAdd(studentDTO);
        }

        public void GetData()
        {
            var students = repository.ReadRecord();
            if (students == null)
            {
                return;
            }
            foreach (var student in students)
            {
                studentDTOs.Add(new StudentsDTO(student.Id, student.Class, student.Number, student.Name, student.Score));
            }
            _view.OnGetData(studentDTOs);
        }

        public void Remove(StudentsDTO studentDTO)
        {
            var removeData = studentDTOs.FirstOrDefault(x => x.Id == studentDTO.Id);
            repository.DeleteRecord(new StudentsDAO(removeData.Id, removeData.Class, removeData.Number, removeData.Name, removeData.Score));
            studentDTOs.Remove(removeData);
            _view.OnRemove(removeData.Id);
        }

        public void Update(StudentsDTO studentDTO)
        {
            repository.UpdateRecord(new StudentsDAO(studentDTO.Id, studentDTO.Class, studentDTO.Number, studentDTO.Name, studentDTO.Score));
            var upDateData = studentDTOs.FirstOrDefault(x => x.Id == studentDTO.Id);
            upDateData.Class = studentDTO.Class;
            upDateData.Number = studentDTO.Number;
            upDateData.Name = studentDTO.Name;
            upDateData.Score = studentDTO.Score;
            _view.OnUpdate(studentDTO);
        }
    }
}
