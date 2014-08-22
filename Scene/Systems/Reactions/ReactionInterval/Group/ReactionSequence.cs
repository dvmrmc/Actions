using UnityEngine;
using System.Collections.Generic;

namespace Actions.Core
{
	public class ReactionSequence : ReactionInterval
	{	
		public List<Reaction> sequence = new List<Reaction>();

		private int currentIndex		= 0;
		private int elapsedTimes		= 0;
		private bool finished			= false;
		private Reaction current		= null;

		private ReactionSequenceData sequenceData
		{
			get
			{
				return data as ReactionSequenceData;
			}
		}

		protected override void OnStart ()
		{
			if(sequenceData.Reactions.Count == 0)
			{
				Stop();
				return; 
			}
			
			elapsedTimes		= 0;
			currentIndex	= 0;
			finished			= false;
			
			ReactionManager.ExecuteReaction(sequenceData.Reactions[currentIndex], this.gameObject, ReactionLoaded);
		}
		
		protected override void OnPause ()
		{
			if(current.GetType().IsSubclassOf(typeof(ReactionInterval)))
			{
				ReactionInterval interval = current as ReactionInterval;
				interval.Pause();
			}
		}
		
		/// <summary>
		/// Raises the resume event.
		/// </summary>
		protected override void OnResume ()
		{
			if(current.GetType().IsSubclassOf(typeof(ReactionInterval)))
			{
				ReactionInterval interval = current as ReactionInterval;
				interval.Resume();
			}
		}
		
		/// <summary>
		/// Raises the stop event.
		/// </summary>
		protected override void OnStop ()
		{
			if (!finished)
			{
				current.Finished -= ReactionFinished;

				if(current.GetType().IsSubclassOf(typeof(ReactionInterval)))
				{
					ReactionInterval interval = current as ReactionInterval;
					interval.Stop();
				}
			}
		}
		
		protected override void OnUpdate (float deltaTime)
		{
			//Do nothing
		}
		
		#region Action callbacks
		
		private void ReactionLoaded(Reaction sender)
		{
			current = sender;
			current.Finished += ReactionFinished;
		}
		
		/// <summary>
		/// Executes the next.
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='args'>
		/// Arguments.
		/// </param>
		private void ReactionFinished(Reaction sender)
		{
			current.Finished -= ReactionFinished;
			
			currentIndex++;
			
			if(currentIndex >= sequenceData.Reactions.Count)
			{
				elapsedTimes++;
				
				if(elapsedTimes < sequenceData.Times || sequenceData.Times == -1)
				{
					currentIndex = 0;
					ReactionManager.ExecuteReaction(sequenceData.Reactions[currentIndex], this.gameObject, ReactionLoaded);
				}
				else
				{	
					finished = true;
					Stop();
				}
				
				return;
			}
			
			ReactionManager.ExecuteReaction(sequenceData.Reactions[currentIndex], this.gameObject, ReactionLoaded);
		}
		
		#endregion
	}
}