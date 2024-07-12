class CalculateAge
{
    public void Age()
    {
        Console.WriteLine("Enter your Date of Birth as (YYYY/MM/DD):");
        DateTime DOB = DateTime.Parse(Console.ReadLine());
        DateTime today = DateTime.Today;

        TimeSpan age = today - DOB;
        int totalDays = Convert.ToInt32(age.TotalDays);
    

        int years = totalDays / 365;
        int months = (totalDays % 365) / 30;
        int weeks = (totalDays % 365 % 30) / 7;
        int days = totalDays % 365 % 30 % 7;

        Console.WriteLine($"Your DOB is {DOB.ToString("dddd, dd MMMM yyyy")}.");
        Console.WriteLine($"Age as of now: {years} years {months} months {weeks} weeks and {days} days old. \n");
    }
}
