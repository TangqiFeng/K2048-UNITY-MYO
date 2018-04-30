# K2048-UNITY-MYO

2048 game with MYO developing using Unity writing in c#.

> author: [Tangqi Feng](https://tangqifeng.github.io/)

> Module: Gesture Based UI Development / 4th Year  
> Lecturer: Dr Damien Costello

This application is a local implementation of the application using gestures ([MYO](https://www.myo.com/)) to interact with it. User can use keyboard on PC, screen touch on mobile device and MYO armband to control this 2048 game.

##### Feature demo (working with myo)

[YouTube Link](https://youtu.be/y3od9nPmPWc)

![working with myo](https://github.com/TangqiFeng/K2048-UNITY-MYO/blob/img/myoshow2.gif)

##### Feature demo (game over)

![game over](https://github.com/TangqiFeng/K2048-UNITY-MYO/blob/img/gameover.gif)

##### Feature demo (you won)

![game over](https://github.com/TangqiFeng/K2048-UNITY-MYO/blob/img/youwon.gif)

### How to run

download/clone this repository, open with Unity, and run... ...

### Purpose of the application

2048 is a single-player sliding block puzzle game by Italian web developer Gabriele Cirulli. Also there are many versions on different platforms already. These games works with keyboards on PCs, with touch screen input on mobile devices. But no one  can control the game with gesture.

In this project, I am trying to develop a game (2048) using a gesture (MYO armband is picked). And developing my version 2048 game with [Unity](https://unity3d.com/cn/). (Unity is a cross-platform game engine that can be used to develop stand-alone games for Windows, MacOS, Linux, or iOS, Android mobile devices. Unity can also develop web games that support WebGL technology, or games on PlayStation, XBox, and Wii consoles.)

### Gestures identified as appropriate for this application

The Myo armband recognises 5 pre-set gestures out of the box. They are:

![myo pose](https://github.com/TangqiFeng/K2048-UNITY-MYO/blob/img/myo%20pose.jpg)

Playing the game 2048: Swipe up, down, left, and right to move the tiles across the board. (The tiles will slide towards the other end, as long as there’s available space.) When tiles of the same number touch during a move, they will combine into one tile carrying the sum of the two tiles. The objective is to reach get a 2048 tile on the board.

It is perfect to design as this:
* move up -> fingure spread
* move down -> fist
* move left -> wave left
* move right -> wave right
* restart game -> double tap

### Architecture for the solution

![class uml](https://github.com/TangqiFeng/K2048-UNITY-MYO/blob/img/k2048%20class%20uml%20Diagram.png)

* GameManager: control the game running and the animation
* Tile,TileStyle: bean classes for the tile object
* ScoreChecker: change high score if current score is higher
* InputManager, TouchInputManager: enable keyboard and touch screen input methods. (tap the title 'K2048' to restart)
* MyoInputManager: implements myo script package, simply using basic pre-set gestures: wave left, wave right, fist, double tap and fingers spread

### Conclusions

This project just simply implements myo's basic five poses. There are also many different ways can be used to control the game. For instance, it is worth to try controlling the game by rotating the myo armband. This [tutorial](http://developerblog.myo.com/myo-scripting-orientation-gestures-part-two/) shows how to get the rotate data.

Limitations with Unity and MYO: unity is a cross-platform game engine. Since different platforms require different extra myo packages to support myo inputs, it is hard to convert to another platform application. 
