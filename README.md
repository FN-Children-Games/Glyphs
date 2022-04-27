# Glyphs

------------------------------------------------------------------------------------------------------------------------------------------------------
How to run:

Download repository from github.

in the repository navigate to Assets > Text Mesh Pro > Fonts > Unzip "oskidakelh1 SDF" into same folder.

Open Unity Hub > select Open Drop down > Add Project from Disk >  

Before opening file select Unity version 2021.3.0f1 (LTS)

Launch Project

------------------------------------------------------------------------------------------------------------------------------------------------------

Objective: Create an IOS, Android, PC compatible Game for Teaching children aboriginal Syllabics.

Home Screen:

- Home Screen with start button & Settings

- Start button will direct player to first (Scene)

![Capture2](https://user-images.githubusercontent.com/26759760/163282622-a0954e67-7235-49df-9971-c59be7a88854.JPG)


Gameplay: (Average Scene Layout)
- The Scene will contain of 24 Syllabic glyphs in a Grid layout group.
- 5 of the 24 glyphs will be the correct answer the Remainer will be incorrect.
- When the correct glyph is pressed it should be highlighted.
- when the correct glyph is pressed audio of the glyph will play the associated sound.
- Counter Tracking remaining correct glyphs correct.
- When All 5 are selected correctly and highlighted move to the next Syllabic glyph

![Capture](https://user-images.githubusercontent.com/26759760/163282654-deeff564-3a17-4505-bccc-696eaa116e3b.JPG)

TO DO:
- Add Mute Functionality to Setting > Mute
- Record Homescreen Background Audio
- Record Glyph Character Sound
- Scripts that need to be modified are located in the Assets > Scripts and are the following (ClickableLetter, DisplayLetter, GameController & RemainingCounterText)

COMPLETE:
- Create Homescene Background - Done
- Create Gamescene Background - Done
- Create Start Button - Done
- Create Return Button - Done
- Create Drop Down Menu, Settings Menu, Mute Button - Done
- Create Glyph/Syllabic Text Mesh Pro Font Asset - Done
- Add Unity Project To Github - Done

-Using Unified Canadian Aboriginal Syllabics UTF-8 create a font for Syllabic's 
  - Dakelh / Carrier (Dakelh Preferred)
  - Syllabic:
  (https://www.ydli.org/dakinfo/dulktop.htm) (https://www.unicode.org/charts/PDF/U1400.pdf)
	-CLC Standardization:
  http://www.ydli.org/dakinfo/clcexp.htm


Source Code for board and clickable letters borrowed from; 

https://game.courses/kidsgame/?ref=15&utm_source=youtube&utm_medium=description&utm_campaign=kidsgame

 Language Instruction from Dakelh Elder in British Columbia and abroad.
For the Children, who will preserve and revitalize the language.
