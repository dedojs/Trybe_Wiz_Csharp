using System.Globalization;
namespace calendar_events;

public class Event : IEvent
{
    public string? Title {get; set; }
    public DateTime EventDate {get; set; }
    public string? Description {get; set; }

    public static CultureInfo Culture = new CultureInfo("pt-BR");

    public Event(string title, string date, string description)
    {
        Title = title;
        var culture = new CultureInfo("pt-BR");
        EventDate = DateTime.Parse(date, Culture);
        Description = description;

    }

    public Event(string title, string date)
    {
        Title = title;
        EventDate = Convert.ToDateTime(date);  
    }

    public void DelayDate(int days)
    {
        EventDate = EventDate.AddDays(days);
    }

    public string PrintEvent(string format)
    {
        if (format == "normal")
        {
            return $"Evento = {Title}\nDate = {EventDate:d}\n";
        }
        if (format == "detailed")
        {
            return $"Evento = {Title}\nDate = {EventDate:d}\nDescription = {Description}";
        }
        throw new ArgumentException("The method or operation is not implemented.");
    }           
}
