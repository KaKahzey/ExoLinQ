using Exo_Linq_Context;

class Program
{
    delegate void del();
    static void Main(string[] args)
    {
        Console.WriteLine("Exercice Linq");
        Console.WriteLine("*************");
        
        del executerMethode = () => displaySectionsMembers();
        executerMethode();
    }
    #region Exercice 1
    static void displayStudents()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            name = s.First_Name + " " + s.Last_Name,
            birthdate = s.BirthDate,
            login = s.Login,
            yearResult = s.Year_Result
        });
        foreach(var s in QueryResult)
        {
            Console.WriteLine($"Name : {s.name}," +
                                $" birthdate : {s.birthdate}," +
                                $" login : {s.login} and last year result : {s.yearResult}");
        }
    }
    #endregion

    #region Exercice 2.1
    static void displayFilteredStudents()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            lastName = s.Last_Name,
            birthdate = s.BirthDate,
            yearResult = s.Year_Result,
            status = s.Year_Result >= 12? "OK" : "KO"
        }).Where(s => s.birthdate.Year <= 1955);

        foreach (var student in QueryResult)
        {
            Console.WriteLine($"Name : {student.lastName}," +
                                $" last year result : {student.yearResult}" +
                                $" and status : {student.status}");
        }
    }
    #endregion

    #region Exercice 2.2
    static void displayFilteredStudentsSecond()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            lastName = s.Last_Name,
            yearResult = s.Year_Result,
            birthdate = s.BirthDate,
            category = s.Year_Result < 10? "inferior" : s.Year_Result == 10 ? "normal" : "superior"
        }).Where(s => s.birthdate.Year >= 1955 && s.birthdate.Year < 1965);

        foreach (var student in QueryResult)
        {
            Console.WriteLine($"Name : {student.lastName}," +
                                $" last year result : {student.yearResult}" +
                                $" and category : {student.category}");
        }
    }
    #endregion

    #region Exerice 2.3
    static void displayFilteredStudentsThird()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            lastName = s.Last_Name,
            id = s.Section_ID
        }).Where(s => s.lastName.EndsWith("r"));

        foreach (var student in QueryResult)
        {
            Console.WriteLine($"Name : {student.lastName}," +
                                $" section id : {student.id}");
        }
    }
    #endregion

    #region Exercice 2.4
    static void displayFilteredStudentsFourth()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            lastName = s.Last_Name,
            yearResult = s.Year_Result
        }).Where(s => s.yearResult <= 3).OrderByDescending(s => s.yearResult);

        foreach (var student in QueryResult)
        {
            Console.WriteLine($"Name : {student.lastName}," +
                                $" last year result : {student.yearResult}");
        }
    }
    #endregion

    #region Exercice 2.5
    static void displayFilteredStudentsFifth()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            name = s.First_Name + " " + s.Last_Name,
            lastName = s.Last_Name,
            yearResult = s.Year_Result,
            section = s.Section_ID
        }).Where(s => s.section == 1110).OrderBy(s => s.lastName);

        foreach (var student in QueryResult)
        {
            Console.WriteLine($"Name : {student.name}," +
                                $" last year result : {student.yearResult}");
        }
    }
    #endregion

    #region Exercice 2.6
    static void displayFilteredStudentsSixth()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            name = s.Last_Name,
            yearResult = s.Year_Result,
            section = s.Section_ID
        }).Where(s => s.section == 1010 || s.section == 1020 && (s.yearResult < 12 || s.yearResult > 18)).OrderBy(s => s.section);

        foreach (var student in QueryResult)
        {
            Console.WriteLine($"Name : {student.name}," +
                                $" section : {student.section} and" +
                                $" last year result : {student.yearResult}");
        }
    }
    #endregion

    #region Exercice 2.7
    static void displayFilteredStudentsSeventh()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Select(s => new
        {
            name = s.Last_Name,
            yearResult = s.Year_Result * 5,
            section = s.Section_ID
        }).Where(s => s.section.ToString().StartsWith("13") && s.yearResult <= 60).OrderByDescending(s => s.yearResult);

        foreach (var student in QueryResult)
        {
            Console.WriteLine($"Name : {student.name}," +
                                $" section : {student.section} and" +
                                $" last year result : {student.yearResult}/100");
        }
    }
    #endregion

    #region Exercice 3.1
    static void displayAverageResult()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Average(s => s.Year_Result);

        Console.WriteLine($"Average result is : {QueryResult}");
    }
    #endregion

    #region Exercice 3.2
    static void displayMaxResult()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Max(s => s.Year_Result);

        Console.WriteLine($"Max result is : {QueryResult}");
    }
    #endregion

    #region Exercice 3.3
    static void displaySumResults()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Sum(s => s.Year_Result);

        Console.WriteLine($"Sum of results is : {QueryResult}");
    }
    #endregion

    #region Exercice 3.4
    static void displayMinResult()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Min(s => s.Year_Result);

        Console.WriteLine($"Minimum result is : {QueryResult}");
    }
    #endregion

    #region Exercice 3.5
    static void displayOddResults()
    {
        DataContext context = new DataContext();
        var QueryResult = context.Students.Count(s => s.Year_Result % 2 != 0);

        Console.WriteLine($"number of odd result is : {QueryResult}");
    }
    #endregion

    #region Exercice 4.1
    static void displayMaxResultPerSection()
    {
        DataContext context = new DataContext();
        var queryResult = context.Students
            .GroupBy(
            s => s.Section_ID
            )
            .Select(g => new
            {
                section = g.Key,
                maxResult = g.Max(s => s.Year_Result)
            }
            );

        foreach(var s in queryResult)
        {
            Console.WriteLine($" Best score in section {s.section} : {s.maxResult}.");
        }
    }
    #endregion

    #region Exercice 4.2
    static void displaySpecificSectionsAverageResult()
    {
        DataContext context = new DataContext();
        var queryResult = context.Students
            .GroupBy(
            s => s.Section_ID
            )
            .Select(g => new
            {
                section = g.Key,
                averageResult = g.Average(s => s.Year_Result)
            }
            )
            .Where(g => g.section.ToString().StartsWith("10"));

        foreach (var s in queryResult)
        {
            Console.WriteLine($" Average score in section {s.section} : {s.averageResult}.");
        }
    }
    #endregion

    #region Exercice 4.3
    static void displaySpecificAgeAverageResult()
    {
        DataContext context = new DataContext();
        var queryResult = context.Students
            .Where(s => s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985)
            .GroupBy(
            s => s.BirthDate.Month
            )
            .Select(s => new
            {
                birthdateMonth = s.Key,
                averageResult = s.Average(s => s.Year_Result)
            }
            )
            ;

        foreach (var s in queryResult)
        {
            Console.WriteLine($" Average score in month {s.birthdateMonth} : {s.averageResult}.");
        }
    }
    #endregion

    #region Exercice 4.4
    static void displaySectionWithMoreThanThreeAverageResult()
    {
        DataContext context = new DataContext();
        var queryResult = context.Students
            .GroupBy(
            s => s.Section_ID
            )
            .Where(g => g.Count() > 3)
            .Select(s => new
            {
                section = s.Key,
                averageResult = s.Average(s => s.Year_Result)
            }
            )
            ;

        foreach (var s in queryResult)
        {
            Console.WriteLine($" Average score in section {s.section} : {s.averageResult}.");
        }
    }
    #endregion

    #region Exercice 4.5
    static void displayCourseProfessorAndTheirSection()
    {
        DataContext context = new DataContext();
        var queryResult = context.Courses
            .Join(context.Professors,
            c => c.Professor_ID,
            p => p.Professor_ID,
            (c, p) => new
            {
                course = c.Course_Name,
                section = p.Section_ID,
                professor = p.Professor_Name
            }
            );

        foreach (var c in queryResult)
        {
            Console.WriteLine($"for the {c.course} course, its professor is {c.professor.ToUpper()} which is in section {c.section}");
        }
    }
    #endregion

    #region Exercice 4.6
    static void displaySectionsDetails()
    {
        DataContext context = new DataContext();
        var queryResult = context.Sections
            .Join(context.Students,
            section => section.Delegate_ID,
            student => student.Student_ID,
            (section, student) => new
            {
                sectionId = section.Section_ID,
                sectionName = section.Section_Name,
                delegateStudent = student.Last_Name
            }
            )
            .OrderByDescending(s => s.sectionId);

        foreach (var s in queryResult)
        {
            Console.WriteLine($"for section {s.sectionId} : {s.sectionName}, its delegate is {s.delegateStudent}");
        }
    }
    #endregion

    #region Exercice 4.7
    static void displaySectionsMembers()
    {
        DataContext context = new DataContext();
        var queryResult = context.Professors
            .Join(context.Sections,
            p => p.Section_ID,
            s => s.Section_ID,
            (p, s) => new
            {
                sectionId = s.Section_ID,
                sectionName = s.Section_Name,
                professorName = p.Professor_Name
            }
            )
            .GroupBy(s => new {s.sectionId, s.sectionName})
            .OrderByDescending(s => s.Key.sectionId);

        foreach (var s in queryResult)
        {
            Console.WriteLine($"{s.Key.sectionId} - {s.Key.sectionName} : ");
            foreach(var p in s)
            {
            Console.WriteLine($"{p.professorName}");
            }
        }
    }
    #endregion

    #region Exercice 4.8 TODO CAUSE THE FIRST ALREADY DOES IT
    static void displaySectionsWithAtLeastOneMember()
    {
        DataContext context = new DataContext();
        var queryResult = context.Professors
            .Join(context.Sections,
            p => p.Section_ID,
            s => s.Section_ID,
            (p, s) => new
            {
                sectionId = s.Section_ID,
                sectionName = s.Section_Name,
                professorName = p.Professor_Name
            }
            )
            .GroupBy(s => new { s.sectionId, s.sectionName })
            .OrderByDescending(s => s.Key);

        foreach (var s in queryResult)
        {
            Console.WriteLine($"{s.Key.sectionId} - {s.Key.sectionName} : ");
            foreach (var p in s)
            {
                Console.WriteLine($"{p.professorName}");
            }
        }
    }
    #endregion

    //#region Exercice 4.9
    //static void displaySpecificStudentsAndTheirGrades()
    //{
    //    DataContext context = new DataContext();
    //    var queryResult = context.Students
    //        .Join(context.Grades,
    //        s => s.Year_Result,
    //        g => g.Lower_Bound
    //        )

        
    //}
    //#endregion
}


