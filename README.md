# wshop

## Backend project development and running:
1) Project architecture using clean architecture
2) Implementation of task following DDD best practice, event sourcing and pattern in C# .NET Core.
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
Step 1: First make sure both backend api and front end application are running.
Step 2: To test the below input , do following:
        1 2 N|LMLMLMLMM
Step 3: Enter values 1, 2, N in the textboxes labelled as x, y, orientation then click land. It will deploy rover.
Step 4: After rover is deployed, enter LMLMLMLMM movement command inside movement text box.
Step 5: After entering movement command, rover can be seen at new location inside grid.