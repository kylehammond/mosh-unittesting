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
As you go down the pyramid widens, indicating HOW MUCh you should do that type of test BECAUSE OF COST TO DO TEST.  Unit tests are cheap so we should do a lot

This ratio depends on your project

UT are great for quickly testing logic on conditional/loop and complex logic


### The tooling

To write tests you can use a testing framework

NUnit - older but good
MSTest - built into VS
xUnit - gaining popularity

Each gives a library and test runner
- utlity library helps you write tests
- test runner runs the tests and gives you passing/failing

Focus on fundamentals, not tooling

ReSharper's test runner is very effective/productivity booster


### Source code
