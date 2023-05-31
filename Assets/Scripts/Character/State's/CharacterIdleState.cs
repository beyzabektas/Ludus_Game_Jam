using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterIdleState : State
{
    private CharacterStateData _stateData = null;

    public override void Enter(params object[] parameters)
    {
        _stateData = parameters[0] as CharacterStateData;

        Utility.PlayAnimation(_stateData.Animator , "Idle");
    }

    public override void Tick()
    {
        Vector2 _moveDirection = _stateData.Character.GetMoveDirection();

        if (_moveDirection.Equals(Vector2.zero))
            return;

        if (_moveDirection.y.Equals(0))
        {
            _stateData.Character.SetState<CharacterMoveState>();
            return;
        }


       // _stateData.Character.SetState<CharacterJumpState>();
    }

    public override void FixedTick()
    {
    }
    public override void Exit()
    {
    }

}