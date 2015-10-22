public var StartingPitch = 1;
public var MaxPitch = 1.8;
public var TimeToIncrease = 1.0;
public var TimeToDecrease = 0.7;

function Start() {

    GetComponent.<AudioSource>().pitch = StartingPitch;
    GetComponent.<AudioSource>().volume = 1.0;  
}

function FixedUpdate(){
 	
	if (Move2D.CarMoveLeft == true)
	{
		if(GetComponent.<AudioSource>().pitch < MaxPitch)
		GetComponent.<AudioSource>().pitch += ((Time.deltaTime) / TimeToIncrease);
	}
		
	else if (Move2D.CarMoveRight == true)
	{
		if(GetComponent.<AudioSource>().pitch < MaxPitch)
		GetComponent.<AudioSource>().pitch += ((Time.deltaTime) / TimeToIncrease);
	}

	else
	{
		if(GetComponent.<AudioSource>().pitch > StartingPitch)
		GetComponent.<AudioSource>().pitch -= ((Time.deltaTime) / TimeToDecrease);
	}    
}