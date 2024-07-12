using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating an Engineer instance
        Engineer prerana = new Engineer(101, 2022, "Java");
        Console.WriteLine($"Engineer ID: {prerana.EmployeeID}");
        Console.WriteLine($"Engineer Hire Year: {prerana.HireYear}");
        Console.WriteLine($"Engineer expertise Programming Language: {prerana.ProgrammingLanguage}");
        prerana.Work(); // method overrided from Employee
        prerana.SolveProblem(); // Engineer-specific method
        prerana.AttendMeeting(); // Method from interface
        prerana.ScheduleMeeting("At sharp 8PM IST");

        Console.WriteLine();

        // Creating a TeamLead instance
        TeamLead teamLead = new TeamLead(102, 2020, "cSharp");
        Console.WriteLine($"Team Lead ID: {teamLead.EmployeeID}");
        Console.WriteLine($"Team Lead Hire Year: {teamLead.HireYear}");
        Console.WriteLine($"Preferred Programming Language: {teamLead.ProgrammingLanguage}");
        teamLead.Work(); // Overridden method from Engineer
        teamLead.SolveProblem(); // Overridden method from Engineer
        teamLead.LeadTeam(); // TeamLead-specific method
        teamLead.AttendMeeting(); // Method from interface
        teamLead.ScheduleMeeting("At sharp 9PM IST");

        Console.WriteLine();

        // Accessing static field from TeamLead
        Console.WriteLine($"Total Team Leads: {TeamLead.TeamLeadCount}");
    }
}

