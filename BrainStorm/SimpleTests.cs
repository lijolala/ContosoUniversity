using System;
using Xunit;
using UnitTestBrainStorm;
using NSubstitute;
using static UnitTestBrainStorm.Customer;
using GenFu;
using System.Collections.Generic;
using System.Linq;
using GenFu.ValueGenerators.Internet;

namespace BrainStormTest
{

   
    public class SimpleTests
    {
        ICalculator calculator = Substitute.For<ICalculator>();

        [Fact(DisplayName = "Passing Test case")]
        public void Test1()
        {
            // Arrange 
         
            UnitTestBrainStorm.Program test1 = new Program();
            int result;

            // Act
            result = test1.Add(5, 6);

            //Assert
            Assert.Equal(11, result);
        }

        [Fact(DisplayName = "Failing Test case")]
        public void Test2()
        {
            // Arrange 

            UnitTestBrainStorm.Program test1 = new Program();
            int result;

            // Act
            result = test1.Add(5, 6);

            //Assert
            Assert.NotEqual(12, result);
        }

        [Fact(DisplayName = "Testing for NSubstitute")]
        public void TestNSubstituteReturnSingle()
        {
            // Arrange 
         
          calculator.Add(3, 4).Returns(7);
            Assert.Equal(calculator.Add(3, 4), 7);
            Assert.NotEqual(calculator.Add(3, 4), 9);


        }

        [Fact(DisplayName = "Testing for NSubstitute - Property")]
        public void TestNSubstituteProperty()
        {

            calculator.Mode.Returns("DEC");
            Assert.Equal(calculator.Mode, "DEC");

            calculator.Mode = "HEX";
            Assert.NotEqual(calculator.Mode, "DEC");
        }

        [Fact(DisplayName = "Testing for NSubstitute - Different Args")]
        public void TestNSubstituteDiffArgs()
        {
            //Return when first arg is anything and second arg is 5:
            calculator.Add(Arg.Any<int>(), 5).Returns(10);
            Assert.Equal(10, calculator.Add(123, 5));
            Assert.Equal(10, calculator.Add(-9, 5));
            Assert.NotEqual(10, calculator.Add(-9, -9));

            //Return when first arg is 1 and second arg less than 0:
            calculator.Add(1, Arg.Is<int>(x => x < 0)).Returns(345);
            Assert.Equal(345, calculator.Add(1, -2));
            Assert.NotEqual(345, calculator.Add(1, 2));

            //Return when both args equal to 0:
            calculator.Add(Arg.Is(0), Arg.Is(0)).Returns(99);
            Assert.Equal(99, calculator.Add(0, 0));
        }

   
        [Fact(DisplayName = "Testing for NSubstitute -Multiple return values")]
        public void TestNSubstituteMultipleReturnValues()
        {
            calculator.Mode.Returns("DEC", "HEX", "BIN");
            Assert.Equal("DEC", calculator.Mode);
            Assert.Equal("HEX", calculator.Mode);
            Assert.Equal("BIN", calculator.Mode);

        }


        [Fact(DisplayName = "Testing for NSubstitute -return from callback")]
        public void TestNSubstituteReturnFromCallback()
        {
            calculator.Mode.Returns(x => "DEC", x => "HEX", x => { throw new Exception(); });
            Assert.Equal("DEC", calculator.Mode);
            Assert.Equal("HEX", calculator.Mode);
            Assert.Throws<Exception>(() => { var result = calculator.Mode; });

        }

        [Fact(DisplayName = "Testing for NSubstitute -Event - received")]
        public void TestNSubstituteForEvents()
        {
            //Arrange
            var command = Substitute.For<ICommand>();
            var something = new SomethingThatNeedsACommand(command);
            //Act
            something.DoSomething();
            //Assert
            command.Received().Execute();
            //command.DidNotReceive().Execute();

        }

        
        public class CustomerServiceTests
        {
            [Fact(DisplayName = " Will_Return_Customer_FullName")]
            public void Will_Return_Customer_FullName()
            {
                ICustomerRepository customerRepository = Substitute.For<ICustomerRepository>();
                customerRepository.GetCustomerById(1).Returns(new Customer() { FirstName = "John", LastName = "Smith" });

                CustomerService customerService = new CustomerService(customerRepository);

                string fullName = customerService.GetFullName(1);

                Assert.Equal("John Smith", fullName);
            }
        }

        [Fact(DisplayName = "Testing with moc data")]
        public void TestWithMocData()
        {

            var leaders = A.ListOf<Leader>(20);
            var meetings = A.ListOf<Meeting>(100);
            //Arrange
            A.Configure<UserGroup>()
                .Fill(x => x.Members).WithinRange(10, 250)
                .Fill(x => x.Name).AsMusicGenreName()
                .Fill(x => x.Description).AsMusicGenreDescription()
                .Fill(x => x.Founded).AsPastDate()
                .Fill(x => x.Leaders);

            var userGroup = A.New<UserGroup>();

            var usergroups = A.ListOf<UserGroup>(20);

            //Act


            //Assert



        }
     

    }
}
