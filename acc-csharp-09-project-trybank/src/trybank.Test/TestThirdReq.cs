using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestThirdReq
{
    [Theory(DisplayName = "Deve devolver o saldo em uma conta logada")]
    [InlineData(50)]
    public void TestCheckBalanceSucess(int balance)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1, 2, 123);
        bank.Login(1, 2, 123);
        bank.Deposit(balance);

        bank.CheckBalance().Should().Be(balance);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(10)]
    public void TestCheckBalanceWithoutLogin(int balance)
    {        
        Trybank bank = new();
        
        Action action = () => bank.CheckBalance();
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve depositar um saldo em uma conta logada")]
    [InlineData(0)]
    public void TestDepositSucess(int value)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1, 2, 123);
        bank.Login(1, 2, 123);
        bank.Deposit(value);

        bank.CheckBalance().Should().Be(value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestDepositWithoutLogin(int value)
    {        
        Trybank bank = new();
        
        Action action = () => bank.Deposit(value);
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve sacar um valor em uma conta logada")]
    [InlineData(1000, 100)]
    public void TestWithdrawSucess(int balance, int value)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1, 2, 123);
        bank.Login(1, 2, 123);
        bank.Deposit(balance);
        bank.Withdraw(value);

        bank.CheckBalance().Should().Be(balance - value);
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário não logado")]
    [InlineData(0)]
    public void TestWithdrawWithoutLogin(int value)
    {        
        Trybank bank = new();
        
        Action action = () => bank.Withdraw(value);
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

    [Theory(DisplayName = "Deve lançar uma exceção de usuário caso não haja saldo suficiente")]
    [InlineData(100, 200)]
    public void TestWithdrawWithoutBalance(int balance, int value)
    {        
        Trybank bank = new();
        bank.RegisterAccount(1, 2, 123);
        bank.Login(1, 2, 123);
        bank.Deposit(balance);
        

        Action act = () => bank.Withdraw(value);
        act.Should().Throw<InvalidOperationException>().WithMessage("Saldo insuficiente");
    }
}