OVERVIEW

This asset allows you to easily implement 2D vehicle in your game. It's extremely easy 
to setup and tune - just in several clicks you will implement it anywhere. It's really fast 
and performance safe - ideal for smartphones.

This asset works on all platforms supported by Unity3D.

Features:
- Mobile friendly
- Keyboard/Touch controls
- Implemented basic vehicle sound system
- Implemented physics (rigidbodies, colliders, joints)
- 2 type of vehicles included (tractor, monster truck)
- Easily create vehicles with different number or wheels
- Make no use of WheelCollider - you can use it on bumpy 2D terrain (slopes, hills) 
- no wheels sinking
- Support for Unity’s new 2D physics (WheelJoint 2D , Rigidbody2D, Circle Collider 2D etc.)
- Check for game over when vehicle is on the roof for specified amount of time



HOW TO USE THE ASSET

1. Import the package to the project.
2. Create two new layers: "CarBody" and "Wheels". Select "Body" object from the 
project manager and set the layer in the inspector to "CarBody". Objects 
"FrontWheel" and "RearWheel" should be on "Wheels" layer.
3. Go to "Edit->Project settings->Physics" and unselect "CarBody/Wheels" 
checkbox under "Layer Collision Matrix". "Solver Iteration Count" set to "30" 
to make vehicle physics computation more accurate.
4. Load Demo-01 scene.
5. “Main Camera” object: set "Projection" to "Orthographic".


FOR MORE INFO - PLEASE CHECK "2D_Vehicle_Kit_Manual.pdf"