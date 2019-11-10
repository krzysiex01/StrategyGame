# StrategyGame


Simple Age of War and Mad Max - inspired game with AI learning based on neural network (AForge.Neuro). </br>
Language: C#

How to play: </br>
-5 types of units. Each with unique characteristics. </br>
-Upgrade them to be sure your vechicle destroy the opponent's. </br>
-Watch out! When fighting near your base it's being damaged! Be the first one to detroy the enemy's base. </br>

How to teach bot: </br>
-When playing, your moves are being recorded and written to "io.txt" in the game's folder. </br>
-Your moves always <b>append</b> so if you don't want bot to learn your stupid moves be careful. </br>
-Copy "io.txt" to location of NeuralNetwork.exe </br>
-Run NeuralNetwork.exe and keep pressing enter. Many numbers showing on the screen means everything is ok - wait for neural network to learn. </br>
-You are ready to fight the bot with some new (yours) skills! (StartegyGame.exe should read automatically from NeuralNetwork folder but it may have problems) </br>
