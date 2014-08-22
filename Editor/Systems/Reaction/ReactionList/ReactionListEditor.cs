using UnityEditor;
using UnityEngine;
using Actions.Core;
using System.Collections.Generic;
using System;

[CustomEditor(typeof(ReactionList))]
public class ReactionListEditor : Editor
{
	private ReactionList reactionList;
	private SerializedObject targetObject;
	private SerializedProperty listProperty;
	
	void OnEnable()
	{
		reactionList = (ReactionList)target;
		targetObject = new SerializedObject(reactionList);
		listProperty = targetObject.FindProperty("data"); // Find the List in our script and create a refrence of it
	}

	public override void OnInspectorGUI ()
	{
		targetObject.Update();

		EditorGUILayout.LabelField("Add a new item with a button");
		if(GUILayout.Button("Add New"))
		{
			reactionList.data.Add(CreateInstance<ReactionData>());
		}

		for (int i = 0; i < listProperty.arraySize; i++)
		{
			SerializedProperty itemProperty = listProperty.GetArrayElementAtIndex(i);
			EditorGUILayout.PropertyField(itemProperty);
		}

		targetObject.ApplyModifiedProperties();
	}

//	public enum ActionGroup
//	{
//		ACTION_LIST,
//		CUSTOM,
//		TRANSFORMS_3D,
//		TRANSFORMS_2D,
//		ANIMATIONS,
//		ACTIVATIONS,
//		SOUND,
//		MATERIALS,
//		VIDEOS,
//		HIGHTLIGHT,
//		COMBO
//	};
//	
//	private ActionGroup selectedActionGroup = ActionGroup.ACTION_LIST;
//	private ReactionList actionList;
//	private List<ReactionDescriptor> actionDescriptors = new List<ReactionDescriptor>();
//	private bool changed = false;
//	private bool showActions = false;
//		
//	private void OnEnable()
//	{
//		changed = false;
//		actionList = target as ReactionList;
//		
//		if( !string.IsNullOrEmpty(actionList.ActionsFilePath))	
//		{
////			actionDescriptors = SerializationUtilsEditor.Deserialize(actionList.ActionsFilePath, null);
//		}
//		else
//		{
//			actionDescriptors = new List<ReactionDescriptor>();
//		}
//	}
//	
//	public override void OnInspectorGUI ()
//	{
//		//Draw actions
////		EditorResources.SecureTextureLoad(EditorResources.TEXTURES.COLLAPSE);
////		EditorResources.SecureTextureLoad(EditorResources.TEXTURES.EXPAND);	
//		GUILayout.Box(actionList.ID, GUILayout.ExpandWidth(true), GUILayout.Height(20f));
//		actionList.ID = EditorGUILayout.TextField("List ID", actionList.ID);
//		
//		EditorGUILayout.Space();
//		
//		FileManagement();
//		
//		if(!string.IsNullOrEmpty(actionList.ActionsFilePath))
//		{
//			EditorGUILayout.Space();
//			
//			DrawList(ref actionDescriptors, ref selectedActionGroup, ref showActions);
//		}
//			
//		//Save if needed
//		if(GUI.changed && !Application.isPlaying)
//		{
//			changed = true;
//		
//			if( !string.IsNullOrEmpty(actionList.ActionsFilePath))	
//			{
////				SerializationUtilsEditor.Serialize(actionList.ActionsFilePath, actionDescriptors);
//			}
//		}
//		EditorUtility.SetDirty(actionList);
//	}
//
//	private void OnDisable()
//	{
//		if(changed)
//		{
//			
////			string actionsFilePath = FileUtils.FilePathAbsoluteRelativeToAssetsPath(actionList.ActionsFilePath);
////			AssetDatabase.ImportAsset(actionsFilePath, ImportAssetOptions.Default);
//			changed = false;
//		}
//	}
//	
//	#region Instance methods
//	
//	/// <summary>
//	/// Adds the or create.
//	/// </summary>
//	/// <returns>
//	/// The or create.
//	/// </returns>
//	/// <param name='fileName'>
//	/// File name.
//	/// </param>
//	/// <param name='actionList'>
//	/// Action list.
//	/// </param>
//	private void FileManagement()
//	{
//		if(!System.IO.File.Exists(actionList.ActionsFilePath))
//		{
//			actionList.ActionsFilePath = null;
//			actionDescriptors.Clear();
//		}
//			
//		//Nombre del fichero
//		EditorGUILayout.LabelField("Actions file",actionList.ActionsFilePath);
//		
//		GUILayout.BeginHorizontal();
//		
//		if( GUILayout.Button("CREATE",GUILayout.ExpandWidth(true)) )
//		{
//			ClearAndCreateFile(true);
//		}
//	
//		if( GUILayout.Button("DUPLICATE",GUILayout.ExpandWidth(true)) )
//		{
//			ClearAndCreateFile(false);
//		}
//		
//		if(!string.IsNullOrEmpty(actionList.ActionsFilePath))
//		{
//			if( GUILayout.Button("ADD",GUILayout.ExpandWidth(true)) )
//			{
//			    string newFileName = EditorUtility.OpenFilePanel("Select File:",Application.dataPath + "/Resources/","txt");
//				
////				newFileName = FileUtils.FilePathAbsoluteRelativeToResources(newFileName);
//				
//				if(!string.IsNullOrEmpty(newFileName))
//				{
////					actionDescriptors = SerializationUtilsEditor.Deserialize(newFileName,actionDescriptors);
////					SerializationUtilsEditor.Serialize(actionList.ActionsFilePath,actionDescriptors);
//				}
//			}
//		}
//		
//		//BOTON CARGAR
//		if( GUILayout.Button("LOAD",GUILayout.ExpandWidth(true)) )
//		{
//		    string newFileName = EditorUtility.OpenFilePanel("Select File:",Application.dataPath + "/Resources/","txt");
//			//newFileName = FileUtils.FilePathAbsoluteRelativeToResources(newFileName);
//			if(!string.IsNullOrEmpty(newFileName))
//			{
//				actionList.ActionsFilePath = newFileName;
////				actionDescriptors = SerializationUtilsEditor.Deserialize(actionList.ActionsFilePath,null);
//			}
//		}
//		GUILayout.EndHorizontal();
//		
//		
//		GUILayout.BeginHorizontal();
//		
//		//BOTON BORRAR
//		if( !string.IsNullOrEmpty(actionList.ActionsFilePath) )
//		{	
//			if(GUILayout.Button("ERASE FILE REFERENCE",GUILayout.ExpandWidth(true)) )
//			{
//				bool destroy = EditorUtility.DisplayDialog("Warning","Are you sure that you want clear all?","Yes","No");
//				if(destroy)
//				{
//					actionDescriptors.Clear();
//					actionList.ActionsFilePath = null;
//				}
//			}
//		}
//		
//		if(PrefabUtility.GetPrefabType(target) == PrefabType.PrefabInstance)
//		{
//			EditorGUILayout.BeginHorizontal();
//			
//			if(GUILayout.Button("UNLINK FROM PREFAB",GUILayout.ExpandWidth(true)))
//			{
//				if(ClearAndCreateFile(false))
//				{
//					PrefabUtility.DisconnectPrefabInstance(target);
//				}
//			}
//			EditorGUILayout.EndHorizontal();
//		}
//		
//		GUILayout.EndHorizontal();
//	}
//	
//	/// <summary>
//	/// Clears the and create file.
//	/// </summary>
//	/// <returns>
//	/// The and create file.
//	/// </returns>
//	/// <param name='clear'>
//	/// If set to <c>true</c> clear.
//	/// </param>
//	private bool ClearAndCreateFile(bool clear)
//	{
//		string newFileName = EditorUtility.SaveFilePanel("Select File:",Application.dataPath + "/Resources/","","txt");
//		
//		//newFileName = FileUtils.FilePathAbsoluteRelativeToResources(newFileName);
//		
//		if(!string.IsNullOrEmpty(newFileName))
//		{
//			if(clear)
//			{
//				actionDescriptors.Clear();
//			}
//			
//			actionList.ActionsFilePath = newFileName;
//			
////			SerializationUtilsEditor.Serialize(actionList.ActionsFilePath, actionDescriptors);
//			return true;
//		}
//			
//		return false;
//	}
//	
//	#endregion
//	
//	#region Class methods
//	
//	public static void DrawList (ref List<ReactionDescriptor> descriptorsList, ref ActionGroup actionGroup, ref bool show)
//	{
//		actionGroup = (ActionGroup) EditorGUILayout.EnumPopup("SELECT CATEGORY", actionGroup, GUILayout.ExpandWidth(true));
//		
//		EditorGUILayout.Space();
//		EditorGUILayout.Space();
//		
//		
//		EditorGUILayout.BeginHorizontal();
//		
//		//Collapse button
////		if(GUILayout.Button(EditorResources.textures[(int)EditorResources.TEXTURES.COLLAPSE],GUILayout.ExpandWidth(true), GUILayout.Height(30f)))
////		{
////			foreach( ActionDescriptor descriptor  in descriptorsList)
////			{
////				descriptor.Show = false;
////			}
////		}
//		
//		//Expand button
////		if(GUILayout.Button(EditorResources.textures[(int)EditorResources.TEXTURES.EXPAND],GUILayout.ExpandWidth(true), GUILayout.Height(30f)))
////		{
////			foreach( ActionDescriptor descriptor  in descriptorsList)
////			{
////				descriptor.Show = true;
////			}
////		}
//		
//		
//		EditorGUILayout.EndHorizontal();
//		
//		EditorGUILayout.Space();
//		
//		//Draw actions
//		if(descriptorsList.Count > 0)
//		{
//			show = EditorGUILayout.Foldout(show, "Actions");
//			
//			EditorGUI.indentLevel++;
//			{
//				if(show)
//				{
//					descriptorsList = DrawAndReorderActionList(descriptorsList);
//				}
//			}
//			
//			EditorGUI.indentLevel--;
//		}
//	}
//	
//	#endregion
//	
//	
//	
//	#region Helpers
//	
//	private static void CreateAction(string name, ref List<ReactionDescriptor> descriptors)
//	{
//		//EXTRACT SELECTED GROUP TO SHOW SELECTABLE GROUP OF ACTIONS
////		int id = 0;
//////		int size = association.Length;
////
//////		string[] list = new string[size];
//////		
//////		for(int i = 0; i < size ; ++i)
//////		{
////////			list[i] = association[i].GetStringID();
//////		}
////		
////		//MAKE A SELECTABLE POPUP
////		id	=  EditorGUILayout.Popup(name,id ,list,GUILayout.ExpandWidth(true));
////		
////		if(id != 0)
////		{
////			//Get selected action group action Types
////			System.Type[] types = null;
////			
//////			for( int i = 0 ; i < association.Length ; ++i )
////			{
////				string currentString = association[i].GetStringID();
////				if(list[id] == currentString )
////				{
////					types = association[i].GetClassTypes();
////					break;
////				}
////			}
////			
////			//Search selected action type to create action instance
////			if(types != null)
////			{
////				foreach(System.Type type in types)
////				{
////					ActionDescriptor descriptor = System.Activator.CreateInstance(type) as ActionDescriptor;
////					
////					if(descriptor != null)
////					{
////						descriptors.Add(descriptor);
////					}
////				}
////			}
////		}
//	}
//	
//	/// <summary>
//	/// Draws the and reorder list.
//	/// </summary>
//	/// <returns>
//	/// The and reorder list.
//	/// </returns>
//	/// <param name='list'>
//	/// List.
//	/// </param>
//	private static List<ReactionDescriptor> DrawAndReorderActionList(List<ReactionDescriptor> descriptors)
//	{
////		EditorResources.SecureTextureLoad(EditorResources.TEXTURES.UP);
////		EditorResources.SecureTextureLoad(EditorResources.TEXTURES.DOWN);
////		EditorResources.SecureTextureLoad(EditorResources.TEXTURES.ERASE);
////		
////		int[] order = new int[descriptors.Count];
////		
////		bool orderChanged = false;
////		
////		for( int i = 0 ; i < descriptors.Count ; ++i)
////		{
////			order[i] = i;
////		}
////		
////		for( int i = 0 ; i < descriptors.Count ; ++i )
////		{
////			EditorGUILayout.Space();
////			
////			ActionDescriptor currentActionDescriptor = descriptors[i];
////			int changedIndex = i;
////			
////			EditorGUILayout.Space();
////			
////			// HEADER
////			EditorGUILayout.BeginHorizontal();
////			{
////				//Action name
////				GUILayout.Box(currentActionDescriptor.Name, GUILayout.ExpandWidth(true), GUILayout.Height(20f));
////			
////				// Up button
////				EditorGUI.BeginDisabledGroup (i == 0);
////				{
////					if(GUILayout.Button(EditorResources.textures[(int)EditorResources.TEXTURES.UP],GUILayout.Width(20),GUILayout.Height(20f)))
////					{
////						changedIndex--;
////					}
////				}
////				EditorGUI.EndDisabledGroup();
////				
////				// Down Button
////				EditorGUI.BeginDisabledGroup (i == descriptors.Count-1);
////				{
////					if( GUILayout.Button(EditorResources.textures[(int)EditorResources.TEXTURES.DOWN],GUILayout.Width(20),GUILayout.Height(20f) ))
////					{
////						changedIndex++;
////					}
////				}
////				EditorGUI.EndDisabledGroup();
////				
////				changedIndex = Mathf.Clamp(changedIndex,0,descriptors.Count-1);
////				
////				// Delete button
////				if( GUILayout.Button(EditorResources.textures[(int)EditorResources.TEXTURES.ERASE],GUILayout.Width(20),GUILayout.Height(20f)))
////				{
////					descriptors.Remove(currentActionDescriptor);
////				}
////				
////			}
////			EditorGUILayout.EndHorizontal();
////		
////			//Change order
////			if(changedIndex != i)
////			{
////			  order[i] 			  = changedIndex;
////			  order[changedIndex] = i;
////			  orderChanged = true;
////			  break;
////			}
////			
////			ActionDescriptorEditor currentActionDescriptoreditor = (ActionDescriptorEditor) System.Activator.CreateInstance(System.Type.GetType(currentActionDescriptor.EditorTypeName()));
////					
////			currentActionDescriptor.Show = EditorGUILayout.Foldout(currentActionDescriptor.Show, currentActionDescriptor.ActionType().ToString());
////			
////			if(currentActionDescriptor.Show)
////			{
////				currentActionDescriptoreditor.Draw(ref currentActionDescriptor);		
////			}
////		}
////		
////	    if(orderChanged)
////		{
////			descriptors = ReorderActionDescriptorList(descriptors, order);
////		}
//		
//		return descriptors;
//	}
//	
//	/// <summary>
//	/// Reorder the list.
//	/// </summary>
//	/// <returns>
//	/// The list.
//	/// </returns>
//	/// <param name='list'>
//	/// List.
//	/// </param>
//	/// <param name='order'>
//	/// Order.texture = Resources.Load("glass");
//	/// </param>
//	private static List<ReactionDescriptor> ReorderActionDescriptorList(List<ReactionDescriptor> list,int[] order)
//	{
//		List<ReactionDescriptor> result = new List<ReactionDescriptor>();
//		
//		for(int i = 0 ; i < list.Count ; ++i)
//		{
//			if(order[i] != i)
//			{
//				result.Add(list[order[i]]);
//			}
//			else
//			{
//				result.Add(list[i]);
//			}
//		}
//		
//		return result;
//	}
//	
//	#endregion
}




