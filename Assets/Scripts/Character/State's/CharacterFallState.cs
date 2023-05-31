using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFallState : State
{
    //BEN BÝDA KONUÞMAM HACI!!!!!!!!!!!
    private CharacterStateData _stateData = null;
    private Vector2 _moveDirection = Vector2.zero;

    public override void Enter(params object[] parameters)
    {
        _stateData = parameters[0] as CharacterStateData;

        Utility.PlayAnimation(_stateData.Animator, "Fall");
    }

    public override void Tick()
    {
        _moveDirection = _stateData.Character.GetMoveDirection();

        if (!_stateData.RigidBody2D.velocity.y.Equals(0))
            _stateData.Character.SetState<CharacterMoveState>();
    }


    public override void FixedTick()
    {
        //_stateData.RigidBody2D.velocity = _stateData.Character.AirMoveSpeed * Time.fixedDeltaTime * new Vector2(_moveDirection.x, _velocity.y);
    }
    public override void Exit()
    {
    }
}