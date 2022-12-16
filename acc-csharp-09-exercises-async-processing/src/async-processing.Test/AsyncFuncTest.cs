using Xunit;
using FluentAssertions;
using System;
using async_processing;
using System.Threading.Tasks;
using System.Diagnostics;


namespace async_processing.Test;

[Collection("Sequential")]
public class AsyncFuncTest
{
    [Fact(DisplayName = "Verificar se a exceção do Tipo Execption com a mensagem \"Exception\" está sendo lançada de forma assíncrona")]    
    public async Task TestThrowSomeAsyncException()
    {
        var asyncFunc = new AsyncFunc();
        var act = async () => await asyncFunc.ThrowSomeAsyncException();
        await act.Should().ThrowAsync<Exception>("Exception");
    }
    

    [Theory(DisplayName = "DoubleTheValueInGenericEntry deve ser assincrono e retornar a resposta correta após o tempo decorrido")]
    [InlineData(10, 1000, 20)]
    [InlineData(20, 2000, 40)]
    [InlineData(5, 3000, 10)]
    [InlineData(7, 4000, 14)]
    [InlineData(3, 5000, 6)]
    public async Task TestDoubleTheValueInGenericEntry(int entry, int delay, int expectedValue)
    {
        var asyncFunc = new AsyncFunc();
        Stopwatch timer = new Stopwatch();
        timer.Start();
        var result = await Task.Run(() => asyncFunc.DoubleTheValueInGenericEntry(entry, delay));
        timer.Stop();
        var timerDelay = timer.ElapsedMilliseconds;

        result.Should().Be(expectedValue);
        timerDelay.Should().BeGreaterThanOrEqualTo(delay);
    }
 	
}