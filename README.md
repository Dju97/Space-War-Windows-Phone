# Space-War-Windows-Phone

# Introduction

To see how the game works and the final result, watch the video ! 

This game was conceived in 2013 with XNA, a game engine writen in C#. The engine alternates permanently a phase Update, that modifies the variables of game elements and a phase Draw that draws elements. Every classes are structured with these methods. The game is divided in 2 screens : home screen and game screen. The class GameScreen hangles game logic.

# Architecture of items

Every game element inherit from the class Mere, that gives them basic methods to move, draw, and collide. There is further weapons and characters that are parents of other class more specifiq.
Classes ContentManager and ScreenManager allow to handle the loading of ressources and transitions bewteen screens.
