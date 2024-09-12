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
    }
}
