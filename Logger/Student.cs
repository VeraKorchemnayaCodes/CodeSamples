namespace Logger;

public record class Student(FullName FullName, Department? Department = null) : Person(FullName)
{ 
    // Implemented implicitely because we don't want to hide this member from the users of the class
    public override string Name => Department is null ? $"{FullName}" : $"{FullName}, {Department}";
    public virtual bool Equals(Student? other)
    {
        if (other is null) return false;
        else return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
