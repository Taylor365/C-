using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterisedDel
{
    class Student
    {
        public string FName { get; set; }
        public string LName { get; set; }

        // Add the following field for PART TWO
        public double AveragePoints { get; set; }

        public Student(string fname, string lname, double avgPoints)
        {
            FName = fname;
            LName = lname;
            AveragePoints = avgPoints;
        }

        public override string ToString()
        {
            return $"{FName} {LName}";
        }
    }

    class Program
    {
        delegate bool MatchingCriteria(string studentName);

        // Delegate for the question
        delegate bool GradeFilter(Student student);

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Joan", "Murray", 87.5),
                new Student("Val", "Jacobs", 54.5),
                new Student("Terry", "Dudley", 34.5),
                new Student("Mickey", "Mouse", 10.8),
                new Student("Marsha", "Brady", 74.2),
                new Student("Boris", "Blockhead", 7.5),
                new Student("Alex", "Sarsons", 90.3),
                new Student("Claude", "Simons", 49.4),
                new Student("Mark", "Lords", 54.6),
                new Student("Victor", "Meldrew", 41.93),
                new Student("Mata", "Hari", 97.7),
                new Student("Tobias", "Tonne", 77.3)
            };

            bool quit = false;
            do
            {
                Console.Write("Enter a letter to display students whose first name begins with that letter, while # in front " +
                                "of the letter means display students whose names end with that letter: ");
                string selection = Console.ReadLine();
                if(!string.IsNullOrEmpty(selection) && selection.Length <= 2)
                {
                    IEnumerable<Student> matchedStudents = null;

                    switch(selection.ToUpper())
                    {
                        case "M":
                            matchedStudents = GetStudentsWithFNameStartingWithM(students);
                            break;

                        case "V":
                            matchedStudents = GetStudentsWithFNameStartingWithV(students);
                            break;

                        case "#Y":
                            matchedStudents = GetStudentsWithFNameEndingWithY(students);
                            break;

                        case "#A":
                            //matchedStudents = GetStudentsWithFNameEndingWithA(students);
                            matchedStudents = GetStudentsThatMatchCriteria(students, StudentFNameEndsWithA);
                            break;

                        default:
                            quit = true;
                            break;
                    }

                    if(matchedStudents != null)
                    {
                        foreach (var student in matchedStudents)
                        {
                            Console.WriteLine(student);
                        }
                    }
                }
            } while (!quit);
            
            // Get the class to do something similar here for student average grades.  Grades are low (below 40),
            // pass (between 40 and 60 inclusive), merit (between 61 and 75 inclusive) and distinction (over 75).
        }

        static IEnumerable<Student> GetStudentsWithFNameStartingWithM(List<Student> students)
        {
            foreach (var student in students)
            {
                if(student.FName.StartsWith("M"))
                {
                    yield return student;
                }
            }
        }

        // Our customer tells us that they want to have students who also have fnames beginning with V. A naive
        // solution would be to add a function similiar to GetStudentsWithFNameStartingWithM
        static IEnumerable<Student> GetStudentsWithFNameStartingWithV(List<Student> students)
        {
            foreach (var student in students)
            {
                if (student.FName.StartsWith("V"))
                {
                    yield return student;
                }
            }
        }

        // So, we could have gotten around the first two cases by having the function GetStudentsWithFNameStartingWith_()
        // being paraterised with the desired letter.  But that wouldn't work if we swapped to names ending with a given
        // letter.  Essentially, we want a way to parameterise the match expression...
        static IEnumerable<Student> GetStudentsWithFNameEndingWithY(List<Student> students)
        {
            foreach (var student in students)
            {
                if (student.FName.ToUpper().EndsWith("Y"))
                {
                    yield return student;
                }
            }
        }

        static IEnumerable<Student> GetStudentsWithFNameEndingWithA(List<Student> students)
        {
            foreach (var student in students)
            {
                if (student.FName.ToUpper().EndsWith("A"))
                {
                    yield return student;
                }
            }
        }

        static bool StudentFNameEndsWithA(string studentFName)
        {
            bool doesEnd = false;

            if(studentFName.ToUpper().EndsWith("A"))
            {
                doesEnd = true;
            }

            return doesEnd;
        }

        static IEnumerable<Student> GetStudentsThatMatchCriteria(List<Student> students, MatchingCriteria criteria)
        {
            foreach (var student in students)
            {
                if(criteria(student.FName))
                {
                    yield return student;
                }
            }
        }

        static bool IsFirstClassStudent(Student student)
        {
            return student.AveragePoints >= 75;
        }

        static bool IsUpperSecondClassStudent(Student student)
        {
            return student.AveragePoints >= 65 && student.AveragePoints <= 74;
        }

        static IEnumerable<Student> GetGradedStudents(List<Student> students, GradeFilter filter)
        {
            foreach (var student in students)
            {
                if (filter(student))
                {
                    yield return student;
                }
            }
        }
    }
}
