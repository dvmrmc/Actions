using UnityEditor;
using UnityEngine;
using Actions.Core;
using System.Collections;
using System;

[CustomPropertyDrawer(typeof(ReactionData))]
public class ReactionDataEditor : PropertyDrawer
{
	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUILayout.LabelField("REACTION");
		var target = property.FindPropertyRelative("Target");
		target = EditorGUILayout.PropertyField(target, "Target");
	}
	/// <summary>
	/// Draw the specified descriptor.
	/// </summary>
	/// <param name='descriptor'>
	/// Descriptor.
	/// </param>
//	public void Draw (ref ReactionDescriptor descriptor)
//	{		
//		descriptor.Name			= EditorGUILayout.TextField("Action Name",descriptor.Name);
//		GameObject gameObject	= (GameObject) EditorGUILayout.ObjectField("Target", null, typeof(GameObject),true);
//
//		DrawAction(ref descriptor);
//	}
//	
//	/// <summary>
//	/// Draws the action.
//	/// </summary>
//	/// <param name='descriptor'>
//	/// Descriptor.
//	/// </param>
//	public abstract void DrawAction (ref ReactionDescriptor descriptor);
}
