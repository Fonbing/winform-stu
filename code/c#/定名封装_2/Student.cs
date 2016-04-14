using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Student
    {
        public Student(string className)
        {
            _stuClass = className;
        }
        public Student()
        {

        }
        private string _stuID;
        private string _stuName;
        private string _stuClass;

        public string stuID
        {
            set { _stuID = value; }
            get { return _stuID; }
        }
        public string stuName
        {
            set { _stuName = value; }
            get { return _stuName; }
        }
        public string stuClass
        {
            set { _stuClass = value; }
            get { return _stuClass; }
        }
    }
}
