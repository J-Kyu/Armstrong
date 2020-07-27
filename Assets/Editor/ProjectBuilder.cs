using UnityEngine; 
using UnityEditor; 
using System; 
using System.IO; 
using System.Collections.Generic;
using UnityEditor.Build.Reporting;

class ProjectBuilder 
{ 
	static string[] SCENES = FindEnabledEditorScenes(); 
	static string TARGET_DIR = "build"; 


	[MenuItem ("Custom/CI/Build iOS Debug")] 
	static void PerformiOSDebugBuild () 
	{ 
		BuildOptions opt = BuildOptions.SymlinkLibraries |
							BuildOptions.Development |
							BuildOptions.ConnectWithProfiler | 
							BuildOptions.AllowDebugging | 
							BuildOptions.Development |
							BuildOptions.AcceptExternalModificationsToPlayer;
		
		PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK; 
		PlayerSettings.iOS.targetOSVersion = iOSTargetOSVersion.iOS_4_3; 
		PlayerSettings.statusBarHidden = true; 

		char sep = Path.DirectorySeparatorChar; 
		string buildDirectory = Path.GetFullPath(".") + sep + TARGET_DIR; 
		
		string BUILD_TARGET_PATH = TARGET_DIR + "/ios"; 
		Directory.CreateDirectory(BUILD_TARGET_PATH); 
		

		GenericBuild(SCENES, BUILD_TARGET_PATH, BuildTarget.iOS, opt); 
	} 
		
	private static string[] FindEnabledEditorScenes() 
	{ 
		List<string> EditorScenes = new List<string>(); 
		foreach(EditorBuildSettingsScene scene in EditorBuildSettings.scenes) 
		{ 
			if (!scene.enabled){
				continue; 
			} 
			
			EditorScenes.Add(scene.path); 
		} 
		return EditorScenes.ToArray(); 
	} 
	static void GenericBuild(string[] scenes, string target_path, BuildTarget build_target, BuildOptions build_options) 
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, build_target);
		BuildReport res = BuildPipeline.BuildPlayer(scenes, target_path, build_target, build_options); 
		if (res.summary.result != BuildResult.Succeeded) 
		{ 
			throw new Exception("BuildPlayer failure: " + res.summary.result ); 
		} 
	} 
}

