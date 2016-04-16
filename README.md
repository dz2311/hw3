# W4172 3D UI and Augmented Reality hw3
This is the third assignment of the course W4172 3D UI and Augmented Reality

# Used
Unity, Vuforia, and C#

# Models
Downloaded from sketchup

# Image Targets
see "Targets.pdf"

＃Description:

The image “Tarmac” is used as the original image target.
＃1. Selection:
I use the touch screen to select objects. After clicking an object, its color will turn
into yellow. If you click another object, the object that was selected before will be
deselected. Also, you can use two fingers to click that object to deselect it.
＃2. Translation:
①In the original image Target: click the object first, then click the cube on the tool bar.
Then the object will do relative movement with the toolbar. If you translate the tool
bar steadily, the object will be translated steadily, too. And it can be translated to
any position. (In the video, it’s difficult for me to hold my phone and my tablet
together and manipulate the toolbar to do this at the same time, so I put the toolbar
on the table to translate it. Notice that if you rotate the toolbar, the object will be
rotated, too.)
②In the work space: you don’t need to click the cube on the toolbar, when you
select an object and it shows up in the work space, click the button ”translation”.
Then you can use the toolbar to manipulate the object. Notice that only after you
click the “end translation” button, the object in the original image target will change
its position.
(The cube on the toolbar doesn’t change its color when using rhis method.)
# 3. Scaling:
By moving the framemaker toward the camera or away from the camera:
You can rescale the object. Please make sure the distance of moving the framemaker
is enough and give some time for these objects to change.
# 4. Rotation:
There are two ways to rotate an object:
① The first way is to use the toolbar. I mentioned how to use the toolbar in the
previous paragraph. The object always rotates around the toolbar by using the
distance from the cube on the toolbar to the object as the rotate diameter. So, the
user can decide the toolbar’s orientation and the diameter. (you can move the
toolbar to anywhere you want , then click the cube on the toolbar or the
translation button to trigger the rotation movement ).
The advantage of this method is that it’s easy to use and it’s natural. (Like Play
Station 4’s remote controller). But it’s less efficient to make the object rotate around
themselves. So, I used another method the achieve the efficient self-rotation.
② FrameMaker 00 :
I use this framemaker to let object rotate around them selves. The object will rotate
when the target is moving toward the camera or away from the camera. The
rotation speed is in proportion to the distance of the framemaker’ s movement.
# 5. Coordinated translation and rotation through seamless transition to
another coordinate system
When using the toolbar, please move it to the area where the camera can observe
and do not cover it. Only when the cube on the toolbar appears, can the toolbar
work normally.
And when you let the object do the relative movement with the toolbar, you can see
that the object can be seamlessly transferred between the coordinate system
defined by the ground target and a second coordinate system (and then back again).
# 6.Workspace:
You can change the scale of the object in the work space without affecting the real
object in the original image target. (The button “ scale down” and “scale up”)
Besides, the framemaker 0 and framemarker 1 can be used in the work space to
change the object’s rotation and scale.

Delete and Create: you can press the button “create” a new object. The new object
will shows up in the origin target (sometimes out of the origin target. Because the
coordinates will changed a little according to the different position of the camera
and those image targets). And the button “delete” can be used to delete a selected
object.

And the toolbar also can be used in the work space to achieve translation and rotation.
I’ve mentioned how to use it in the previous paragraphs.
