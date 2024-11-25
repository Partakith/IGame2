# IGame2 - My Retro
Manual Game Collection Management Tool - A place for your collected games of all sorts! (Retro Collection Intended) 
[You can of course still add any EXE based game to the list and launch it all the same]

Trial 3 - Coming soon further improvements to theme and fixes on ill theme logo, removal of SVG.Net likely happening as not used anymore after Trial 2.
Config update to actually save settings config to file and additional settings to be added. This will also remove many other dll requirments leaving only the SharpDX.dll, SharpDX.Xinput.dll, SharpDX.Xinput.xml

Trial 3 Sample Image - https://imgur.com/7q8cqZv.png
Trial 3 Program Icon - https://imgur.com/KBAcNeC.png

Trial Release 2.9 - Seems I broke something in the controller support in this release will be fixed in next. Hotfix posted with controller working.
LB/RB - Scroll up/down. A or B - Select and Launch Selected Game. Left-Stick or D-PAD - Scroll through selection left-to-right.
Once game is selected controller support disables as to not interfere with gameplay. Clicking back into the application should reactivate it or pressing the Library button.
Controller must be plugged in before opening app, next trial it won't matter, if you plugged it in after, resizing the window will activate it as well without needing to close.

I am considering adding in a function that runs that allows a controller key-combo to alt-f4 close your game itself for game closing and opening via this app without the need for a mouse once you get setup.
This way if you open a game and want to quit, you can just using your controller and then be able to select another game. [the wiki has the discord join link let me know your ideas and thoughts!]

Almost forgot - the resize is trial and definitely needs to be updated....it works but not correctly 
when attempting to pull from the straight bottom it's wonky, so side-to-side or bottom right is best for now sorry.

Also I will clean up this readme at some point and make it all more clear and remove old data.

Simple Beta Trial 1 - I am not the best with getting things out and about to showcase. There is no site or discord yet.
Time taken to build beta - 3 hours in total including concept time... I would guess, it's rather simple.

Updated to Trial 2 -

Includes [Experimental Beta] Basic Xbox controller support allowing you to select games and start them via controller. Still needs to be polished.

Includes ability to right-click a game to edit it's GameEntry file which contains the ImageLocation/SortTitleName/GamefileLocation (as of now it just opens in your defaulted text editor)

Some appearance updates and changes.

Now using SharpDX.Input & Svg.Net to support the included svg and xbox controller use.

Trial 2 - does not yet save a config for settings but trial 3 will and more settings options will be added.

How to use IGame2 and its purpose? (Trial Beta, all is set to change/update)

Example image trial 2 [Game Images are 600x900 if you want to achieve similar appearance but not required to be this size]

https://imgur.com/rFtMgO8.png
Images shown in collection for example purposes only.

Example Image from trial 1
[img]https://i.imgur.com/d0TTKZh.png[/img]

It's quite simple gather up image posters and titles for your games (Not Provided via API sorry for broad support of titles vs API only)

Select to add a new game, it will prompt you via an OpenFileDialog to select the Poster Image first. 

Go ahead and select one for example I chose "Assassin's Creed" but PS3 cover.

It will Prompt you after for a name, (This will save a txt file in IGame2's current directory under Games as the name you choose will affect the sorting of the game)

Then it will show the game image in your Library, when you first press the game image it will have you select the game file. 

This is where you can select a game of any file type for example (.gba,.n64,.3ds,.exe,.etc) and so on.

(if you make a mistake you can open the .txt file in the Games Directory and edit it)

Good to go! Now it will appear in your list until deleted from the Games folder. Simply pressing it will attempt to start the selected file.
I recommend finding programs you can associate with the filetype extensions and set them as defaults to open the game if not an .exe.




