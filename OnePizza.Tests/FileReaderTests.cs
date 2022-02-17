namespace OnePizza.Tests
{
    using FluentAssertions;
    using OnePizzaNet5;
    using System;
    using System.IO;
    using System.Reflection;
    using Xunit;

    public class FileReaderTests
    {
        private const string example = "a_an_example.in.txt";
        private const string basic = "b_basic.in.txt";
        private const string coarse = "c_coarse.in.txt";
        private const string difficult = "d_difficult.in.txt";
        private const string elaborate = "e_elaborate.in.txt";
        
        [Theory]
        [InlineData(example)]
        [InlineData(basic)]
        [InlineData(coarse)]
        [InlineData(difficult)]
        [InlineData(elaborate)]
        public void GivenValidFile_WhenReading_ReturnClients(string file)
        {
            var directory = $"{Directory.GetParent(typeof(FileReaderTests).GetTypeInfo().Assembly.Location).FullName}\\Artifacts";
            var clients = FileReader.Get(Path.Combine(directory,file));
            using (var stream = File.OpenRead(Path.Combine(directory, file)))
            using (var fileReader = new StreamReader(stream))
            {
                clients.Count.Should().Be(int.Parse(fileReader.ReadLine()));
            }
        }
    }
}
