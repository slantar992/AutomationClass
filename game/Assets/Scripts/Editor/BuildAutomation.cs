using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class BuildAutomation
{

	[MenuItem("Tools/BuildToSteam")]
	public static void Build()
	{
		var AutomationProjectPath = Environment.GetEnvironmentVariable("AUTOMATION_PROJECT_PATH", EnvironmentVariableTarget.User);
		var buildPath = $"{AutomationProjectPath}/game/Builds/Steam";
		BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, $"{buildPath}/game.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
		Application.OpenURL(buildPath);
	}
}
