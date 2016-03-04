#<u>DOWNLOAD: http://bit.ly/1oWcCJ1 </u>

# Hey mates!
Alright. So if you're seeing this for the first time, I bet you have no idea as to what it does - so here we go. 

This program will automatically generate a .cfg file in order to automatically, well, spam a large amount of text. 
It will take a input text document, and convert it to a .cfg file that you can then execute inside of TF2 and use inside a server of your choice.

# How To

Alright. So that's cool and all, but how do you use it? Quite easily, actually. 

1. Start up the program. Administrator rights might be needed, but it depends from machine to machine. (https://i.imgur.com/j6qrIcS.png)

2. Fill out the avaliable text boxes.

  - Start Keybind: The keybind you will use to start the script inside of TF2. (I recommend something you're not already using, or else that key's function will be overwritten)
  - Cancel Keybind: Like above, this is the keybind that you will use to stop the script. A word of warning though, I found that this only works half of the time, if not at all. 
  - Delay (MS): This is the amount of delay you want from "saying" each line in the script. This is capped at over than 500ms to prevent spam - but hey, the source files are above. Change it yourself.
  - .CFG Filename: This is the name of the file that the program creates. If I wanted to make a file called "Danger Shield Sucks", it will output to "DangerShieldSucks.cfg". 
  - Alias: This is hard to explain, if at all. This is only here for further customization, and it'll prolly be removed sometime soon. You can put anything you want into this.
  - Source File: This is the source file of the text you want to bind. To clarify: say I had a txt document with the lyrics of "How much I hate Danger Shields" (great song btw). I would select this using the "open" button, and the bind would "say" the lines from the song. 
  
3. Press Start! (<b>For the love of god, please make sure all of the text boxes are filled before you press this, or the program will crash.</b>)

Alright. So this really should help you understand what the hell this program does. 

# How to "install" the .cfg file
-This is pretty simple: After the program creates the .cfg file, you want to drag it into `Steam\SteamApps\common\Team Fortress 2\tf\cfg`
- After that, run the game and press the `~` key, located above the `Tab` button. Then, type in `exec WHATEVERTHEHECKYOUNAMEDYOURCFG`. If you did it right, it should automatically find the .cfg. Then, press enter. 
- Join the server of your choice (preferably one without Admins,) and press the Start Keybind you set above. It should work! 

# Text Box Input Types

- Start Keybind: String
- Cancel Keybind: String
- Delay (MS): Integer
- .CFG Filename: String
- Alias: String
- Source File: String

# "QUESTIONS"

<b>Why can't you just automatically place this into the TF2 folder? </b>
- Cause I don't like to mess around with moving files on other computers, bad things can happen if I or the program messes up. I also like to keep the user's privacy to the max. 

<b>Does this work for CSGO?</b>
- I really don't see why not. They both run in the same engine, so it should work.

<b>What's with all of these .dlls hanging about?</b>
- Those are so the window looks good. You NEED to have those in order to run the program. Sorry!

<b>CAN YOU MAKE ONE FOR BATTLEFIELD</b>
- No. 

<b>Any other questions can be sent to me on Reddit, at /u/Metherul. Cheers! </b>

# OH YEAH! TOTALLY FORGOT

A huge thanks to /u/theblindman and this thread (https://www.reddit.com/r/tf2/comments/40c889/i_made_a_tf2_bind_for_the_entire_bee_movie_script/) for the inspiration for this program. Thank you so much!

-------

# BIG NOTE!!!!!!!!

### It is not my fault if you get banned/muted/whatever from your server. You did that, not me. 

### ALSO: This is NOT A CHEAT! This will NOT give you a VACation, and it never will. This is simply making a .cfg that you will then execute IN GAME. 

#MIT OPEN SOURCE LICENSE - CAUSE IT'S COOL TO HAVE THIS

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
