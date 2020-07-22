// using UnityEngine;
// using UnityEditor;

// using System;
// using System.IO;
// using System.Collections;
// using System.Collections.Generic;

// public class ProjectBuilder
// {
// 	static string[] SCENES = FindEnabledEditorScenes();
// 	static string TARGET_DIR = "Build";

// 	//------------------------- [ Common ] ---------------------------
// 	private static string[] FindEnabledEditorScenes() {
// 		List<string> EditorScenes = new List<string>();
// 		foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
// 			if (!scene.enabled) continue;
// 			EditorScenes.Add(scene.path);
// 		}
		
// 		return EditorScenes.ToArray();
// 	}

//     static void GenericBuild(string[] scenes, string target_path, BuildTarget build_target, BuildOptions build_options)
// 	{
// 		EditorUserBuildSettings.SwitchActiveBuildTarget(build_target);
// 		var res = BuildPipeline.BuildPlayer(scenes, target_path, build_target, build_options);
// 		if (res.ToString().Length > 0) {
// 			throw new Exception("BuildPlayer failure: " + res);
// 		}
// 	}


// 	//------------------------- [ iOS ] ---------------------------
// 	[MenuItem ("Custom/CI/Build iOS")]
// 	static void PerformiOSBuild ()
// 	{
// 		/*
// 		BuildOptions opt = BuildOptions.SymlinkLibraries |
// 			BuildOptions.Development |
// 				BuildOptions.ConnectWithProfiler |
// 				BuildOptions.AllowDebugging |
// 				BuildOptions.Development;         
// 		*/
// 		BuildOptions opt = BuildOptions.None;
		
// 		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK; 
// 		PlayerSettings.iOS.targetOSVersion = iOSTargetOSVersion.iOS_4_3;
// 		PlayerSettings.statusBarHidden = true;

// 		char sep = Path.DirectorySeparatorChar;
// 		string buildDirectory = Path.GetFullPath(".") + sep + TARGET_DIR;
// 		Directory.CreateDirectory(TARGET_DIR + "/iOS");

// 		string BUILD_TARGET_PATH = buildDirectory + "/iOS";
// 		GenericBuild(SCENES, BUILD_TARGET_PATH, BuildTarget.iOS, opt);
// 	}
	

// 	//------------------------- [ Android ] ---------------------------
// 	[MenuItem ("Custom/CI/Build Android (Client)")]
// 	static void PerformAndroidBuildClient ()
// 	{
// 		BuildOptions opt = BuildOptions.None;

//         /* 안드로이드 Sign 으로 묶어서 빌드 할때
// 		PlayerSettings.Android.keystorePass = "키스토어 비번";
// 		PlayerSettings.Android.keyaliasPass = "키스토어 alias 이름";
//         */
        
// 		char sep = Path.DirectorySeparatorChar;
// 		string BUILD_TARGET_PATH = Path.GetFullPath (".") + sep + TARGET_DIR + string.Format ("/AndroidBuild_{0}.apk", PlayerSettings.bundleVersion);
// 		GenericBuild(SCENES, BUILD_TARGET_PATH, BuildTarget.Android, opt);
// 	}
// }
