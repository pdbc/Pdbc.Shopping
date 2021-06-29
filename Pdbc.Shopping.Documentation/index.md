# CIA 

This component is responsible for 
* authentication and authorization on sdworx applications
* identifying profiles and inviduals
* administration of profiles and IDP related data

# Documentation structure

The documention is structured into several main parts
* [General](general\intro.md) contains information about
  - the architecture of CIA
  - support related items (e.g., known issues, frequent questions)
  - limitations and restrictions  
  
* [Articles](articles\overview\intro.md) contains 
  - vocabulary of CIA 
  - small text documents explaining specific topic, e.g., 
      - integration with CIA
      - different types of profile and how do we match them
      - different types of application and authentication flows
      - when an invitation mail is sent
      - the provisioning flows 
      - what an Operational Employer Group is and how it is created
      - SSO setup
      - Security  

* [Cookbooks](cookbooks\intro.md) contains answers to a specific question an end-use might have, e.g.,
  - how to connect with CIA
  - questionnaires concerning a new provisioning system, application, file-uploader, ...
  - how to do the provisioning  

* [Internal](internal\intro.md) contains mainly information for internal use, e.g., 
  - setup a swagger application
  - scheduled tasks to guarantee the data quality
  - meta security concept

* [Administration Flows](flows\admin\intro.md) demonstrate the CIA admin specific actions.<br/>These contain screenshots to visualize the user's flow, e.g.,
  - setup data
  - profile actions (e.g., merge profiles, grant helpdesk rights)
  - operational employer group actions (e.g., merge oeg's)

* [Portal/MyAccount Flows](flows\portal\intro.md) demonstrate the CIA end user specific actions.<br/>These contain screenshots to
visualize the end user's flow, e.g.,
  - change profile data
  - change password
  - merge personal profiles
    
* [User Journey Flows](flows\userJourney\overview\intro.md) demonstrate the CIA end user specific actions during login.<br/>These contain screenshots to visualize the end user's flow during login, e.g.,
  - login
  - account recovery
  - invitation
  - registration
  - two-step authentication

* [Application scopes](scopes\overview\intro.md) contains documentation not specific to CIA, but more related to the various application scopes that are integrating with CIA, e.g., MyWorkAndMe

* [FAQ](flows\faq\overview\intro.md) contains answers to the most frequently asked question, e.g.,
  - how to accept an invitation
  - how to create an SD Worx account
  - how to setup two step authentication

* [URLs](api\intro.md) contains CIA related URLs for the different environments, e.g.,
  - swagger URLs
  - documentation URLs
  - login URLs
  
# Contacts

* Integration with the identitystore requires oAuth authentication.  This access can be requested from the middleware squad using Cherwell.
* Issues can be reported to the SPARC Internal squad on the following email address: <portals@sdworx.com>
* Feature request can be addressed to the product owner: Natacza Johnson

# Releases

We publish all of our releases after every CICD build on our [Azure Dev Ops Wiki](https://sdworx.visualstudio.com/SPARC%20Internal/_wiki/wikis/SPARC%20Internal.wiki?pagePath=%2FReleases%2Fcia%2Ffull).<br/>
Specific folders are created for each build/component, please subscribe (or follow) if you want to be notified when new releases are pushed out.

We do have a pre-release folder which specifies all the components that are ready to be released.  The next release, these user-stories will go to production.
