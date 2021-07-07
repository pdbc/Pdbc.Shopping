# Web API

Exposing functionality for front-end applications or other back-end applications can be done by an API.  

## Common Functionalities

All API's must have some similar functionalities.  Think about
* lifeline checks (is the service up and running, are all the dependencies of my api reacheable, ..)
* Transactions support
* security
* returning the correct http status codes depending on the action
* versioning


## Life line check & Dependency check

Two request are created to call to the API to verify the health of the API.  A HealthController that is setup in the common api library can then accept these request to verify the status. 

> By putting the controller in the common api library all future API projects will have this methods exposed.

* The life line check simply goes throug the entire request pipeline and returns a valid response
* the dependency check will find all 'DependencyCheckTests' in the solution and call Verify() on it.  The response will then merge all the answers in the response and report back to the client. 

## Transaction Support

The request pipeline will initiate a transaction to ensure all actions within this request will atomically succeed or fail.

An Action