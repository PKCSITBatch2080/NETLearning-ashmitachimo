//Abstract Base class
public abstract class Employee
{
    //Fields
    private int employeeID;

    // Read-only
    private readonly int hireYear; 

    public Employee(int employeeID, int hireYear)
    {
        this.employeeID = employeeID;
        this.hireYear = hireYear;
    }
    //Property
    public int EmployeeID
    {
        get { return employeeID; }
        set { employeeID = value; }
    }

    public int HireYear
    {
        get { return hireYear; }
    }

    public abstract void Work(); // Abstract method
}
