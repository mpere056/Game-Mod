#Read Features.txt to know what this mod can do
#This code includes only code that my friend and I wrote, not all the code needed for these classes to be fully functional

- Candies.cs
    - Code for candy that's shot out
    - On collision with a player, the player performs a random dance animation

- CandyBalls.cs
    - Code to make a pvp gamemode where coloured balls are shot at players
    - https://youtu.be/BltUulGohGg

- FengGameManagerMKII.cs
    - Acts as the main class that's used to run code from other classes
    - Also contains most of the RPC functions, which are used as multiplayer functions

- LoginSystem.cs
    - Communicates with a database by using webclient that contains usernames and password, and a list of friends for each user
    - Includes a basic user friends GUI to login, send friend requests, and see which friends are online

- MainGUI.cs
    - GUI to access settings such as changing the render distance, the time of day, etc
    - Also contains a music player

- PauseGUI.cs
    - GUI to insert links for skins and animated skins

- serverList2.cs
    - GUI for a new server list and server creation menu
