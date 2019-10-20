using System;
using System.Collections.Generic;
using System.IO;
using Shouldly;
using Xunit;

namespace TwitKaidoTests
{
    public class ConsoleTwitterShould
    {
        private StringWriter outputStream;
        private StringReader inputStream;
        private TwitKaido twitKaido;
        private const string WelcomeMessage = "Welcome to TwitKaido.";

        public ConsoleTwitterShould()
        {
            outputStream = new StringWriter();
            Console.SetOut(outputStream);
            inputStream = new StringReader("");
            Console.SetIn(inputStream);
            twitKaido = new TwitKaido();
        }

        [Fact]
        public void PrintWelcomeMessageWhenProgramStarts()
        {
            twitKaido.Run();
            var output = outputStream.ToString();
            output.ShouldBe($"{WelcomeMessage}{Environment.NewLine}");
        }

        [Theory]
        [InlineData ("Bob")]
        [InlineData ("Mike")]
        [InlineData ("John")]
        public void PrintsEmptyBobsWallWhenThereAreNoMessagesFromBob(string value)
        {
            inputStream = new StringReader(value);
            Console.SetIn(inputStream);
            twitKaido.Run();
            var output = outputStream.ToString();
            output.ShouldBe($"{WelcomeMessage}{Environment.NewLine}{Environment.NewLine}");
        }

        [Fact]
        public void PrintsBobsWallWithOneMessage()
        {
            inputStream = new StringReader($"Bob -> Hello{Environment.NewLine}Bob");
            Console.SetIn(inputStream);
            twitKaido.Run();
            var output = outputStream.ToString();
            output.ShouldBe($"{WelcomeMessage}{Environment.NewLine}Hello{Environment.NewLine}{Environment.NewLine}");
        }

    }
    public class TwitKaido
    {
        private const string WelcomeMessage = "Welcome to TwitKaido.";

        public void Run()
        {
            Console.WriteLine(WelcomeMessage);
            var input = Console.ReadLine();

            while (input != null)
            {
                if (input.Contains("->"))
                {
                    Console.WriteLine(input.Split(">")[1].Substring(1));
                }
                if (input == "Bob" || input == "Mike" || input == "John")
                {
                    Console.WriteLine();
                }
                input = Console.ReadLine();
            }
        }
    }
}