namespace Logger;

public record class Employee(FullName FullName, uint Salary) : Person(FullName)
{
    public uint Salary { get; set; } = Salary;
    // Implemented implicitly because we don't want to hide this member from the users of the class
    public override string Name => $"{FullName}, ${Salary}";
    public virtual bool Equals(Employee? other)
    {
        if (other is null) return false;
        else return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
