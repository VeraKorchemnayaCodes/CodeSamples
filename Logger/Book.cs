namespace Logger;

public record class Book(string Title, FullName Author, string ISBN) : BaseEntity
{
    public string Title { get; } = Title ?? throw new ArgumentNullException(nameof(Title));
    public string ISBN { get; } = ISBN ?? throw new ArgumentNullException(nameof(ISBN));
    public FullName Author { get; } = Author;


    // Implemented implicitly because we don't want to hide this member from the users of the class
    public override string Name { get => $"{Title} by {Author} ({ISBN})"; }

    public virtual bool Equals(Book? other)
    {
        if (other is null) return false;
        else return ISBN.Equals(other.ISBN);
    }

    public override int GetHashCode()
    {
        return ISBN.GetHashCode();
    }
}
