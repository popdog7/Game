using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MaskedMischiefNamespace
{
	public abstract class StateMachine
	{
		protected IState currentState;

		public IState CurrentState { get => currentState; }

		public void ChangeState(IState newState)
		{
			currentState?.Exit();

			currentState = newState;

			currentState.Enter();
		}

		public void HandleInput()
		{
			currentState?.HandleInput();
		}

		public void Update()
		{
			currentState?.Update();
		}

		public void PhysicsUpdate()
		{
			currentState?.PhysicsUpdate();
		}
		public void ExitState()
		{
			currentState?.Exit();
		}

	}
}
