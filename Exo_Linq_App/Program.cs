using Exo_Linq_Context;

class Program
{
    delegate void del();
    static void Main(string[] args)
    {
        Console.WriteLine("Exercice Linq");
        Console.WriteLine("*************");
        
        del executerMethode = () => displayFilteredStudentsSeventh();
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
}


