using UnityEngine;
using System.Collections.Generic;

namespace Actions.Core
{
	public abstract class ReactionGroupData : ReactionData 
	{
		public List<ReactionData> 	Reactions 	= new List<ReactionData>();
	}
}