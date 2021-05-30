using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class BuildAutomation
{
	[MenuItem("Tools/BuildToSteam")]
	public static void Build()
	{
		
		BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, Application.dataPath + "/../Builds/Steam/game.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
	}
}
