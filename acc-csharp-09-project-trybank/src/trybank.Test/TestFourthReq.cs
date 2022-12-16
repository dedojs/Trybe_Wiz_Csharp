using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestFourthReq
{
    [Theory(DisplayName = "Deve transefir um valor com uma conta logada")]
    [InlineData(1000, 100)]
    public void TestTransferSucess(int balance, int value)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1, 2, 123);
        bank.RegisterAccount(4, 5, 456);
        bank.Login(1, 2, 123);
        bank.Deposit(balance);

        bank.Transfer(4, 5, value);
        bank.Bank[0, 3].Should().Be(balance - value);
        bank.Bank[1, 3].Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(10)]
    public void TestTransferWithoutLogin(int value)
    {        
        Trybank bank = new();
        
        Action action = () => bank.Transfer(1, 1, value);
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de saldo insuficiente")]
    [InlineData(50, 100)]
    public void TestTransferWithoutBalance(int balance, int value)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1, 2, 123);
        bank.RegisterAccount(4, 5, 456);
        bank.Login(1, 2, 123);
        bank.Deposit(balance);

        Action action = () => bank.Transfer(4, 5, value);
        action.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}
