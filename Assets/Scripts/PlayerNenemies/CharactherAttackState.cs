using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactherAttackState : State
{
    private CharacterStateData _stateData = null;
    private float _attackDuration = 5f;
    private float _currentAttackTime = 3f;
    private bool _isAttacking = false;

    public override void Enter(params object[] parameters)
    {
        _stateData = parameters[0] as CharacterStateData;

        Utility.PlayAnimation(_stateData.Animator, "Attack");
        _currentAttackTime = 3f;
        _isAttacking = true;
    }

    public override void Tick()
    {
        if (_isAttacking)
        {
            Debug.Log("çalýþýyor muuuuuuuuuuuuuuuuuu");
            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime >= _attackDuration)
            {
                _stateData.Character.SetState<CharacterIdleState>();
                _isAttacking = false;
            }
        }

        if (Input.GetMouseButtonDown(0) && !_isAttacking)
        {
            _stateData.Character.SetState<CharactherAttackState>();
        }
    }

 
 

    public override void FixedTick()
    {
    }

public override void Exit()
    {
    }
}

