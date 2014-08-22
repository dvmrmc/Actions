using UnityEngine;
using Actions.Core;

public class LogMessageData : ReactionData
{
	public string LogMessage = string.Empty;

	public override System.Type ReactionType ()
	{
		return typeof(LogMessage);
	}
}