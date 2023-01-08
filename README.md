# RotmgPCap
Captures [Realm of the Mad God](https://www.realmofthemadgod.com/) network traffic and offers binary analysis tools.

![Join our Discord](https://i.imgur.com/OyBrOV9.png)

# Tutorial
RotmgPCap works on windows only and requires you to install:
- [.NET Framework 4.7.2+](https://dotnet.microsoft.com/en-us/download/dotnet) Should come preinstalled w/ Windows 10 since April 2018 otherwise look for .NET desktop runtime.
- [WinPCap](https://www.winpcap.org/install/).

You might have to restart your machine before continuing.

When you're all set up you can launch the executable.
After the launch sequence is complete you will be greeted by the packet capture window.
Unless you're looking for something specific most of the options can be left on their default value.
Do make sure you select the correct network device from the dropdown list (your current wifi, lan or vpn device).
It goes without saying that the Start button starts the capturing process.
This might however not immediately result in packets appearing. 
If you have checked "Await sync." it will filter all packets as long as the process isn't synchronized.
This synchronization will happen once the client connects to a different world or server.

Once you have captured the packets you're looking for you can stop the process.
Try selecting one and clicking "Analyze" (or double click it) and it will open up the packet analyzer tool.
Here it will display the binary data and a tree view of all its parsed components.
Both of which can be interacted with to display the correlation between them.
In the packet capture window you can save, or load previous sessions, by clicking on the "Session" button.

In the 'Resources' directory there should be a file named proto.txt.
This file describes the data structures of the packets.
You may edit this if you like. A more in depth explanation can be found there.
It can also be accessed and refreshed from the Analyze window.

