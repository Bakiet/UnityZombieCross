using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {


	// Use this for initialization
	void Start () {
		const string projectId = "e04fcd00-8fb7-4ce7-a262-ef2ed94430e2";
		UnityAnalytics.StartSDK (projectId);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
