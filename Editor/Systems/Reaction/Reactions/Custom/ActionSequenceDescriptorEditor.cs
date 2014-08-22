using UnityEngine;
using UnityEditor;
using System.Collections;

public class ActionSequenceDescriptorEditor : ReactionIntervalDescriptorEditor 
{
//	
//	/// <summary>
//	/// Draws the interval action.
//	/// </summary>
//	/// <param name='descriptor'>
//	/// Descriptor.
//	/// </param>
//	public override void DrawIntervalAction (ref ReactionDescriptor descriptor)
//	{
////		ActionSequenceDescriptor sequenceDescriptor = descriptor as ActionSequenceDescriptor;
////		
////		sequenceDescriptor.SelectedType = (ActionSequenceDescriptor.SequenceType) EditorGUILayout.EnumPopup("Sequence Type:",sequenceDescriptor.SelectedType);
////		
////		switch(sequenceDescriptor.SelectedType)
////		{
////			case ActionSequenceDescriptor.SequenceType.Repeat:
////			{
////				sequenceDescriptor.Times = EditorGUILayout.IntSlider("Times:", sequenceDescriptor.Times, 0, 50);
////			}
////			break;
////		}			
////		
////		ActionListEditor.ActionGroup actionGroup = (ActionListEditor.ActionGroup) sequenceDescriptor.groups;
////		
////		ActionListEditor.DrawList(ref sequenceDescriptor.ActionList,ref actionGroup, ref descriptor.Show);
////		
////		sequenceDescriptor.groups = (int) actionGroup;
//	}
}
