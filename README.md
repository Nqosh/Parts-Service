# How to Set up and Run the ASP.NET Core 
 - You need to have Visual Studio Installed or Visual Studio Code
 - You also need to install Docker Desktop to spin up the Postgres database
 - You also need to install PG Admin if you want to visually see the tables on Postgres
 - After you have installed the above tools, You need to clone the source code, you may use git bash or clone the zip file
 - Open the source code using Visual Studio or VS code
 - Uncomment the below line in the Program Class to allow migrations to run 
![image](https://github.com/user-attachments/assets/e7f24e53-f6a4-42b1-9b18-6db08ffcc374)
 - Navigate to the solution explorer of the code and you will find a docker-compose.yml file
 - Use the cd command to navigate to the directory where the docker-compose.yml file is located.
-  Run the command docker-compose up. This command reads the docker-compose.yml file, builds any necessary images, creates containers, and starts the services.
-  After executing docker-compose up, you can check the status of your containers using docker ps. This command lists all running containers. 
- To view the logs of your running containers, use docker-compose logs. To follow the logs in real-time, use docker-compose logs -f. 
- To stop the containers, use docker-compose down
- Go back to Visual Studio and run the Web API and a swagger solution should open like below:

  ![image](https://github.com/user-attachments/assets/7fde6477-5fc5-41e4-9a09-2f9cd1f1e3b8)

