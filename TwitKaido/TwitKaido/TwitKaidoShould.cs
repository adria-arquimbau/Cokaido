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
        private const string WelcomeMessage = "Welcome to console twitter.";
        private const string SomeThingToWrite = "You need to write something!";

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

        [Fact]
        public void PrintsEmptyBobsWallWhenThereAreNoMessagesFromBob()
        {
            inputStream = new StringReader("Bob");
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
        public void PrintsNeedWriteSomthingIfMessageIsNull()
        {
            inputStream = new StringReader("");
            Console.SetIn(inputStream);
            consoleTwitter.Run();
            var output = outputStream.ToString();
            output.ShouldBe($"{WelcomeMessage}{Environment.NewLine}{SomeThingToWrite}");
        }
    }

    public class ConsoleTwitter
    {
        private const string WelcomeMessage = "Welcome to console twitter.";
        private const string SomeThingToWrite = "You need to write something!";
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
                if (input == "Bob")
                {
                    Console.WriteLine();
                }
                if (input == "")
                {
                    Console.WriteLine(SomeThingToWrite);
                }
                input = Console.ReadLine();
            }
        }
    }
}