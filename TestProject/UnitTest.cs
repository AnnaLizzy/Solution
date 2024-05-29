namespace TestProject
{
    public class Tests
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<AppDbContext> _appDbContextMock;
        private readonly Mock<AppDbContext2> _appDbContext2Mock;
        public Tests()
        {
            _configurationMock = new Mock<IConfiguration>();
            _appDbContextMock = new Mock<AppDbContext>();
            _appDbContext2Mock = new Mock<AppDbContext2>();
            _employeeService = new EmployeeService(_appDbContextMock.Object, _appDbContext2Mock.Object,_configurationMock.Object);
        }

        [Test]
        public async Task Authenticate_UserNotFound_ReturnsLoginError()
        {

            // Arrange
            var loginDto = new LoginDTO { UserName = "testUser", Password = "testPassword", RememberMe = false };           

            // Act
            var result = await _employeeService.Authenticate(loginDto);
            Assert.Multiple(() =>            {

                // Assert
                Assert.That(result.ResultObj, Is.EqualTo("Login Error"));
                Assert.That(result.Message, Is.EqualTo("User not found"));
            });
        }

        [Test]
        public async Task Authenticate_UserFound_ReturnsToken()
        {
            // Arrange
            var loginDto = new LoginDTO { UserName = "V0515311", Password = "123456", RememberMe = true };
            // Act
            var result = await _employeeService.Authenticate(loginDto);
            // Assert
            Assert.That(result.ResultObj, Is.Not.Null);
            Assert.That(result.Message, Is.EqualTo("Login successfully"));
        }
    }
}