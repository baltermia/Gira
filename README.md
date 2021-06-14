# Gira

Gira is a simple copy of Atlassians Jira. It has many limitations and is by far not as good as the real Jira, but it's open-source at least. Functionality is listed under [Functions](#Functions) below.

## Used Tools

- C#
- WPF
- MySql

## Functions

Gira has the following functions:

- Create different user accounts and login
- Manager:
  - Create new Tickets for other users
  - Edit tickets of other users
  - Move tickets from one user to another
  - Has all normal user functionality (listed below)
- Normal user:
  - Add own tickets
  - Edit own tickets
  - Add comments on any tickets
  - Add worklogs on own tickets
- Admin portal allows account changes

### Ticket Definition

A Gira-Ticket holds the following data:
- Title
- Description
- Due-Date
- Create-Date
- Last-Updated-Date
- Assignee
- Reporter (manager account)
- Comments
- Worklogs

## Authors

* **Baltermia** - *Hard (well done) work* - [speyck](https://github.com/speyck)
* **Alessio** - *Second Hand / Mental support* - [antar](https://github.com/antar)
