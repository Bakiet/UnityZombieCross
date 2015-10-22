/*  This file is part of the "Simple IAP System for SOOMLA" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them directly or indirectly
 *  from Rebound Games. You shall not license, sublicense, sell, resell, transfer, assign,
 *  distribute or otherwise make available to any third party the Service or the Content. 
 */

using UnityEngine;
using UnityEditor;
using System.Collections;

//our about/help/support editor window
public class AboutSISEditor : EditorWindow
{
    [MenuItem("Window/Simple IAP System/About")]
    static void Init()
    {
        AboutSISEditor aboutWindow = (AboutSISEditor)EditorWindow.GetWindowWithRect
                (typeof(AboutSISEditor), new Rect(0, 0, 300, 300), false, "About");
        aboutWindow.Show();
    }

    void OnGUI()
    {
        EditorGUI.LabelField(new Rect(55, 20, 250, 25), "Simple IAP System for SOOMLA");
        EditorGUI.LabelField(new Rect(90, 37, 250, 25), "by Rebound Games");

        GUILayout.Space(75);

        GUILayout.Label("Info", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
        GUILayout.Label("Homepage");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("http://www.rebound-games.com");
        }
        GUILayout.EndHorizontal();
		
        GUILayout.BeginHorizontal();
        GUILayout.Label("YouTube");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("https://www.youtube.com/user/ReboundGamesTV");
        }
        GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
        GUILayout.Label("Twitter");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("https://twitter.com/Rebound_G");
        }
        GUILayout.EndHorizontal();
		GUILayout.Space(5);

	
        GUILayout.Label("Support", EditorStyles.boldLabel);
		GUILayout.BeginHorizontal();
        GUILayout.Label("Script Reference");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("http://www.rebound-games.com/docs/sisoom/");
        }
        GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
        GUILayout.Label("Support Forum");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("www.rebound-games.com/forum/");
        }
        GUILayout.EndHorizontal();
		
		GUILayout.BeginHorizontal();
        GUILayout.Label("Unity Forum");
        if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("http://forum.unity3d.com/threads/simple-in-app-purchase-system-sis-for-soomla.289730/");
        }
        GUILayout.EndHorizontal();
		GUILayout.Space(5);
		
        GUILayout.Label("Support us!", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Rate/Review");

		if (GUILayout.Button("Visit", GUILayout.Width(100)))
        {
            Help.BrowseURL("https://www.assetstore.unity3d.com/en/#!/content/22628");
        }
		GUILayout.EndHorizontal();
    }
}