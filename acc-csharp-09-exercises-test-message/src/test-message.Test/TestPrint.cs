using Xunit;
using FluentAssertions;
using System.IO;
using System;

namespace test_message.Test;

public class TestPrint
{
    [Theory]
    [InlineData("ola", "ola")]
    [InlineData("lara", "lara")]
    [InlineData("luisa", "luisa")]
    [InlineData("andre", "andre")]
    [InlineData("bob", "bob")]
    public void TestPrintMsgSucess(string Send, string Expected)
    {   
        /*
        throw new NotImplementedException();
        using (var NewOutput = new StringWriter())
        {
            Console.SetOut(NewOutput);

            Message.PrintMsg("");

            string result = NewOutput.ToString().Trim();

            result.Should();      
        }*/
        
        {
            var result = Message.PrintMsg(Send);
            result.Should().Be(Expected);
        }
    }
}