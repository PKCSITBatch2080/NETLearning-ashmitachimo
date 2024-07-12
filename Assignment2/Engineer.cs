//Multiple Inheritance
public class Engineer : Employee, IMeetingAttendee
{
    public string ProgrammingLanguage { get; set; }

    public Engineer(int employeeID, int hireYear, string programmingLanguage) : base(employeeID, hireYear)
    {
        ProgrammingLanguage = programmingLanguage;
    }
 // New method specific to Engineer, can be overridden
    public virtual void SolveProblem()
    {
        Console.WriteLine("Engineer is solving a problem.");
    }

    public override void Work()
    {
        Console.WriteLine("Engineer is coding.");
    }

    // Implementing interface method
    public void AttendMeeting()
    {
        Console.WriteLine("Engineer is attending a meeting.");
    }
     public void ScheduleMeeting(string meetingDetails)
    {
        Console.WriteLine($"Engineer is scheduling a meeting: {meetingDetails}");
    }
}