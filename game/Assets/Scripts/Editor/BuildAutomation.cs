using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Diagnostics;
using System.IO;

public static class BuildAutomation
{

	[MenuItem("Tools/BuildToSteam")]
	public static void Build()
	{
		var AutomationProjectPath = Environment.GetEnvironmentVariable("AUTOMATION_PROJECT_PATH", EnvironmentVariableTarget.User);
		var buildPath = $"{AutomationProjectPath}/tools/Build";
		var logPath = $"{AutomationProjectPath}/log.txt";
		File.Create(logPath);

		//Build game
		File.AppendAllText(logPath, "Building...");
		BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, $"{buildPath}/game.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
		File.AppendAllText(logPath, "Build Successfull");

		//Upload to steam
		var startInfo = new ProcessStartInfo
		{
			FileName = $"{AutomationProjectPath}/tools/UploadToSteam.bat",
			Arguments = ""
		};

		var process = new Process { StartInfo = startInfo };

		process.Start();
		process.WaitForExit();
	}
}
