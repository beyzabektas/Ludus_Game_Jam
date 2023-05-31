using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    private EnemyStateData _data = null;
    private Transform _target = null;


    private float _attackDuration = 0.00f;
    private float _elapsedTime = 0.00f;

    public override void Enter(params object[] parameters)
    {
        _data = parameters[0] as EnemyStateData;
        _target = GameObject.FindGameObjectWithTag("Player").transform;

        Utility.PlayAnimation(_data.Animator, "Attack");

        _attackDuration = _data.Enemy.GetCurrentClipLength();
    }


    public override void Tick()
    {
        _elapsedTime += Time.deltaTime;

        if (Vector2.Distance(_data.Transform.position, new(_target.position.x, _data.Transform.position.y)) > _data.Data.AttackRange)
            _data.Enemy.SetState<EnemyMoveState>();

        if (_elapsedTime < _attackDuration)
            return;

        _target.GetComponent<PlayerHealthManager>().HurtPlayer(_data.Data.Damage);
        _data.Enemy.SetState<EnemyMoveState>();
    }

    public override void Exit()
    {
        _elapsedTime = 0.00f;
    }

    public override void FixedTick()
    {
    }
}
