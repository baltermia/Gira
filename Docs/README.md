# Gira

Gira is a simple copy of Atlassians Jira. Jira is a issue-tracking webapp which is used for bug tracking and agile project management. Gira has many limitations and is by far not as good as the real Jira, but it's open-source at least. Only the GUI is implemented, there's no real backend. The UI was created with [ModernWPF](https://github.com/Kinnara/ModernWpf). Functionality is listed under [Functions](#Functions) below.

## Used Tools

- WPF
- C#
- ModernWPF library

## Functions

Gira has the following functions:

- Create different user accounts and login
- Manager:
  - Create new Tickets for other users
  - Edit tickets of other users
  - Move tickets from one user to another
  - Has all standard user functionality (listed below)
- Standard user:
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

## Diagrams

### Use-Case diagram

Click [here](https://github.com/speyck/Gira/blob/main/Docs/Use-Case/Use-Case%20diagram.png) to see the Use-Case diagram.

### Wireframes

Wireframes can be found in [here](https://github.com/speyck/Gira/blob/main/Docs/Wireframes).

### Personas

The personas are listed in [here](https://github.com/speyck/Gira/tree/main/Docs/Personas).

## Authors

* **Baltermia** - *Hard (well done) work* - [speyck](https://github.com/speyck)
* **Alessio** - *Second Hand / Mental support* - [antar](https://github.com/antar)
