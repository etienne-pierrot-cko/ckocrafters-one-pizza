namespace OnePizza.Tests
{
    using FluentAssertions;
    using OnePizzaNet5;
    using Xunit;

    public class FileReaderTests
    {
        private const string basePath = "C:\\Users\\Alex.Woodward\\source\\repos\\hashcode\\ckocrafters-one-pizza\\Artifacts\\";
        private const string example = "a_an_example.in.txt";
        private const string basic = "b_basic.in.txt";
        private const string coarse = "c_coarse.in.txt";
        private const string difficult = "d_difficult.in.txt";
        private const string elaborate = "e_elaborate.in.txt";
        
        [Fact]
        public void GivenValidFile_WhenReading_ReturnClients()
        {
            var clients = FileReader.Get(basePath + example);
            clients.Should().NotBeNullOrEmpty();
        }
    }
}
