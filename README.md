# IRENESLAB.github.io
IRENESLAB

--login web api
IRENESLAB.github.io/AuthWebAPI

--subscription web api allowing logged in user to subscribe to one to many books in catelog
IRENESLAB.github.io/WebAPI

--models and data helper classes
IRENESLAB.github.io/Entities


--sql databases
1. UserAccess
  Dependency : IRENESLAB.github.io/AuthWebAPI 
2. BookSubscriptions
  Dependency : IRENESLAB.github.io/WebAPI

--Additional UI created to add books
IRENESLAB.github.io/BookSubscriptions/BookSubscriptionUI
--additional web api using swagger to add books
IRENESLAB.github.io/BookSubscriptions/BookSubscriptions
  note: the user tables and references to user tables were what i initially used to create users but switched to Useraccess (AuthenticationContextModel) and JWT

