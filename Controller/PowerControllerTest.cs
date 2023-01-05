namespace SuperHeroAPITests.Controller
{
    public class PowerControllerTest
    {
        private readonly IPowerRepository _powerRepository;
        private readonly IMapper _mapper;


        public PowerControllerTest()
        {
            _powerRepository = A.Fake<IPowerRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PowerController_GetPower_ReturnOk()
        {
            //Arrange
            var powers = A.Fake<ICollection<PowerDto>>();
            var powerList = A.Fake<List<PowerDto>>();
            A.CallTo(() => _mapper.Map<List<PowerDto>>(powers))
                .Returns(powerList);
            var controller = new PowerController(_powerRepository, _mapper);
            //Act
            var result = controller.GetPowers();
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
