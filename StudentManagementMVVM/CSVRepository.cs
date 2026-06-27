using CSVlibrary;
using StudentManagementMVVM.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementMVVM
{
    public class CSVRepository : IRepository
    {
        public string fileName = $@"C:\Users\user\Desktop\CsharpClass\StudentDataBase\Data.csv";
        public void CreateRecord(StudentsDAO studentsDAO)
        {
            CSVHelper.Write<StudentsDAO>(fileName, studentsDAO);
        }

        public void DeleteRecord(StudentsDAO studentsDAO)
        {
            List<StudentsDAO> students = ReadRecord();
            StudentsDAO removeData = students.FirstOrDefault(x => x.Id == studentsDAO.Id);
            students.Remove(removeData);
            File.Delete(fileName);
            CSVHelper.Write<StudentsDAO>(fileName, students);
        }

        public List<StudentsDAO> ReadRecord()
        {
            if (!File.Exists(fileName))
            {
                return null;
            }
            return CSVHelper.Read<StudentsDAO>(fileName);
        }

        public void UpdateRecord(StudentsDAO studentsDAO)
        {
            List<StudentsDAO> students = ReadRecord();
            StudentsDAO UpdateData = students.FirstOrDefault(x => x.Id == studentsDAO.Id);
            UpdateData.Class = studentsDAO.Class;
            UpdateData.Number = studentsDAO.Number;
            UpdateData.Name = studentsDAO.Name;
            UpdateData.Score = studentsDAO.Score;
            File.Delete(fileName);
            CSVHelper.Write<StudentsDAO>(fileName, students);
        }
    }
}
