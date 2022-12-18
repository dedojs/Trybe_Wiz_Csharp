using System.Globalization;
namespace DataHandler;

public class Schedule : IScheduleFormat
{
    public DateTime[] nextEvents { get; set; }

    public Schedule()
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
        nextEvents = new DateTime[10];
    }

    public string NextEvent()
    {
        if(nextEvents[0] == new DateTime()) return "Não há eventos marcados";
        else                                return nextEvents[0].ToString("D");
    }

    public void AddEventAtDays(int days)
    {        
        for (int index = 0; index < nextEvents.Length-1; index++)
        {
            if(nextEvents[index] == new DateTime())
            {            
                nextEvents[index] = (DateTime.Now).AddDays(days);
                return;
            }   
        }
        throw new ArgumentException("Não há espaço disponível para o evento.");
    }

    public void RemoveFirstEvent()
    {
        nextEvents = nextEvents.Skip(1).ToArray(); // deleta

        //for (int i = 0; i < nextEvents.Length - 1; i++)
        //{
        //    nextEvents[i] = nextEvents[i + 1];
        //}
        //nextEvents[nextEvents.Length - 1] = new DateTime();
        //substitui;
    }

}
