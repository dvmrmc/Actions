using UnityEngine;

namespace Actions.Core
{
	public class ReactionSequenceData : ReactionGroupData
	{
		public int Times;
		public override System.Type ReactionType ()
		{
			return typeof(ReactionSequence);
		}
	}
}