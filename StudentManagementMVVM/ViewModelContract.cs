using StudentManagementMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementMVVM
{
    public class ViewModelContract
    {
        public interface IView
        {
            void OnAdd(StudentsDTO studentDTO);
            void OnRemove(string Id);
            void OnUpdate(StudentsDTO studentDTO);
            void OnGetData(List<StudentsDTO> studentsDTOs);

        }
        public interface IPresenter
        {
            void Add(StudentsDTO studentDTO);
            void Remove(StudentsDTO studentDTO);
            void Update(StudentsDTO studentDTO);
            void GetData();
        }
    }
}
