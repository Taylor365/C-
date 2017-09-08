# The Library System

## This library system allows a user to:

- Add students or lecturers
- Search for students or lecturers by name or ID
- List students or lecturers
- List Library Items by type: Book, Paper, DVD
- Borrow Library items
- Return Library items
- Validate if a user is in the system


&nbsp;

## Innovation Used:

- Using an Interface

  - The project uses an Interface to group all borrowable objects together (Book, Paper, DVD). This interface allows a user to borrow and return objects in the same way.

- Item classes (Book, Paper, DVD)

  - The project has different classes for different items all implementing the Borrowable Interface.

- Validation

  - Using validation in a lot of instances. For example, if the user does not enter a valid option on the main screen, they will receive a message. Also, if the user tries to enter the Library part of the system without a valid ID, they will not be allowed.

- Down Casting Borrowable Items as different item types

  - In order for me to treat each item in the Borrowables list the same without throwing any Invalid exceptions, I down cast to each class based on the type of object searched for. This allows the chance to refactor a lot of code and group methods together. Instead of having a borrowBook(), borrowPaper() and borrowDvd() methods, there is now only a borrowItem() method. Casting allows to explicitly search the Borrowable list for only that type of item and ignore the others.

- Return Items

  - The project keeps track of borrowed items and allows users to return items. The item is only returned if the user has the item and their ID matches that borrow record.

- Overloading Search

  - The search method is overloaded so a user can search using name or ID.
