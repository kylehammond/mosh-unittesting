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