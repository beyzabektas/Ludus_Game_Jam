using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJumpState : State
{
    private CharacterStateData _stateData = null;

    public override void Enter(params object[] parameters)
    {
        _stateData = parameters[0] as CharacterStateData;

        Utility.PlayAnimation(_stateData.Animator, "Jump");

        _stateData.RigidBody2D.velocity = Vector2.up * _stateData.Character.JumpForce;
    }

    public override void Tick()
    {
        if (_stateData.RigidBody2D.velocity.y >= 0)
            return;

        _stateData.Character.SetState<CharacterFallState>();
    }

    public override void FixedTick()
    {
    }
    public override void Exit()
    {
    }
}