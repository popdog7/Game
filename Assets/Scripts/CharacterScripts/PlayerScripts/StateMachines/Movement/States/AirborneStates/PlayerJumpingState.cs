using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskedMischiefNamespace
{
	public class PlayerJumpingState : PlayerMovementState
	{
		public PlayerJumpingState(PlayerMovementStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
		{
		}

		public override void Enter()
		{
			base.Enter();
			stateMachine.player.yVelocity += stateMachine.player.jumpStrength;
            stateMachine.player.animator.SetTrigger("isJumping");
        }

		public override void Exit()
		{
			base.Exit();
            stateMachine.player.animator.ResetTrigger("isJumping");
        }

		public override void PhysicsUpdate()
		{
			base.PhysicsUpdate();
			var player = stateMachine.player;
			player.transform.Translate(0, player.yVelocity, 0);
			player.yVelocity -= player.gravity;
			if (!player.IsGrounded())
			{
				stateMachine.ChangeState(stateMachine.FallingState);
			}
		}
	}
}