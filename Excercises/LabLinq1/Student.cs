using System;
namespace LabLinq1
{
    /// <summary>
    /// Defines a student based on the name, major, graduation
    /// year, and whether the student is a honor student or not.
    /// </summary>
    public class Student
    {
        public string Name { get; }
        public string Major { get; }
        public int Year { get; }
        public bool Honor { get; }

        /// <summary>
        /// Creates a Student object and initializes it with the
        /// arguments provided.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="major"></param>
        /// <param name="year"></param>
        /// <param name="honor"></param>
        public Student(string name, string major, int year, bool honor)
        {
            Name = name;
            Major = major;
            Year = year;
            Honor = honor;
        }

        public override string ToString()
        {
            return string.Format("{0}{1} ({2}) .. {3}", Honor ? "*" : " ", Name, Year, Major);
        }
    }

}
