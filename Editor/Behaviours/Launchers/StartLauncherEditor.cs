using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

//[CustomEditor(typeof(StartLauncher))]
public class StartLauncherEditor: Editor
{		
//	private StartLauncher launcher;
//	private bool changed;
//	
//	private void OnEnable()
//	{
//		launcher = target as StartLauncher;
//	}
//	
//	public override void OnInspectorGUI ()
//	{
//		launcher.SelectedTargetType = (StartLauncher.TargetType) EditorGUILayout.EnumPopup("Target type",launcher.SelectedTargetType);
//		
//		switch(launcher.SelectedTargetType)
//		{
//			case StartLauncher.TargetType.Node:
//			{
//				launcher.ActionListTarget 	= (GameObject) EditorGUILayout.ObjectField("Target", launcher.ActionListTarget, typeof(GameObject),true);
//			}
//			break;
//			
//			case StartLauncher.TargetType.Tag:
//			{
//				launcher.ActionListTargetTag = EditorGUILayout.TextField("Target tag", launcher.ActionListTargetTag);
//			}
//			break;
//			
//			default: { } break;
//		}
//		
//		launcher.ActionListID = EditorGUILayout.TextField("List ID", launcher.ActionListID);
//		
//		if(GUI.changed)
//		{
//			EditorUtility.SetDirty(launcher);
//		}
//	}	
}

