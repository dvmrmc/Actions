using UnityEngine;

namespace Actions.Core
{
	public abstract class ReactionInstant : Reaction
	{
		#region Hidden methods
		
		public sealed override void Execute(ReactionData data)
		{
			base.Execute(data);
			OnExecute();
			RaiseFinishedEvent();
		}
		
		#endregion
		
		#region ExposedMethods
		
		/// <summary>
		/// OnExecute method contains all the execution code of this ActionInstant.
		/// </summary>
		protected abstract void OnExecute();
		
		#endregion
	}
}