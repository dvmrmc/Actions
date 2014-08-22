using UnityEngine;

namespace Actions.Core
{
	public class ReactionParallelData : ReactionGroupData 
	{
		public override System.Type ReactionType ()
		{
			return typeof(ReactionParallel);
		}
	}
}