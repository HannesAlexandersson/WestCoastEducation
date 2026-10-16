# WestCoast Education


## What is this?
This is another assignment for ITHS .NET clouddevelopment, wher the students are supposed to create a prototype presentation app for a fictive company *WestCoast Education". 
The idea is basicly that this small console application can handle read and write to and from JSON as substutute for a real database. It can display the stored data back to the user. It can
accept new data to be stored. 

The application uses Microsoft dependency injection to wire managers, JSON persistence, and entity factories. JSON files remain in the `Data` directory under the current working directory.

## How to use the app
To use the app first clone the repo.
Then run the program from a terminal like git bash or powershell or even zsh if you are on mac. 
Run the program:
```bash
dotnet run
```

### Instructions & Pseudo code

The app have several selections: 
1.  Add new course
2.  Add new teacher
3.  Add new Admin
4.  Add new handler
5.  Add new student
6.  List all course
7.  List all students

The selection "List all Students" leads to a submenu with more selections
1. Show students names and id
2. show students adress
3. show students phone
4. show students email

