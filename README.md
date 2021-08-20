# ToyRobot
This Project comprises of a simple game where you can place and move a robot inside a board by a few console commands. Since the user interaction is all through the command line, 
for checking the current position of the robot 'REPORT' command can be used.

The commands I have introduced in the code are below:
1. PLACE X,Y,Direction : This is for placing the robot at specific x and y position with direction parameter to make the robot face in a particular direction.
2. MOVE : This command moves the robot one step ahead in the direction it is pointing to.
3. LEFT : This command changes the direction of the robot by turning it left.
4. RIGHT : This command changes the direction of the robot by turning it right.
5. REPORT : This command is used to fetch the position of the robot along with the direction it is pointing to.

Conditions in the code:
1. The first operation needs to be a 'PLACE' command with all the three parameters.
2. The robot can also be moved anytime after initialisation using the place command. It is not mandatory to provide the direction while using it after initialisation.
3. Move command will not work in case the robot is standing on the boundary while facing towards the cliff.
4. It is not allowed to place the robot outside the bounds of the board.
