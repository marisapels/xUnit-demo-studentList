using System;

namespace StudentList.Services
{
    public class StudentManager
    {

        //ToDo : Need to get delimiter from constants
        private const char StudentEntryDelimiter = ',';
        private StudentStorage _studentStorage;
        private string _studentList;

        
    
        public StudentManager()
        {

            //Create new Student Storage object and student list
            _studentStorage = new StudentStorage();
            _studentList = _studentStorage.LoadStudentList();
        }
        

       //Alternative constructor, that uses moc object
       //Instead of real StudentStorage object
       public StudentManager(StudentStorage storage)
        {
            _studentStorage = storage;
            _studentList = _studentStorage.LoadStudentList();
        }

        public string[] Students
        {
            get
            {
                return _studentList.Split(StudentEntryDelimiter);
            }
        }

        public string PickRandomStudent()
        {
            var rnd = new Random();
            var rndIndex = rnd.Next(0,Students.Length);
            return Students[rndIndex];
        }
    }
}
