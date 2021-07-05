# Testing

The success of every projects stands is dependent on different items.  The amount of bugs or the certainty that the software behaves as expected are one the bigger ones of coures.  To be confident in your software the availability of an automated test-suite is practicaly mandatory.  There are of-course various types of test you can/need to write

## Unit Tests

Unit test verifies the functionality in a small and controlled subset of the code.  You will never have any external dependencies when doing a unittest, this allows your tests to be ran fast & reliable.  You will test basic code statements and verify that external dependencies are called (your logical code flow).  You can do this by using a Mocking framework which allows you verify external calls that are made or by stubbing values to be returned from outer facing contract/services.

## Data & System Tests

I'd like to write data & system tests as well as they provide me with a simple means of testing some complex logic in an isolated environment.  Complex queries for instance are better tested in an isolated environment to verify its behavior.  External dependencies (other api calls, mailing integration, ...) deserve its own 'clean' test to verify its behavior as we expect it.  We are talking to that component in a certain way, checking that this way never changes is part of these tests.

> These tests could also be part of you complete integration-test suite, but this allows more complex setups (you need to setup the complete scenario instead of simply calling an external service/sql statement) and require larger knowledge to simulate different scenario's.

## Integration Tests

Integration tests takes the system a whole, setup the data and use the system as any other client would use it.  This is the most complete integration of all your components you can have.  

> CQRS vs API tests: in an ideal world you will write one test and you can verify the same test and scenario directly on your CQRS code and on your API layer (including serialization, authorization handing, ...)

You can opt for two cases of API tests, in-hosts tests where you will setup a webserver inside your (base) test class and connect with that one.  Or actually deploy the web-api and connect to the deployed application.  Both have advantages/disadvantages.  
* test-host: faster, but less reliable (other network components like web firewall, reverse proxy, ...)
* deployed: as it is in 'production', but requires a deployed version. Later in the release pipeline.

## Front-End Tests

The ultimate tests (but also the most brittle and error-prone) tests are the tests as the end-user experiences the application.  Usually this is in the form of a web-application or device application.  Automating these flows gives us the advantages that even the rendering of the screens, the availabilty of buttons & text boxes can be validated.  If these test work, it means the end-user can certainly do his job with the application.

> As an extra bonus, automating the front-end also allows us to keep our documentation up-to-date by taking screenshots during these tests.  Any change on the UI now immediately is reflected in the documentation's screenshots.






