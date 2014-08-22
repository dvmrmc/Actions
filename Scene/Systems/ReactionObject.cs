using UnityEngine;
using System;
using System.Collections;

namespace Actions.Core
{
	public class ReactionObject : MonoBehaviour 
	{
		public void Execute(ReactionData data, Action<Reaction> loadedHandler)
		{
			Reaction reaction = (Reaction) gameObject.AddComponent(data.ReactionType());;
			if(loadedHandler != null)
			{
				reaction.Loaded += loadedHandler;
			}
			reaction.Execute(data);
		}
	}
}