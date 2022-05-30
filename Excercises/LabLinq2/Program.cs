using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabLinq2
{
    public class Program
    {
        #region student list
        private static List<Student> students = new List<Student> {
            new Student("Don", "CS", 2015, true),
            new Student("Dan", "CS", 2012, true),
            new Student("Dee", "CS", 2013, false),
            new Student("Bob", "CJ", 2013, false),
            new Student("Ben", "CJ", 2013, true),
            new Student("Jan", "FA", 2012, true),
            new Student("Jim", "FA", 2014, false),
            new Student("Rob", "EE", 2015, true),
            new Student("Ray", "EE", 2012, true)
         };
        #endregion

        #region Main
        static void Main(string[] args)
        {
            LinqChallenge2();
        }

        static void LinqChallenge2()
        { 
            Console.WriteLine("\nL I N Q   C H A L L E N G E 2:");

            Console.WriteLine("\n\n======= Group students by honor (no group name):");
            groupStudentsByHonorNoGroupName();

            Console.WriteLine("\n\n======= Group students by honor (with group name):");
            groupStudentsByHonorWithGroupName();

            Console.WriteLine("\n\n======= Group students by major:");
            groupStudentsByMajor();

            Console.WriteLine("\n\n======= Group students by first letter of major:");
            groupStudentsByFirstLetterOfMajor();

            Console.WriteLine("\n\n======= Group student names by year:");
            GroupStudentNamesByYear();

            Console.WriteLine("\n\n======= Group student names by year (ordered by year):");
            GroupStudentNamesByYearOrdered();

            Console.WriteLine("\n\n======= Number of students per year:");
            NumberOfStudentsPerYear();

            Console.WriteLine("\n\n======= List Numbered Students:");
            ListNumberedStudents();

            Console.WriteLine("\n\n. . . press enter . . .");
            Console.Read();
        }
        #endregion

        #region groupStudentsByHonor()
        private static void groupStudentsByHonorNoGroupName()
        {

        }

        private static void groupStudentsByHonorWithGroupName()
        {

        }
        #endregion

        #region groupStudentsByMajor()
        private static void groupStudentsByMajor()
        {
                
        }
        #endregion

        #region groupStudentsByFirstLetterOfMajor()
        private static void groupStudentsByFirstLetterOfMajor()
        {

        }
        #endregion

        #region GroupStudentNamesByYear
        private static void GroupStudentNamesByYear()
        {

        }
        #endregion

        #region GroupStudentNamesByYearOrdered
        private static void GroupStudentNamesByYearOrdered()
        {

        }
        #endregion

        #region NumberOfStudentsPerYear
        private static void NumberOfStudentsPerYear()
        {

        }
        #endregion

        #region ListNumberedStudents
        private static void ListNumberedStudents()
        {

        }
        #endregion
    }
}
