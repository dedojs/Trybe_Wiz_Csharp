using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFirstReq
{
    [Theory(DisplayName = "Deve cadastrar contas com sucesso!")]
    [InlineData(2, 3, 123)]
    public void TestRegisterAccountSucess(int number, int agency, int pass)
    {        
        Trybank bank = new();
        bank.RegisterAccount(number, agency, pass);
        bank.Bank[0,0].Should().Be(number);
        bank.Bank[0,1].Should().Be(agency); 
        bank.Bank[0,2].Should().Be(pass); 
    }

    [Theory(DisplayName = "Deve retornar ArgumentException ao cadastrar contas que já existem")]
    [InlineData(2, 3, 123)]
    public void TestRegisterAccountException(int number, int agency, int pass)
    {        
        Trybank bank = new();
        bank.RegisterAccount(number, agency, pass);
        Action action = () => bank.RegisterAccount(number, agency, pass);
        action.Should().Throw<ArgumentException>().WithMessage("A conta já está sendo usada!");
    }
}