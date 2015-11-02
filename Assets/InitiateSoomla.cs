using UnityEngine;
using System.Collections;
using Soomla;
using Grow.Highway;
using Grow.Insights;

public class InitiateSoomla : MonoBehaviour {

	//
	// Various event handling methods
	//
	public void onGrowInsightsInitialized () {
		Debug.Log("Grow insights has been initialized.");
	}
	public void onInsightsRefreshFinished (){
		if (GrowInsights.UserInsights.PayInsights.PayRankByGenre[Genre.Educational] > 3) {
			// ... Do stuff according to your business plan ...
		}
	}
	
	//
	// Initialize SOOMLA's modules
	//
	void Start () {
		
		// Setup all event handlers - Make sure to set the event handlers before you initialize
		HighwayEvents.OnGrowInsightsInitialized += onGrowInsightsInitialized;
		HighwayEvents.OnInsightsRefreshFinished += onInsightsRefreshFinished;
		
		// Make sure to make this call in your earliest loading scene,
		// and before initializing any other SOOMLA/GROW components
		// i.e. before SoomlaStore.Initialize(...)
		GrowHighway.Initialize();
		
		// Make sure to make this call AFTER initializing HIGHWAY
		GrowInsights.Initialize();
		
		// Initialize the other SOOMLA modules you're using here
	}
}
