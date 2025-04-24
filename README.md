# MPBasicsCSharp
The bare minimum to get a host and client working while separating the network related things from the rest of any project.

Load up project.
Make sure to run at least 2 instances under Debug>Customize Run Instances
Make one the host and connect with other instances.

This project uses a LobbyManager Node and a LobbyMemberNode to usher clients in and out of network. When fully connected and validated the LobbyEvent Node fires the MemberValidated Event which would be where gamelogic and a playermanager would take over to create the actual player representing stuff as it relates to the lobby member.

Reason to go about it this way is to be able to do a clear network connection handling and client validation separate to actual gamelogic. So a client that connects can be tested for correct version or other validation before they show up as a player instance anywhere.

Code is more or less commented up. Some might be missing or even inaccurate. Do let me know if you find issues.

The goal with sharing this is more to put a working example out there for anyone that want to know how can see at least one way it can be done.

Might work for Godot version earlier then 4.4 with no or minor changes.

Godot 4.4.1 verified as working

[![Watch the video](https://img.youtube.com/vi/mBRIXzM2GC0/0.jpg)](https://www.youtube.com/watch?v=mBRIXzM2GC0)
