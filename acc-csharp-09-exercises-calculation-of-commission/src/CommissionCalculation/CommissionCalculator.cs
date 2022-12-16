using System;

namespace CommissionCalculation;
public class CommissionCalculator
{
    public const decimal CommissionPerCarSold = 250;
    public decimal FixedSalary { get; set; }
    public int AmountCarsSold { get; set; }
    public decimal TotalSalesValue { get; set; }
    public decimal FinalSalary { get; set; }

    public void CalculateFinalSalary(decimal fixedSalary, int amountCarsSold, decimal totalSalesValue) 
    {   
        AmountCarsSold = amountCarsSold;
        FixedSalary = fixedSalary;
        TotalSalesValue = totalSalesValue;
        FinalSalary = fixedSalary + (amountCarsSold * CommissionPerCarSold) + (totalSalesValue * 3 / 100 );
    }

    public void ShowFinalSalary(string contributorName, string month)
    {
        Console.WriteLine($"O colaborador {contributorName} neste mês de {month} obteve o salário final de R${FinalSalary.ToString("F2")} referente à:");
        Console.WriteLine($"SALARIO FIXO: R${FixedSalary.ToString("F2")}");
        Console.WriteLine($"TOTAL DE CARROS VENDIDOS: {AmountCarsSold}");
        Console.WriteLine($"VALOR TOTAL DE VENDAS NO MES: R${TotalSalesValue.ToString("F2")}");
        Console.WriteLine($"COMISSÃO POR CARROS VENDIDOS: R${(AmountCarsSold * CommissionPerCarSold).ToString("F2")}");
        Console.WriteLine($"COMISSÃO DE 3% DO TOTAL DE VENDAS: R${(TotalSalesValue * 3 / 100).ToString("F2")}");
    }
}
