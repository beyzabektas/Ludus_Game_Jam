using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackState : State
{
    private CharacterStateData _stateData = null;

    private float _attackDuration = 1.00f;
    private float _elapsedTime = 0.00f;

    public override void Enter(params object[] parameters)
    {
        _stateData = parameters[0] as CharacterStateData;

        Utility.PlayAnimation(_stateData.Animator, "Attack");
    }


    public override void Tick()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _attackDuration)
        {
            _elapsedTime = 0.00f;

            if (GetRayType(out IDamagable damagable))
                damagable.TakeDamage(_stateData.Character.Damage);

            _stateData.Character.SetState<CharacterIdleState>();
        }
    }
    public override void Exit()
    {
        _elapsedTime = 0.00f;
    }

    public override void FixedTick()
    {
    }

    private bool GetRayType<T>(out T _t)
    {
        Vector2 _direction = _stateData.Controller.transform.localScale.x < 0 ? Vector2.left : Vector2.right;

        RaycastHit2D _hit = Physics2D.Raycast(_stateData.Controller.transform.position, _direction, _stateData.Character.AttackRange , _stateData.Character.HitMask);

        if(!_hit.collider)
        {
            _t = default;
            return false;
        }    

        return _hit.collider.TryGetComponent(out _t);
    }
}
