using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieState : State
{
    //State Machine

    private EnemyStateData _data = null;

    private float _timeDuration = 0.80f;
    private float _elapsedTime = 0.00f;

    private bool _isCompletedTask = false;



    public override void Enter(params object[] parameters)
    {

        _data = parameters[0] as EnemyStateData;

        Utility.PlayAnimation(_data.Animator , "Death");
        //_data.Enemy.PlayAnimation("Die");

        //_timeDuration = _data.Enemy.GetCurrentClipLength();
    }

    public override void Tick()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime < _timeDuration)
            return;

        if (!_isCompletedTask)
            CompleteTask();
    }

    public override void FixedTick()
    {
    }

    public override void Exit()
    {
    }

    private void CompleteTask()
    {
        _isCompletedTask = true;

        _data.Enemy.gameObject.SetActive(false);


        if (_data.Data.GetRandomLootDrop(out GameObject _random))
          Instantiate(_random,new(_data.Transform.position.x, GameObject.FindWithTag("Player").transform.position.y) , Quaternion.identity);

        _data.Enemy.InvokeOnDeadAction();
    }
}