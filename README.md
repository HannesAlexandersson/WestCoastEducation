# TO MICHAEL GUSTAFSSON
21/10 you mentioned to the class that it was important that we dont do to much i these assignments. At this point in time I had ALREADY handed the assignment in. So basicly I could not go back and change anything. So I guess I'll have to explain myself here instead. 

I have gone "bananas" once more. But not because I want to impress or anything like that. I simply enjoy sitting and coding. And after each lesson I felt an urge to try to use the stuff we learned during those lessons and it felt natural to me to go to the only thing I had close at hand, which was this assignment. For example after the dependency injection lesson and factory pattern lessons I wanted to test myself and try them out, so I added them to the project. 

So to sum it up: You told us about the restriction to late, I had ALREADY gone bananas, and I had no way of taking it back when you told us about not going bananas.

# WestCoast Education

## The BIG DI & Factory  refactoring of 16/10
After the lesson 22 on 16/10 I decided to try refactor the app to try and use dependency injection and factorys.... This proved to be a little more then I could chew, and took my a pretty long time to get working. 
I learned alot of hard learned lessons and it wasnt as straightforward as I first thought. 

### Basic flow and usage if DI
So bascily this is what the flow is if I havent totally misunderstood this: 
We have registred App AND Menu in the ServiceCollectionExtension as a singleton and a transient. And then in Apps constructor we have a Menu, so whenver a App is created an instance of a Menu is also created. 
And in program.cs when we start the app, we also start up and build the services, and then we use DI to create the instance of App we use to run the application, and since Menu waas in Apps constructor we now also have used DI to create the menu!

But now I ran into my first problem, since the menu had all the managers in its constructor it ment all manages was always created whenver the app started. So I had to fix this. The solution was to create a serviceprovider!
So instead of menu having the managers in the constructor it has the ServiceProveider interface which basicly does one thing: it gets the service we want as long as we can provide it with a serviceType. 

So now the managers are no longer created whenever the app starts and instead menu can say whenever it NEEDS a manager to ask the serviceprovider to create the manager with DI!!!

### My steps to add DI
1. add the interface that sets the rule for what  methods the service should have
2. add the service that implement the interface.
3. register the service in the service collection extension list, which says whwnever someone want to use the interface, then give them the service.
4. now the service is ready to be used. And its the ApplicationData class that uses all the services because ApplicationData is the owner of all the lists, it only made sence that ApplicationData also loaded the lists into memory with the services.
5. Now whwnever anyone needs to use the lists it uses the shared object ApplicationData, for example all the managers have Applicationdata object in their constructors.


The biggest issue was how i could get DI to handle the shared lists. My goal and idea with the app was that I wanted only one list of for ex students, teachers courses etc.. So only ever create one list and pass that list around when needed.
but since I used managers and generic methods Di didnt knwo WHAT type of list to create. In teh end I needed to create a shared object data class to represent the different types of lisst. This came with a little caveat:
My original idea was to have a class named App that would be the literall owner of everything related to the appdata, but now this sharead object would be the owener of the lists. But this in mu opinion was a small price to pay for DI.

### How does the DI work?
The basic flow of the Di to my understanding using the courses as example: 
the class ApplicationData is a shared object that owns all the lists with the data. It doesnt know or care wher the lsits come from or how they are created. It is just an owner. Now ApplicationData is itself registered as a service in
the ServiceCollectionExtensions, as a singleton. It will be created when the app starts and live until the app dies. When DI first creates ApplicationData, it supplies the course service, which is waht loads the courses. 
Because ApplicationData is a singleton, subsequent consumers receive the same instance and therefore the same lists, exaclty as I originally had planned and still wanted.
Then, the manager (CourseManager) can then receive ApplicationData and ICourseFactory through constructor injection.



## What is this?
This is another assignment for ITHS .NET clouddevelopment, wher the students are supposed to create a prototype presentation app for a fictive company *WestCoast Education". 
The idea is basicly that this small console application can handle read and write to and from JSON as substutute for a real database. It can display the stored data back to the user. It can
accept new data to be stored. 

## How to use the app
To use the app first clone the repo.
Then run the program from a terminal like git bash or powershell or even zsh if you are on mac. 
Run the program:
```bash
dotnet run
```

## Instructions & Pseudo code

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


## What does what?

### Program
- program runs the app
- 
### App
- App loads the data and owns the application's shared lists.
- App handles the initiation of the menus
- App also initiates the services
- App insitate the managers

### Managers
- Managers perform operations on the lists, such as listing courses or adding a student etc

### Models
- Models represent data.

### Factorys
- Factories construct new model instances.

### Services
-Services retrieve or otherwise provide data to the application.

## Dependenceis
The app tries to make use of Dependency injections and tthis table gives an overview of the dependency relations
<b>Dependency</b>  <B>Used by</b>      <b>Reason</b>
IService<Course>	  App	                  Loads the initial course list.
ICourseFactory	    CourseManager	        Creates new Course instances.
List<Course>	      App and CourseManager	Both use the same shared list instance.
List<Teacher>	      App and CourseManager	The manager needs the existing teachers to let the user select course personnel.


the goal was to achive these three things:
- One shared list of courses, teachers, students, etc. Only ever one copy.
- Get DI to constructs the managers and menu.
- Managers operate on the same lists throughout the application.
