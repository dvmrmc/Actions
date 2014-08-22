using UnityEngine;
using System;
using System.Collections.Generic;

namespace Actions.Core
{
	public abstract class Reaction : MonoBehaviour
	{	
		#region Events
		public event Action<Reaction> Loaded;
		public event Action<Reaction> Finished;
		#endregion

		#region Attributes
		public ReactionData data;
		#endregion
		
		#region Public methods
		public virtual void Execute(ReactionData data)
		{
			this.data = data;
			RaiseLoadedEvent();
		}
		#endregion
		
		#region Engine methods
		protected virtual void RaiseLoadedEvent()
		{
			if(Loaded != null)
			{
				Loaded(this);
			}
		}

		protected virtual void RaiseFinishedEvent()
		{
			if(Finished != null)
			{
				Finished(this);
			}
			Destroy(this);
		}
		#endregion
	}
}