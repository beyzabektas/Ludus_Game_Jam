using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : State
{
    private EnemyStateData _data = null;
    private Transform _target = null;

    public override void Enter(params object[] parameters)
    {
        _data = parameters[0] as EnemyStateData;

        _target = GameObject.FindGameObjectWithTag("Player").transform;

        Utility.PlayAnimation(_data.Animator, "Move");
    }

    public override void Tick()
    {
        Vector2 _target = new(this._target.position.x, _data.Transform.position.y);

        _data.Transform.position = Vector2.MoveTowards(_data.Transform.position, _target, Time.deltaTime * _data.Data.MoveSpeed);

        _data.SpriteRenderer.flipX = _data.Transform.position.x - _target.x < 0;

        if (Vector2.Distance(_data.Transform.position, _target) > _data.Data.AttackRange)
            return;

        _data.Enemy.SetState<EnemyAttackState>();
    }

    public override void FixedTick()
    {
    }
    public override void Exit()
    {
    }
}