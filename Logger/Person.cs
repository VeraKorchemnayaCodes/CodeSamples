namespace Logger;

public abstract record class Person(FullName FullName) : BaseEntity
{
    protected FullName FullName { get; init; } = FullName;
}