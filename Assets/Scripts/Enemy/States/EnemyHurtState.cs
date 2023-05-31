using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : State
{
    private EnemyStateData _data = null;

    private float _timeDuration = 0.40f;
    private float _elapsedTime = 0.00f;

    public override void Enter(params object[] parameters)
    {
        _data = parameters[0] as EnemyStateData;

        Utility.PlayAnimation(_data.Animator, "Hurt");
        // _timeDuration = _data.Enemy.GetCurrentClipLength();
        Debug.Log(_timeDuration);
    }


    public override void Tick()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime < _timeDuration)
            return;

        _data.Enemy.SetState<EnemyMoveState>();
    }
    public override void FixedTick()
    {
    }

    public override void Exit()
    {
    }
}
