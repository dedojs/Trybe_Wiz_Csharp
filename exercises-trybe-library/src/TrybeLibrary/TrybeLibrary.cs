using LibraryTypes;

namespace TrybeLibrary;

public struct Book
{
    public BookTypes Type { get; set; }

	public Book(BookTypes type)
	{
		Type = type;
	}
}