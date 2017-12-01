using System;
using Xunit;
using StudentList.Services;
using Moq;

namespace StudentList.Tests
{
    public class StudentManager_Should
    {

        //Mock StudentStorage is used to imitate real StudentStorage, without using it
       Mock<StudentStorage> mockStorage;

       public StudentManager_Should()
       {

           //This is called for every test we run, so it will 
           //created (and reseted) for all tests that are run
           mockStorage = new Mock<StudentStorage>();

           //If somebody ever calls LoadStudentList method of mockStorage 
           //mock object- deffined output will be returned
           mockStorage.Setup(sm => sm.LoadStudentList())
                        .Returns("student1,student2,student3");

       }

        [Fact]
        public void ReturnListOfStudents()
        {
            //Arrange
            //object of mockStorage is used to use 'fake'-mock storage object
            var sut = new StudentManager(mockStorage.Object);
          
            //Act
            var actual = sut.Students;

            //Assert
            Assert.IsType(typeof(string[]), actual);

            //Because we use mockStorage we have full control of result set 
            //now we can use quite actual values in this text
            Assert.True(actual.Length == 3);
            Assert.Contains("student2",actual);
            
        }

        [Fact]
        public void ReturnCorrectCountOfStudents()
        {
             //Arrange
            //object of mockStorage is used to use 'fake'-mock storage object
            var sut = new StudentManager(mockStorage.Object);

            //Act
            var actual = sut.Students.Length;

            //Assert

            //Because we use mockStorage we have full control of result set 
            //now we can use quite actual values in this text
            Assert.Equal(actual, 3);
        }

        [Fact]
        public void ReturnRandomStudent()
        {
             //Arrange
            //object of mockStorage is used to use 'fake'-mock storage object
            var sut = new StudentManager(mockStorage.Object);
            var mocStudentList = mockStorage.Object.LoadStudentList();

            //Act
            var actual = sut.PickRandomStudent();

            //Assert
            Assert.Contains(actual,mocStudentList);
        }
    }
}
