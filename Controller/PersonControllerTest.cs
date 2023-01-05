namespace SuperHeroAPITests.Controller
{
    public class PersonControllerTest
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPowerRepository _powerRepository;
        private readonly IMapper _mapper;


        public PersonControllerTest()
        {
            _personRepository = A.Fake<IPersonRepository>();
            _powerRepository = A.Fake<IPowerRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PersonController_GetPeople_ReturnOk()
        {
            //Arrange
            var people = A.Fake<ICollection<PersonDto>>();
            var personList = A.Fake<List<PersonDto>>();
            A.CallTo(() => _mapper.Map<List<PersonDto>>(people))
                .Returns(personList);
            var controller = new PersonController(_personRepository, _powerRepository, _mapper);
            //Act
            var result = controller.GetPeople();
            //Assert 
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        
        [Theory]
        [InlineData(1)]
        public void PersonController_GetPerson_ReturnOk(int personId)
        {
            //Arrange
            var controller = new PersonController(_personRepository, _powerRepository, _mapper);
            var person = A.Fake<ICollection<PersonDto>>();
            //Act
            var result = controller.GetPerson(personId);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
