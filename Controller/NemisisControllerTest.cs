namespace SuperHeroAPITests.Controller
{
    public class NemisisControllerTest
    {
        private readonly INemisisRepository _nemisisRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public NemisisControllerTest()
        {
            _personRepository = A.Fake<IPersonRepository>();
            _nemisisRepository = A.Fake<INemisisRepository>();
            _mapper = A.Fake<IMapper>();
        }


        [Fact]
        public void NemisiController_GetNemeses_ReturnOk()
        {
            //Arrange
            var nemeses = A.Fake<ICollection<NemisisDto>>();
            var nemisisList = A.Fake<List<NemisisDto>>();
            A.CallTo(() => _mapper.Map<List<NemisisDto>>(nemeses))
                .Returns(nemisisList);
            var controller = new NemisisController(_nemisisRepository, _personRepository, _mapper);
            //Act
            var result = controller.GetNemeses();
            //Assert 
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
