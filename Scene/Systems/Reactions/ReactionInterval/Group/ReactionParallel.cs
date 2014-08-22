using UnityEngine;
using System.Collections.Generic;

namespace Actions.Core
{
	public class ReactionParallel : ReactionInterval
	{		
		private List<Reaction> currentActions = new List<Reaction>();
		private int finishedActions = 0;

		private ReactionGroupData groupData
		{
			get
			{
				return (ReactionGroupData)data;
			}
		}

		protected override void OnStart ()
		{
			finishedActions = 0;
			
			if(groupData.Reactions.Count == 0)
			{
				Stop();
				return;
			}

			foreach (ReactionData reaction in groupData.Reactions) 
			{
				ReactionManager.ExecuteReaction(reaction, this.gameObject, ActionLoaded);
			}


		}

		protected override void OnPause ()
		{
			foreach (Reaction reaction in currentActions)
			{
				if(reaction.GetType().IsSubclassOf(typeof(ReactionInterval)))
				{
					ReactionInterval interval = reaction as ReactionInterval;
					interval.Pause();
				}
			}
		}

		protected override void OnResume ()
		{
			foreach (Reaction reaction in currentActions)
			{
				if(reaction.GetType().IsSubclassOf(typeof(ReactionInterval)))
				{
					ReactionInterval interval = reaction as ReactionInterval;
					interval.Resume();
				}
			}
		}
		
		/// <summary>
		/// Raises the stop event.
		/// </summary>
		protected override void OnStop ()
		{
			foreach (Reaction reaction in currentActions)
			{
				reaction.Finished -= ActionFinished;;

				if(reaction.GetType().IsSubclassOf(typeof(ReactionInterval)))
				{
					ReactionInterval interval = reaction as ReactionInterval;
					interval.Resume();
				}
			}
		}
		/// <summary>
		/// Raises the run update event.
		/// </summary>
		/// <param name='deltaTime'>
		/// Delta time.
		/// </param>
		protected override void OnUpdate (float deltaTime)
		{
			//Do nothing
		}
		
		#region Action callbacks
		
		private void ActionLoaded(Reaction sender)
		{
			sender.Finished += ActionFinished;
			currentActions.Add(sender);
		}
		
		private void ActionFinished(Reaction sender)
		{
			sender.Finished -= ActionFinished;
			finishedActions ++;
			currentActions.Remove(sender);
			
			if(finishedActions == groupData.Reactions.Count)
			{
				Stop();
			}
		}
		
		#endregion
	}
}