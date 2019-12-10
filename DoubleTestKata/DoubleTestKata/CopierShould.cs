using System;
using System.Collections.Generic;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using Xunit;

namespace DoubleTestKata
{
    public class CopierShould
    {
        [Theory]
        [InlineData("A")]
        [InlineData("AA")]
        [InlineData("AAA")]
        [InlineData("AAAA")]
        public void CopyGivenValueIntoDestination(string expectedString)
        {
            var fakeSource = new FakeSource(expectedString + "\n");
            var spyDestination = new SpyDestination();
            var copier = new Copier(fakeSource, spyDestination);

            copier.Copy();
            Assert.Equal(expectedString, spyDestination.GetCopiedChars());
        }

        [Theory]
        [InlineData("B")]
        [InlineData("AB")]
        [InlineData("ABC")]
        [InlineData("ABCDYѺ")]
        public void CopyGivenValueIntoDestinationWithMocks(string expectedString)
        {
            var inputString = expectedString +'\n';
            var fakeSource = Substitute.For<ISource>();
            int counter = 0;
            fakeSource.GetChar().Returns(x =>
            {
                while (counter < inputString.Length)
                {
                    var characterReturn = inputString[counter];
                    counter++;
                    return characterReturn;
                }

                return '\n';
            });
            var spyDestination = Substitute.For<IDestination>();
            
            
            var copier = new Copier(fakeSource, spyDestination);

            copier.Copy();

            //spyDestination.Received().SetChar(expectedString[0]);

            Received.InOrder(() =>
            {
                foreach (var character in expectedString)
                {
                    spyDestination.SetChar(character);
                }
            });
        }
    }   
}
