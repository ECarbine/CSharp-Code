using System;
using System.Collections.Generic;
using System.Linq;

namespace LabLinq1
{
    class Program
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
            Console.WriteLine("\nL I N Q   E X E R C I S E");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("\n\n1) Graduation years of FA students:");
            ListGraudationYearOfFaStudents();

            Console.WriteLine("\n\n2) Names and graduation years of CS students:");
            ListNamesAndGraudationYearOfCsStudents();

            Console.WriteLine("\n\n3) Names of CS students who graduate after 2012:");
            ListNamesOfCsStudentsGraduatingAfter2012();

            Console.WriteLine("\n\n4) All Graduation years without duplicates:");
            ListGraduationYearsWithoutDuplicates();

            Console.WriteLine("\n\n5) Graduation years withoug duplicates in descending order:");
            ListGraduationYearsWithoutDuplicatesDescending();

            Console.WriteLine("\n\n. . . press enter . . .");
            Console.Read();
        }
        #endregion

        // TODO 1:	Write a query that lists the graduation years of all fine art (FA) students 
        //          then run the program to test the results
        private static void ListGraudationYearOfFaStudents()
        {
            var majorYears =
                from s1 in students
                where s1.Major == "FA"
                select s1.Year;

            foreach(int x in majorYears)
            {
                Console.WriteLine(x);
            }
        }

        // TODO 2:	Write a query that lists the names and graduation years of all computer science (CS) students
        //          then run the program to test the results
        private static void ListNamesAndGraudationYearOfCsStudents()
        {
            var csInfo =
                from cs in students
                where cs.Major == "CS"
                select new { SName = cs.Name, gradYear = cs.Year };

            foreach(var x in csInfo)
            {
                Console.WriteLine(x.SName + ": " + x.gradYear);
            }
        }

        // TODO 3:	Write a query that lists the names of CS students that graduate after 2012 
        //          then run the program to test the results 
        private static void ListNamesOfCsStudentsGraduatingAfter2012()
        {
            var csGrads =
                from cs in students
                where cs.Major == "CS"
                where cs.Year > 2012
                select cs.Name;

            foreach(var x in csGrads)
            {
                Console.WriteLine(x);
            }
        }

        // TODO 4:	Write a query that lists all graduation years but no duplicates
        //          then run the program to test the results 
        private static void ListGraduationYearsWithoutDuplicates()
        {
            IEnumerable<int> noDups = (from s in students select s.Year).Distinct();

            foreach(var year in noDups)
            {
                Console.WriteLine(year);
            }

        }

        // TODO 5:	Write a query that lists all graduation years - but no duplicates - in descending order
        //          then run the program to test the results 
        private static void ListGraduationYearsWithoutDuplicatesDescending()
        {
            IEnumerable<int> noDups = (
                from s in students 
                select s.Year).Distinct().
                OrderByDescending(x => x);


            foreach (var year in noDups)
            {
                Console.WriteLine(year);
            }
        }
    }
}
