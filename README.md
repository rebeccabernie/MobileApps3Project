# Tappy Toaster
> Module: Mobile Applications Development 3  
> Lecturer: Damien Costello  
> Project: Create a UWP app with responsive UI across multiple devices.

[Project Spec PDF](https://learnonline.gmit.ie/pluginfile.php/187530/mod_resource/content/0/Mobile%20Applications%20Development%202%20-%20Project.pdf)  

### Overview
For this project, I decided to make an endless runner game using [Unity](https://unity3d.com/). The goal of the game is to avoid the rain clouds and beat your high score.

### Initial Ideas
There are countless endless runner games available online, with some of the most popular being [Temple Run](https://www.microsoft.com/en-us/store/p/temple-run/9wzdncrfj3w3?SilentAuth=1&wa=wsignin1.0), Facebook's [Endless Lake](https://play.google.com/store/apps/details?id=com.spilgames.EndlessLake&hl=en), and the infamous [Flappy Bird](http://flappybird.io/). Endless runner games are, in my opinion, so popular because they're simple and easy to play - and also because you'll always want to one-up your friends' scores.  
It seems like every possible idea has already been done (see [Flappy Jam](https://itch.io/jam/flappyjam) games) but I came up with the following list of ideas:  
1. Tip Tap Swim: An endless underwater scroller feautring a character (a manta ray or a turtle, still deciding) and some obstacles (seaweed, coral, other sea creatures). Scoring: either each obstacle passed adds 1 to your score, or score based on time without hitting an object.
2. Tappy Toaster: A nod to After Dark's popular [Flying Toasters](https://en.wikipedia.org/wiki/After_Dark_(software)#Flying_Toasters) screensaver from the 1990s. Similar gameplay - tap the toaster to make it fly higher or lower, dodging objects. Scoring based on either obstacles avoided or time without hitting something.  

In the end, I decided to go for Tappy Toaster as the theme seemed a bit more interesting / light hearted and hasn't been done before.

### User Guide
1. Download the game from the Microsoft App Store (submitted, still waiting on certification, will link when published).  
2. Open the game. If you've never played before, you'll be asked to enter a username - this can be anything you like, under 20 characters.  
3. Once you've set a username, you'll be brought back to the main menu. Click the start button to navigate to the game screen. The game itself won't start yet.  
4. When you're ready, start the game using the spacebar, left mouse button, or tap the screen. These controls can be used to give the toaster a boost.  
5. Use the boost to avoid clouds. The longer you last without hitting anything, the higher your score will be.   
4. If you hit a cloud, the game will reload automatically and any new high score will be saved. Space / tap / click to start the game again!  

**Scoring**  
The game is time based - for every second you last without hitting a cloud, you'll gain two points. I felt this was the best option

### Learning Curve  
**Unity**  
I had never worked with Unity before, but wanted to try developing a simple, fun game. I found Unity was very finicky at times and it took a while to get used to, but ultimately was enjoyable to play around with. There were many useful tutorials online, as well as many forums and good documentation. I enjoyed the experience overall and would definitely like to try developing more complex games with the software in the future.     

**Pixel Art**  
I designed all the sprites for this game, which required learning some basic pixel art skills. I used [Adobe Photoshop](http://www.adobe.com/ie/products/photoshop.html) to design and edit one sprite sheet containing all required sprites - I used similar software before but Photoshop took a lot of practise to get used to. In the end it proved very convenient overall and also from the point of view of importing into Unity. as it preserves transparency in an image. This made creation of individual sprites easy, as sprites were easily distinguished from the background in the Unity sprite editor.  

**Azure / Cloud Storage**  
I researched a selection of possible cloud storage services, such as Azure and Amazon Web Services and decided Azure would be easier to incorporate in a Universal Windows Platform app. Azure has a variety of different cloud storage functions, but found it very difficult to incorporate any of them in the app. I tested many tutorials and blog posts from both Microsoft and other sources, but ultimately could not get cloud storage working properly.  
There is a degree of data storage within the app in that the user's personal high score is saved, but no cloud storage to facilitate worldwide high scores as of yet.

<img align="center" src="https://user-images.githubusercontent.com/14957616/33949554-d5c67166-e021-11e7-9ac2-6ac5df1a00a2.png">



