using UnityEngine;
using Actions.Core;

public class LogMessage : ReactionInstant
{
	private LogMessageData logData
	{
		get
		{
			return data as LogMessageData;
		}
	}

	protected override void OnExecute ()
	{
		Debug.Log(logData.LogMessage);
	}
}
