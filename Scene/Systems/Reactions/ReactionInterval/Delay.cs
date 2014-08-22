using UnityEngine;
using Actions.Core;

public class Delay : ReactionInterval
{
	private float delayed;

	protected override void OnStart ()
	{
		delayed = 0.0f;
	}

	protected override void OnPause ()
	{
		//Do nothing
	}

	protected override void OnResume ()
	{
		//Do nothing
	}

	protected override void OnStop ()
	{
		//Do nothing
	}

	protected override void OnUpdate (float deltaTime)
	{
		delayed+=deltaTime;
		if(delayed > (data as DelayData).Delay)
		{
			Stop();
		}
	}
}
