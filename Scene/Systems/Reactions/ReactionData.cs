using UnityEngine;
using System;
using System.Collections;

namespace Actions.Core
{
	public class ReactionData : ScriptableObject
	{
		public GameObject Target = null;

		public virtual System.Type ReactionType()
		{
			return typeof(Reaction);
		}
	}
}