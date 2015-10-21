using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SceneLoaderWindow : EditorWindow
{
    private static Dictionary<string, List<FileInfo>> scenesByFolder;
    private static Dictionary<string, List<FileInfo>> ScenesByFolder
    {
        get
        {
            if (scenesByFolder == null || scenesByFolder.Count == 0)
            {
                var sceneFiles = new DirectoryInfo(Application.dataPath).GetFiles("*.unity", SearchOption.AllDirectories);

                scenesByFolder = new Dictionary<string, List<FileInfo>>();

                foreach (var sceneFile in sceneFiles)
                {
                    if (sceneFile.Directory != null)
                    {
                        var dirPath = sceneFile.Directory.FullName
                            .Replace(Application.dataPath.Replace("/", "\\"), string.Empty)
                            .Trim('/', '\\');

                        if (!scenesByFolder.ContainsKey(dirPath))
                        {
                            scenesByFolder.Add(dirPath, new List<FileInfo>());
                        }

                        scenesByFolder[dirPath].Add(sceneFile); 
                    }
                    else
                    {
                        Debug.LogWarning("No folder for file: " + sceneFile.FullName);
                    }
                }
            }

            return scenesByFolder;
        }
    }

    private static Vector2 scrollPosition;

    [MenuItem("Window/Scene Loader")]
    public static void ShowWindow()
    {
        scenesByFolder = ScenesByFolder;

        var editorWindow = GetWindow(typeof(SceneLoaderWindow));

#if UNITY_5_1
        editorWindow.titleContent.text
#else
        editorWindow.title
#endif
            = "Scene Loader";

        editorWindow.Focus();
    }

    protected void OnGUI()
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, false);

        if (ScenesByFolder != null)
        {
            foreach (var scenes in ScenesByFolder)
            {
                GUILayout.Label(scenes.Key);

                foreach (var scene in scenes.Value)
                {
                    GUILayout.BeginHorizontal();

                    if (GUILayout.Button(scene.Name.Replace(scene.Extension, string.Empty)))
                    {
                        if (EditorApplication.SaveCurrentSceneIfUserWantsTo())
                        {
                            EditorApplication.OpenScene(scene.FullName);
                        }
                    }

                    if (GUILayout.Button("7", GUILayout.ExpandWidth(false)))
                    {
                        var scenePath = "Assets\\" + scenes.Key + "\\" + scene.Name;

                        var sceneAsset = AssetDatabase.LoadMainAssetAtPath(scenePath);

                        if (sceneAsset)
                        {
                            EditorGUIUtility.PingObject(sceneAsset); 
                        }
                        else
                        {
                            Debug.LogWarning("No scene asset found: " + scenePath);
                        }
                    }

                    GUILayout.EndHorizontal();
                }

                GUILayout.Space(17);
            }
        }

        if (GUILayout.Button("Refresh Scenes"))
        {
            scenesByFolder = null;
            scenesByFolder = ScenesByFolder;
        }

        GUILayout.EndScrollView();
    }
}