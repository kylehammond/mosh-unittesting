## My notes while watching the videos

### What is automated testing
automated testing - the practice of writing code to test our code, and then run those tests in an automated fashion

code projects split into
- prod code
- test code

prevents you from needing to manually take steps and launch app when testing a feature (or features)

time to test increases exponentially as app grows in size

tests are repeatable

### Benefits
why should we write code to test code?
- test frequently in less time
- catch bugs before deploying
- allow refactoring with confidence
- allows you to focus more on the quality of code


### Types of tests
- unit tests
  - test a unit of app without external dependencies (such as files, db's, web services, credentials, dlls, etc)
  - cheap to write
  - execute fast

- integration tests
  - testing WITH external dependencies (such as files, db's, web services, credentials, dlls, etc)
  - take longer to run
  - give you more confidence in health of application
  - its a poor definition to think if you're testing more than one class then it's an integration test
    - these are fragile and coupled to implementation detail
    - these kinds of tests will break over time as implementation changes and you'll waste a lot of time wasting them
    - won't give you value

- end to end tests
  - drives an application through UI
  - there are tools made for this (like selenium)
  - give you greatest amount of confidence
  - very slow
  - very brittle

### Test pyramid

A guideline for testing could be a pyramid with E2E at the top, integration middle, unit bottom 

  End-to-End
 Integration
    Unit
    
As you go up, it gets more costly to do, but more confident - and vice versa  
As you go down the pyramid widens, indicating HOW MUCH you should do that type of test BECAUSE OF COST TO DO TEST.  Unit tests are cheap so we should do a lot

This ratio depends on your project

UT are great for quickly testing logic on conditional/loop and complex logic


### The tooling

To write tests you can use a testing framework

**NUnit** - older but good  
**MSTest** - built into VS  
**xUnit** - gaining popularity  

Each gives a library and test runner
- utlity library helps you write tests
- test runner runs the tests and gives you passing/failing

Focus on fundamentals, not tooling

This course will show MSTest but focus on NUnit

ReSharper's test runner is very effective/productivity booster


### Source code
Downloaded the starter source code and complete source code and added to repository.

### Reservation tests
Attributes TestClass and TestMethod belong to MSTest framework (using Microsoft.VisualStudio.TestTools.UnitTesting;)- testrunner runs at all classes decorated with TestClass then TestMethod and will run tests

Naming convention here is ClassnameTest

"CanBeCancelledBy_Scenario_ExpectedBehavior"

Want to test all scenarios/execution paths

Want to 

//Arrange - initialize objects

//Act - call a method/test a method

//Assert - verify that result matches expected behavior


Test Methods act as a type of documentation of the code

NUnit uses different terms

TestFixture (class)
Test (method)


# Test Driven Development
AKA Test First

Write tests before writing app/prod code

1. Write a failing test (b/c no code)
2. Write simplest code that makes test pass
3. Refactor if necessary

Benefits
1. Testable source code from get-go
2. Full coverage by tests
3. Simpler implementation

Not covered in this course

# Unit tests

Good unit tests are 
- First class citizens
- Sould be Clean, readable, maintanable
  - has single responsibility
  - ideally less than 10 lines of code
  - time consuming to debug if big (won't be touched)
- No logic
  - Introduces bugs (might make you waste time figuring out bug is code or test)
- Isolated
- Not too specific/General

# What to test and what not
Test the OUTCOME of a function
  - query functions
    - return a value
  - command functions
    - performs an action which probably changes state/db/etc
    - may also return value

DON'T test:
  - language features (ex: properties)
  - 3rd party code

# Naming
Projects
  ProjectName
  ProjectName.UnitTests

Test Classes
  ClassName
  ClassNameTest 
    One or more Test methods - usually >= exec. paths

Test Methods
  MethodName_Scenario_ExpectedBehavior
  If too big of a code method - maybe create it's own test class for method  (ClassName.MethodNameTests)

# Writing a simple unit test
Avoid arbitrary test values like 952 - people will ask - is this significant?

Don't create global Arangements - could have improper state from test to test - always be fresh

However -

NUnit can help 

Attributes:
//SetUp 
//TearDown - often used in integration tests

# Parameterized test methods
NUnit allows you to condense similar methods

# Ignoring test
[Ignore("Reason for disabling")]

# Unit Tests should be TRUSTWORTHY
How to write?
- TDD
- write tests that test the RIGHT THING

# Developers who don't write tests
There's people who think tests are a waste of time
There's people who think if you don't write tests (or even only do auto tests) you're doing it wrong

The reality is the truth is somewhere in the middle

It depends on the cost of the software bug for your org - however it's usually more expensive to catch down the chain (like prod)

Can be compared to Double entry accounting

# Specific vs general tests
See tests

            // Assert
            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));


            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique);

            //Assert.That(result, Is.Not.Empty);

            //Assert.That(result.Count(), Is.EqualTo(3));

            //Assert.That(result, Does.Contain(1));
            //Assert.That(result, Does.Contain(3));
            //Assert.That(result, Does.Contain(5));

# Void functions
Query functions - return a value
Command functions - change state, value of one or more properties, persist state

Void functions are COMMAND functions



# Methods that throw exceptions

Throws standard exception
* Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

Throws nonstandard exception
* Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>());


# Private methods
DON'T TEST PRIVATE METHODS

If you have a public method that calls a large chain of private methods - this might be a code smell

# Handling methods that raise events
You need to add a handler to your event handler and get back from it what it returns and make sure it's state has changed

# Code coverage tools for .NET
* Visual Studio Enterprise Edition
* ReSharper Ultimate (dotCover)
* NCover (fairly expensive)

# Real world testing
* If an old app, need to weigh if testing is worth the time taken to refactor 
* Cost of testing EVERYTHING may easily outweight benefits
* Startups may not have the time to test all code - but could write test for key parts (might save time on manually testing complicated calculations, etc)
* Only developer who writes clean and testable code - can't really implement unit testing.. swimming against the river.  Try to educate team and help them.


# External resources
Unit tests should not touch external resources, these are INTEGRATION TESTS

To test inputs we use Test Doubles/Fake Objects  (mock?)

# Loosley coupled / Fakes
Need to refactor existing code to be loosely coupled to make it more testable

1. Extract code using external resource into separate class (isolate from code)
2. Extract interface from this class
3. Modify class to talk to interface instead of concrete so you can pass in your fake object

Remove new operator from class - must pass in with interface (basic Dependency Injection)

He says Mocks and Stubs are both Fakes and that new frameworks don't differentiate.  So we don't need to call these things anything but "Fake_"

# Dependency Injection

Frameworks:
* NInject  < he recommends
* StructureMap
* Sprint.NET
* Autofac  < he recommends
* Unity

Container - big mapping of interfaces and implementations

if Implementations require dependencies, it gets those too, creating an 'object graph'

this is out of scope

don't get hung up on the tooling

# Mocking (isolation) Frameworks
Helps you create your fake/mock objects so you don't need to create them each by hand for each test.  

For example, the FakeFileReader.Read we made returns string.empty .. if we change that to be more realistic, our test will break

Frameworks:
* Moq < he recommends
* NSubstitute
* FakeItEasy
* Rhino Mocks

! Reserve mocks for only external dependencies !
- it causes a lot of fat setup code


# Interaction testing
Again, only for external resources

Need to verify class we're testing interacts with another class properly

Verify that the right method called with right arguments

Test the external behavior not the implementation

