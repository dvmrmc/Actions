using UnityEngine;
using Actions.Core;
using System.Collections;

public class DelayData : ReactionData
{
	public float Delay;

	public override System.Type ReactionType ()
	{
		return typeof(Delay);
	}
}
