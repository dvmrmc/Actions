using UnityEngine;
using System;

namespace Actions.Core
{
	public abstract class ReactionInterval : Reaction
	{
		#region Attributes

		#region Events

		public event Action<Reaction> Paused;
		protected virtual void RaisePausedEvent()
		{
			if(Paused != null)
			{
				Paused(this);
			}
		}

		public event Action<Reaction> Resumed;
		protected virtual void RaiseResumedEvent()
		{
			if(Resumed != null)
			{
				Resumed(this);
			}
		}

		#endregion
		
		#region Inner attributes
		
		private enum State
		{
			None,
			Running,
			Paused
		}
		
		private State CurrentState  = State.None;
		
		#endregion
		
		#region Engine attributes
		
		protected float ElapsedTime;
		
		#endregion
		
		#endregion
		
		#region Methods
		
		#region Overriden methods
		
		/// <summary>
		/// Raises the execute action event.
		/// </summary>
		public sealed override void Execute(ReactionData data)
		{
			base.Execute(data);
			SetState(State.Running);
			OnStart();
		}
		
		public void Pause ()
		{
			if(CurrentState == State.Running)
			{
				SetState(State.Paused);
				OnPause();
				RaisePausedEvent();
			}
		}
		
		public void Resume ()
		{
			if(CurrentState == State.Paused)
			{
				SetState(State.Running);
				OnResume();
				RaiseResumedEvent();
			}
		}
		
		public void Stop ()
		{
			OnStop();
			RaiseFinishedEvent();
		}
		
		#endregion
		
		
		#region Private methods
		
		
		/// <summary>
		/// Sets the state.
		/// </summary>
		/// <param name='state'>
		/// State.
		/// </param>
		private void SetState(State state)
		{
			CurrentState  = state;
		}

		#endregion
		
		#region Unity methods
		
		/// <summary>
		/// Update this instance.
		/// </summary>
		void Update()
		{	
			if(CurrentState == State.Running)
			{
				ElapsedTime += Time.deltaTime;
				OnUpdate(Time.deltaTime);
			}
		}
		
		#endregion
		
		#region Overridable methods
		protected abstract void OnStart();
		
		protected abstract void OnUpdate(float deltaTime);
		
		protected abstract void OnPause();
		protected abstract void OnResume(); 
		
		protected abstract void OnStop();
		
		#endregion
		
		#endregion
	}
}