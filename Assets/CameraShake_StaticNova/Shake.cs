using UnityEngine;
using System.Collections;

[AddComponentMenu("Camera Shake System/Shake")]
public class Shake : MonoBehaviour {

	// Logic flags.
	bool shaking = false;
	bool startDecay = false;
	bool addDecay = false;
 
	// Shake values, with default settings.
	float decay = 5f;
	float intensity = 0.0010f;
	float intensityLimit = 0.0015f;

	// Initial values so we can reset after shaking.
	Vector3 initialPosition;
	Quaternion initialRotation;
	float initialIntensity, initialIntensityLimit;

	// Stores our values when calling a custom shake. 
	float customDecay = 0.00025f;
	float customIntensity = 0.0320f;
	float customIntensityLimit = 0.015f;
	bool customAddDecay = false;

	// Different shake types, call Shake() with one of these.
	public enum ShakeType {
	    standard,
	    rumble,
	    explosion,
	    earthquake,
	    random,
	    custom
	}

	// Simple singleton pattern.
	static Shake _instance;
	public static Shake Instance { get{ return _instance; } }
	public static Shake GetInstance() {
	   if(!_instance) Debug.Log("Shake() - Please assign the script to the object in the scene before trying to access it.");
	   return _instance;   
	}

	void Awake() {
	    _instance = this;
		initialPosition = transform.position;
	    initialRotation = transform.rotation;
	}

	public bool GetShakeState() {
	    return shaking;
	}

	public void StartShake( float shakeIntensity, float shakeDecay, float shakeLimit, bool shakeAddDecay ) {
		customIntensity = shakeIntensity > 0 ? shakeIntensity : intensity;
	    customIntensityLimit = shakeLimit > 0 ? shakeLimit : intensityLimit;
	    customDecay = shakeDecay > 0 ? shakeDecay : decay;
	    customAddDecay = shakeAddDecay;
	    StartShake( ShakeType.custom );
	} 
	public void StartShake() { StartShake( ShakeType.standard ); }
	public void StartShake( ShakeType type ) {
	    if(!shaking) {
	        switch(type) {
	            case ShakeType.rumble:       Rumble();          break;
	            case ShakeType.explosion:    Explosion();       break;
	            case ShakeType.earthquake:   Earthquake();      break;
	            case ShakeType.random: 		 RandomShake(); 	break;
	            case ShakeType.custom: 		 CustomShake(); 	break;
	            default:  					 DefaultShake();    break;                   
	        }
	    }
	}

	public void StopShake() {
		shaking = false;
	    startDecay = false;
		intensity = initialIntensity;
	    intensityLimit = initialIntensityLimit;
		transform.position = initialPosition;
	  	transform.rotation = initialRotation;
	}

	IEnumerator BeginShake() {
	    while(shaking){
	        // Shake Algorythm.
	        transform.position = gameObject.transform.position + Random.insideUnitSphere * intensity;
	        transform.rotation = new Quaternion( initialRotation.x + Random.Range( -intensity, intensity ) * Random.value,
	                                             initialRotation.y + Random.Range( -intensity, intensity ) * Random.value,
	                                             initialRotation.z + Random.Range( -intensity, intensity ) * Random.value,
	                                             initialRotation.w + Random.Range( -intensity, intensity ) * Random.value );

	        // Specific behaviour for presets.
	        if(addDecay) {
	        	if(!startDecay) {
                    intensity += decay;
                    if(intensity >= intensityLimit) startDecay = true;
                } else {
                    intensity -= decay;
                }
	        } else {
	        	intensity -= decay;    
	        }
	        
	        // Check to see if we need to stop the shake.
	        if(intensity <= 0f) StopShake();   
	        yield return null;
	    }
	}

	  /////////////
	 // Presets //
	/////////////

	void Rumble() {
	    if(!shaking) {
	        initialIntensity = intensity;
	        initialIntensityLimit = intensityLimit;
	        shaking = true;
	        addDecay = true;
	        intensityLimit = 0.015f;
	        intensity = 0.000125f;
	        decay = 0.00000825f;
	        StartCoroutine("BeginShake");
	    }
	}

	void Explosion() {
	    if(!shaking) {
	        initialIntensity = intensity;
	        initialIntensityLimit = intensityLimit;
	        shaking = true;
	        addDecay = true;
	        intensityLimit = 0.009f;
	        intensity = 0.009f;
			decay = 0.0000825f;
	        StartCoroutine("BeginShake");
	    }
	}

	void Earthquake() {
	    if(!shaking) {
	        initialIntensity = intensity;
	        initialIntensityLimit = intensityLimit;
	        shaking = true;
	        addDecay = true;
	        intensityLimit = 0.015f;
	        intensity = 0.000125f;
	        decay = 0.00000825f;
	        StartCoroutine("BeginShake");
	    }
	}

	void RandomShake() {
	    if(!shaking) {
	        initialIntensity = intensity;
	        initialIntensityLimit = intensityLimit;
	        shaking = true;
	        if( Random.Range(0.0f, 100.0f) > 50.0f ) addDecay = true;
	        else addDecay = false;
	        intensityLimit = Random.Range(0.010f, 0.035f);
	        intensity = Random.Range(0.00025f, 0.0055f);
	        decay = Random.Range(0.00000825f, 0.00015f);
	        StartCoroutine("BeginShake");
	    }
	}

	void CustomShake() {
		if(!shaking) {
	        initialIntensity = intensity;
	        initialIntensityLimit = intensityLimit;
	        shaking = true;
	        addDecay = customAddDecay;
	        intensity = customIntensity;
	        intensityLimit = customIntensityLimit;
	        decay = customDecay;
	        StartCoroutine("BeginShake");
	    }
	}

	void DefaultShake() {
		if(!shaking) {
			initialIntensity = intensity;
	   	 	initialIntensityLimit = intensityLimit;
	   	 	shaking = true;
	   	 	addDecay = false;
	   	 	intensityLimit = 0.015f;
			intensity = 0.0320f;
			decay = 0.00025f;
	   	 	StartCoroutine("BeginShake"); 
	   	}
	}
}
