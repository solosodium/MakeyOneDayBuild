# MakeyOneDayBuild
A Makey Makey Go game and input handling helper

## Intro
This repo contains a complete game built with Unity3D and an [input handling helper script] (Assets/Scripts/MakeyGoInput.cs) for Makey Makey Go with the following features:
* Delegate and event for input trigger callback
* Support input selection (mouse click / space / either)
* Identify and count repeated clicks

## Example
Attach the MakeyGoInput.cs to any object in your scene and set up the parameters for MakeyGoInput.cs in inspector

![alt tag](http://4.bp.blogspot.com/-kqxSG2pqFwU/Vn1CQ705I0I/AAAAAAAAAUk/FI1mAKqBnnE/s1600/Screen%2BShot%2B2015-12-25%2Bat%2B9.17.13%2BPM.png)

```csharp
// add this in your behavior script

// register your callback function
void Start() {
    MakeyGoInput.onClicks += MyHandler;
}

// define your callback function
void MyHandler (int clicks) {
    // clicks is the number of clicks detected
}
```

## A blog
If you need more info, go [here] (http://randomcodingstuff.blogspot.com/2015/12/makey-makey-go-one-day-build.html)
