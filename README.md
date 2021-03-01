# wshop

## Backend project development and running:
1) Project architecture done using clean architecture
2) Implementation of task has been done following DDD best practice, event sourcing and CQRS pattern in C# .NET Core.
3) Rover commands are exposed as APIs which front end application can consume.
4) To run the backend, download projects from backend folder and run it.

## Frontend project development and running:
1) Frontend application is being done using VueJs, CSS, SCSS, Bootstrap & Axios.
2) Application is developed using bottomup approach building smaller components in vuejs.
3) Created small components like Tile, Grid, Rover, Landing Headup Display, Movement Heads Up Display.
4) All these components are used by main app component to deploy the rover and move the rover.
4) Front end will call backend api to find rover position and rover would be didplayed in the grid.
5) To run the application, download frontend/wshop-marsrover-vue project run `npm install` command and then run `npm run serve`. It will launch the application showing grid with two rovers initially.
## Test both frontend and backend application
1) First make sure both backend api and front end application are running.
2) To test the below input , do following:
        1 2 N|LMLMLMLMM
3) Enter values 1, 2, N in the textboxes labelled as x, y, orientation then click land. It will deploy rover.
4) After rover is deployed, enter LMLMLMLMM movement command inside movement text box.
5) After entering movement command, rover can be seen at new location inside grid.

## Further enhancement and optimizations:
1) Few configuration are hard-coded in front end, which shoud be moved to some configuration file.
2) Few features tested using some sample data for testing purpose, so cleanup is needed in front end.
3) To show react skills, same application has been attempted to develop in react but it's incomplete due to time constraint which can be completed afer putting few more hours.
4) For backend projects, domain model is exposed to controller which can be abstrcted using some dto. Exposing domain model to outside world is anti-pattern.
5) Controller code can be further cleanup into smaller tasks/commands with passing less no. of. parameters.
6) All hardcoded urls/ strings e.g event sourcing url etc. should be put inside configutaion file and
should be accessed across application using dependency injection.
