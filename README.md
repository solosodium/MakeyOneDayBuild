# MakeyOneDayBuild
A Makey Makey Go game and input handling helper.

![tag](http://4.bp.blogspot.com/-qeERdGitlVE/Vn1FHNW0i_I/AAAAAAAAAUw/5mbj84VQvns/s1600/giphy.gif)

## Intro
This repo contains a complete game built with Unity3D and an [input handling helper script](Assets/Scripts/MakeyGoInput.cs) for Makey Makey Go with the following features:
* Delegate and event for input trigger callback
* Support input selection (mouse click / space / either)
* Identify and count repeated clicks

## Example
Attach the MakeyGoInput.cs to any object in your scene and set up the parameters for MakeyGoInput.cs in inspector.

![tag](http://4.bp.blogspot.com/-kqxSG2pqFwU/Vn1CQ705I0I/AAAAAAAAAUk/FI1mAKqBnnE/s1600/Screen%2BShot%2B2015-12-25%2Bat%2B9.17.13%2BPM.png)

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

## Blog
If you need more info, go [here](http://randomcodingstuff.blogspot.com/2015/12/makey-makey-go-one-day-build.html).

## Licence

The MIT License (MIT)

© 2016 Hao Fu

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
