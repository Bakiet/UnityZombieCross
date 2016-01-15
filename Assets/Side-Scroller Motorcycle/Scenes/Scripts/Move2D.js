#pragma strict

// 2D Vehicle Kit 1.0
// © Marcjan Biegaj - https://twitter.com/entertrack


public var Car : GameObject;
//Car = GameObject.Find("Car"); 

public var CarBody : GameObject;
CarBody = GameObject.Find("Body2D"); 

public var CenterOfMass : GameObject;
CenterOfMass = GameObject.Find("CoM2D");

public var Smoke : GameObject;
Smoke = GameObject.Find("Smoke");

public var Ensemble : GameObject;
Ensemble = GameObject.Find("Ensemble2D");
 
//Vehicle properties
public var UserControlled : boolean = true;
public var MaxSpeed = 50;
public static var CurrentSpeed : int;
public var CurrentSpeedInKmph : int;
public var Acceleration = 15.0;
private var Velocity = 0.0;
private var SmokeEmmiter : ParticleAnimator;
private var CurrentVelocity : float;
public static var CarMoveLeft : boolean;
public static var CarMoveRight : boolean;
public static var CarHandbrake : boolean;
public static var CarFlip : boolean;
public static var Reset : boolean;
public var Wheels : GameObject[];
public var WheelRadius : float[];
public var WheelTorqueAmount : float[];

public static var axisH: float = 0;
public static var axisV: float = 0;

function Awake()
{
	SmokeEmmiter = Smoke.GetComponent(ParticleAnimator);
	WheelRadius = new float[Wheels.length];
}

function Start()
{
	CarMoveLeft = false;
	CarMoveRight = false;
	CarHandbrake = false;
	CarFlip = false;
	Reset = false;
	
	axisH = 0;

	//Center of mass
	CarBody.GetComponent.<Rigidbody2D>().centerOfMass = CenterOfMass.transform.localPosition;
	
	
	//Get radius for each wheel
	for(var i = 0; i <= (Wheels.length-1); i++)
	{
		WheelRadius[i] = Wheels[i].GetComponent(CircleCollider2D).radius;
	}
	
	CalculateVelocity();
}

function FixedUpdate ()
{      
        CalculateVelocity();
        GetUserInput();
        GetCurrentspeed();
        
        if(UserControlled == true)
        {
        	for(var i = 0; i <= (Wheels.length-1); i++)
			{
				Wheels[i].GetComponent.<Rigidbody2D>().AddTorque(-0.2f * (Velocity / WheelRadius[i]) * 10);
			}
        }
}

function Update()
{
 	transform.Translate(Input.acceleration.x, 0, -Input.acceleration.y);
	SmokeEmmiter.force.y = Velocity * 20;
}

//Simulate key press for touch steering
function InputGetAxis(axis: String): float 
{

    var v = Input.GetAxis(axis);
    if (Mathf.Abs(v) > 0.005) return v;
    if (axis=="Horizontal") return axisH;
    if (axis=="Vertical") return axisV;
}

function CalculateVelocity()
{
	if(Gui2D.TouchButtonsEnabledGlobal == true)
	{
		CurrentVelocity = Acceleration * InputGetAxis("Horizontal") * Time.deltaTime * 10;
		Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
	}
	
	if(Gui2D.TouchButtonsEnabledGlobal == false)
	{
		CurrentVelocity = Acceleration * Input.GetAxis("Horizontal") * Time.deltaTime * 10;
		Velocity = Mathf.Clamp(CurrentVelocity, -MaxSpeed, MaxSpeed);
		
		if(Input.GetAxis("Horizontal") < 0)
		{
			CarMoveLeft = true;
			CarMoveRight = false;
		}
		
		else if(Input.GetAxis("Horizontal") > 0)
		{
			CarMoveLeft = false;
			CarMoveRight = true;
		}
		
		else
		{
			CarMoveLeft = false;
			CarMoveRight = false;
		}
	}
	
}

function GetUserInput()
{
	//Get input for the handbrake
	if(Input.GetKey(KeyCode.Space) || CarHandbrake == true)
	{
		for(var i = 0; i <= (Wheels.length-1); i++)
		{
			Wheels[i].GetComponent.<Rigidbody2D>().fixedAngle = true;
		}
	}
	
	else
	{
		CarHandbrake = false;
		for(var j = 0; j <= (Wheels.length-1); j++)
		{
			Wheels[j].GetComponent.<Rigidbody2D>().fixedAngle = false;
		}
	}
	
	if(Input.GetKey(KeyCode.R)) Application.LoadLevel(Application.loadedLevel);
	if(Input.GetKey(KeyCode.Z) || CarFlip == true) FlipCar();
}

function FlipCar()
{
	//Flip the car
	Ensemble.transform.rotation = Quaternion.LookRotation(Ensemble.transform.forward);
	Car.transform.position.y += 0.2;
}

function GetCurrentspeed()
{
	//This converts rigidbody2D velocity magnitude to km/h
	CurrentSpeed = CarBody.GetComponent.<Rigidbody2D>().velocity.magnitude * 3.6;
	CurrentSpeedInKmph = CurrentSpeed;
	//Debug.Log("CurrentSpeed: "+CurrentSpeed+" km/h");
}
 
