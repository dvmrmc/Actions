using UnityEngine;
using System;
using System.Collections.Generic;

namespace Actions.Core
{
	[AddComponentMenu("Actions/Reaction List")]
	[Serializable]
	public class ReactionList : MonoBehaviour 
	{
		#region Events
		
		public event Action Loaded;
		protected void RaiseLoaded()
		{
			if(Loaded != null)
			{
				Loaded();
			}
		}
		
		public event Action Paused;
		protected void RaisePaused()
		{
			if(Paused != null)
			{
				Paused();
			}
		}
		
		public event Action Resumed;
		protected void RaiseResumed()
		{
			if(Resumed != null)
			{
				Resumed();
			}
		}
		
		public event Action Finished;
		protected void RaiseFinished()
		{
			if(Finished != null)
			{
				Finished();
			}
		}
		
		#endregion
		
		#region Attributes

		[SerializeField]
		public string ID = string.Empty;
		[SerializeField]
		public List<ReactionData> data = new List<ReactionData>();

		private List<Reaction> reactions = new List<Reaction>();
		private int loadedActions = 0;
		private int finishedActions = 0;

		#endregion

		#region Public Methods

		public void OnEnable()
		{
			if(reactions == null)
			{
				reactions = new List<Reaction>();
			}
		}
		
		public void Execute()
		{
			loadedActions = 0;
			finishedActions = 0;
		}
		
		public void Pause()
		{
			foreach(Reaction reaction in reactions)
			{
				if(reaction.GetType().IsSubclassOf(typeof(ReactionInterval)))
				{
					ReactionInterval interval = reaction as ReactionInterval;
					interval.Pause();
				}
				else
				{
					//TODO: Pause next ReactionInterval
				}
			}
			
			RaisePaused();
		}
		
		public void Resume()
		{
			foreach(Reaction reaction in reactions)
			{
				if(reaction.GetType().IsSubclassOf(typeof(ReactionInterval)))
				{
					ReactionInterval interval = reaction as ReactionInterval;
					interval.Resume();
				}
				else
				{
					//TODO: Resume next ReactionInterval
				}
			}
			
			RaiseResumed();
		}
		
		public void Stop()
		{
			foreach(Reaction reaction in reactions)
			{
				if(reaction.GetType().IsSubclassOf(typeof(ReactionInterval)))
				{
					ReactionInterval interval = reaction as ReactionInterval;
					interval.Stop();
				}
				else
				{
					//TODO: Stop next ReactionInterval
				}
			}
			
			RaiseFinished();
		}
		
		#endregion
		
		#region Action callbacks
		
		private void ReactionLoaded(Reaction sender)
		{
			sender.Finished += ReactionFinished;
			loadedActions ++;
			reactions.Add(sender);
			
			if(loadedActions == data.Count)
			{
				RaiseLoaded();
			}
		}
		
		private void ReactionFinished(Reaction sender)
		{
			sender.Finished -= ReactionFinished;
			
			finishedActions ++;
			reactions.Remove(sender);
			
			if(finishedActions == data.Count)
			{
				Stop();
			}
		}
		
		#endregion
	}
}