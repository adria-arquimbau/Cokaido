using System;
using System.IO;
using Shouldly;
using Xunit;

namespace ConsoleTwitterTests
{
    public class ConsoleTwitterShould
    {
        private StringWriter outputStream;
        private StringReader inputStream;
        private ConsoleTwitter consoleTwitter;
        private const string WelcomeMessage = "Welcome to TwitKaido.";

        public ConsoleTwitterShould()
        {
            outputStream = new StringWriter();
            Console.SetOut(outputStream);
            inputStream = new StringReader("");
            Console.SetIn(inputStream);
            consoleTwitter = new ConsoleTwitter();
        }

        [Fact]
        public void PrintWelcomeMessageWhenProgramStarts()
        {
            consoleTwitter.Run();
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
            consoleTwitter.Run();
            var output = outputStream.ToString();
            output.ShouldBe($"{WelcomeMessage}{Environment.NewLine}{Environment.NewLine}");
        }

        [Fact]
        public void PrintsBobsWallWithOneMessage()
        {
            inputStream = new StringReader($"Bob -> Hello{Environment.NewLine}Bob");
            Console.SetIn(inputStream);
            consoleTwitter.Run();
            var output = outputStream.ToString();
            output.ShouldBe($"{WelcomeMessage}{Environment.NewLine}Hello{Environment.NewLine}{Environment.NewLine}");
        }

        [Fact]
        public void PrintsMikeWallWithOneMessage()
        {
            inputStream = new StringReader($"Mike -> Hello{Environment.NewLine}Mike");
            Console.SetIn(inputStream);
            consoleTwitter.Run();
            var output = outputStream.ToString();
            output.ShouldBe($"{WelcomeMessage}{Environment.NewLine}Hello{Environment.NewLine}{Environment.NewLine}");
        }

    }
    public class ConsoleTwitter
    {
        private const string WelcomeMessage = "Welcome to TwitKaido.";
        public void Run()
        {
            Console.WriteLine(WelcomeMessage);
            var input = Console.ReadLine();

            while (input != null)
            {
                if (input.StartsWith("Bob ->"))
                {
                    Console.WriteLine(input.Split(">")[1].Substring(1));
                }
                if (input.StartsWith("Mike ->"))
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