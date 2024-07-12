
public class TeamLead : Engineer
{
    private static int teamLeadCount;

     public TeamLead(int employeeID, int hireYear, string programmingLanguage) : base(employeeID, hireYear, programmingLanguage)
    {
        teamLeadCount++;
    }

    public static int TeamLeadCount
    {
        get { return teamLeadCount; }
    }

    public void LeadTeam()
    {
        Console.WriteLine("Team Lead is leading the team.");
    }

    // Override Engineer's SolveProblem method
    public override void SolveProblem()
    {
        Console.WriteLine("Team Lead is solving a problem while leading the team.");
    }

    public override void Work()
    {
        Console.WriteLine("Team Lead is managing tasks and leading the team.");
    }
    public new void AttendMeeting()
    {
        Console.WriteLine("TeamLead is attending a meeting.");
    }
     public new void ScheduleMeeting(string meetingDetails)
    {
        Console.WriteLine($"Team Lead is scheduling a meeting: {meetingDetails}");
    }
}

