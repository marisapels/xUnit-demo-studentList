using System;
using System.IO;
using System.Linq;


namespace StudentList.Services
{
    public class StudentStorage
    {
        // Name of file containing list of students
        private const string StudentList = "students.txt";

        // Writes the given string of data to the file with the given file name.
        //This method also adds a timestamp to the end of the file. 
        public virtual void UpdateStudentList(string content)
        {
            var timestamp = String.Format("List last updated on {0}", DateTime.Now);

            // The 'using' construct does the heavy lifting of flushing a stream
            // and releasing system resources the stream was using.
            using (var fileStream = new FileStream(StudentList,FileMode.Open))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine(content);
                writer.WriteLine(timestamp);
            }
        }

        public virtual string LoadStudentList()
        {
            // The 'using' construct does the heavy lifting of flushing a stream
            // and releasing system resources the stream was using.
            using (var fileStream = new FileStream(StudentList,FileMode.Open))
            using (var reader = new StreamReader(fileStream))
            {

                // The format of our student list is that it is two lines.
                // The first line is a comma-separated list of student names. 
                // The second line is a timestamp. 
                // Let's just retrieve the first line, which is the student names. 
                return reader.ReadLine();
            }
        }
    }
}