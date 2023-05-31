using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveState : State
{
    private CharacterStateData _stateData = null;

    private Vector2 _moveDirection = Vector2.zero;

    public override void Enter(params object[] parameters)
    {
        _stateData = parameters[0] as CharacterStateData;

        Utility.PlayAnimation(_stateData.Animator, "Move");
    }

    public override void Tick()
    {
        _moveDirection = _stateData.Character.GetMoveDirection();

        if (_moveDirection.Equals(Vector2.zero))
            _stateData.Character.SetState<CharacterIdleState>();

        /*if (!_moveDirection.y.Equals(0))
            _stateData.Character.SetState<CharacterJumpState>();*/
    }

    public override void FixedTick()
    {
        _stateData.RigidBody2D.velocity = _stateData.Character.MoveSpeed * Time.fixedDeltaTime * new Vector2(_moveDirection.x, 0);
    }

    public override void Exit()
    {

        if (_stateData.RigidBody2D != null)
        {
            _stateData.RigidBody2D.velocity = Vector2.zero;
        }
    }
}