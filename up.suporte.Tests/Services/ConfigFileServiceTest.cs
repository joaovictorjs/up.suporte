using up.suporte.Services;
using up.suporte.Stores;

namespace up.suporte.Tests.Services
{
    public class ConfigFileServiceTest
    {
        private class DecodeLineMock : ConfigFileService
        {
            public DecodeLineMock(ConfigFileStore store, string path = "up.suporte.ini") : base(store, path)
            {
            }

            public new (string? key, string? value) DecodeLine(string line)
            {
                return base.DecodeLine(line);
            }
        }

        [Theory]
        [InlineData("address=localhost", "address", "localhost")]
        [InlineData("Address=LocalHost", "address", "LocalHost")]
        [InlineData("address = localhost", "address", "localhost")]
        [InlineData("address = local host", "address", "local host")]
        [InlineData("address =      ", null, null)]
        [InlineData("address=", null, null)]
        [InlineData("=localhost", null, null)]
        [InlineData("", null, null)]
        [InlineData("address", null, null)]
        [InlineData(" ", null, null)]
        public void DecodeLineTest(string line, string? expKey, string? expValue)
        {
            ConfigFileStore store = new ConfigFileStore();
            DecodeLineMock mock = new DecodeLineMock(store);

            Assert.Equal((expKey, expValue), mock.DecodeLine(line));
        }

        public static IEnumerable<object[]> SendIsOkParameters()
        {
            yield return new object[] {
                new Dictionary<string, string>()
                {
                    {"address", "localhost" },
                    {"port", "5432" },
                    {"database", "base" },
                },
                true
            };

            yield return new object[] {
                new Dictionary<string, string>()
                {
                    {"address", "" },
                    {"port", "5432" },
                    {"database", "base" },
                },
                false
            };

            yield return new object[] {
                new Dictionary<string, string>()
                {
                    {"address", "   " },
                    {"port", "5432" },
                    {"database", "base" },
                },
                false
            };

            yield return new object[] {
                new Dictionary<string, string>()
                {
                    {"port", "5432" },
                    {"database", "base" },
                },
                false
            };

            yield return new object[] {
                new Dictionary<string, string>(),
                false
            };
        }


        [Theory]
        [MemberData(nameof(SendIsOkParameters))]
        public void IsOkTest(Dictionary<string, string> data, bool result)
        {
            ConfigFileStore store = new ConfigFileStore();
            store.CurrentConfig = data;
            IConfigFileService service = new ConfigFileService(store);
            Assert.Equal(result, service.IsOk());
        }

        [Fact]
        public void Read_Should_Create_ConfigFile_When_File_Not_Exists()
        {
            string path = "read.ini";
            Assert.False(File.Exists(path));

            ConfigFileStore store = new ConfigFileStore();
            IConfigFileService service = new ConfigFileService(store, path);
            service.Read();

            Assert.True(File.Exists(path));

            File.Delete(path);
        }

        [Fact]
        public void Write_Should_Create_ConfigFile_When_File_Not_Exists()
        {
            string path = "write.ini";
            Assert.False(File.Exists(path));

            ConfigFileStore store = new ConfigFileStore();
            IConfigFileService service = new ConfigFileService(store, path);
            service.Write();

            Assert.True(File.Exists(path));

            File.Delete(path);
        }
    }
}
