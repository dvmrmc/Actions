using UnityEngine;
using System.Collections.Generic;

[AddComponentMenu("Actions/Start Launcher")]
public class StartLauncher : MonoBehaviour
{
	public enum TargetType
	{
		Node, 
		Tag
	}
	
	public TargetType SelectedTargetType = TargetType.Node;
	
	public GameObject 	ActionListTarget;
	public string	 	ActionListTargetTag;
	
	public string 		ActionListID = "";
	
	private GameObject node;
	
	/// <summary>
	/// Raises the awake event.
	/// </summary>
	private void Awake ()
	{
		if(string.IsNullOrEmpty(ActionListID))
			return;
		
		node = this.gameObject;
		
		switch(SelectedTargetType)
		{
			case TargetType.Node:
			{
				if(ActionListTarget == null)
				{
					ActionListTarget = node;
				}
			}
			break;
			
			case TargetType.Tag:
			{
				ActionListTarget = GameObject.FindWithTag(ActionListTargetTag);
			}
			break;
		}
	}
	
	private void Start()
	{
//		ReactionList.ExecuteActionList(ActionListTarget, ActionListID);
	}
}