namespace month_name;
public class MonthNameInCalendar
{
    /// <summary>
    /// Esta função retorna o nome do mês passado como parâmetro de entrada.
    /// </summary>
    /// <param month="mes"> Um número inteiro com o mês. </param>   
    /// <returns> Nome do mês</returns>
    public static string MonthName(int month)
    {
        var monthResponse = string.Empty;

        switch (month)
        {
            case 1:
                monthResponse = "Janeiro";
                break;
            case 2:
                monthResponse = "Fevereiro";
                break;
            case 3:
                monthResponse = "Março";
                break;
            case 4:
                monthResponse = "Abril";
                break;
            case 5:
                monthResponse = "Maio";
                break;
            case 6:
                monthResponse = "Junho";
                break;
            case 7:
                monthResponse = "Julho";
                break;
            case 8:
                monthResponse = "Agosto";
                break;
            case 9:
                monthResponse = "Setembro";
                break;
            case 10:
                monthResponse = "Outubro";
                break;
            case 11:
                monthResponse = "Novembro";
                break;
            case 12:
                monthResponse = "Dezembro";
                break;
            default:
                monthResponse = "inválido";
                break;
        }

        return monthResponse;
    }
}