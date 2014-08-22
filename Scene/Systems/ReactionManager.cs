using System;
using UnityEngine;
using System.Collections.Generic;

namespace Actions.Core
{
	public class ReactionManager
	{
		#region Attributes

		private Dictionary<GameObject, ReactionObject> reactionObjects = new Dictionary<GameObject, ReactionObject>();

		#endregion

		#region Singleton
		
		private static ReactionManager instance;
		private static ReactionManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new ReactionManager();
				}
				return instance;
			}
		}

		private ReactionManager()
		{
		}
		
		#endregion
		
		#region Public methods

		public static void ExecuteReaction(ReactionData data, GameObject sender)
		{
			ReactionManager.Instance.Execute(data, sender, null);
		}

		public static void ExecuteReaction(ReactionData data, GameObject sender, Action<Reaction> loadedHandler)
		{
			ReactionManager.Instance.Execute(data, sender, loadedHandler);
		}

		private void Execute(ReactionData data, GameObject sender, Action<Reaction> loadedHandler)
		{
			ReactionObject reactionObject = GetReactionObject(data, sender);
			reactionObject.Execute(data, loadedHandler);
		}

		#endregion

		#region Helpers

		private ReactionObject GetReactionObject(ReactionData data, GameObject sender)
		{
			ReactionObject result;
			
			if(data.Target == null)
			{
				data.Target = sender;
			}
			
			if(reactionObjects.ContainsKey(data.Target))
			{
				result = reactionObjects[data.Target];
			}
			else
			{
				result = data.Target.AddComponent<ReactionObject>();
				reactionObjects.Add(data.Target, result);
			}
			
			return result;
		}

		#endregion
	}
}