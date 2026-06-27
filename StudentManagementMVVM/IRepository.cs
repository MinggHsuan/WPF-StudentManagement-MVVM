using StudentManagementMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace StudentManagementMVVM
{
    public interface IRepository
    {
        void CreateRecord(StudentsDAO studentsDAO);
        void DeleteRecord(StudentsDAO studentsDAO);
        void UpdateRecord(StudentsDAO studentsDAO);
        List<StudentsDAO> ReadRecord();
    }
}
