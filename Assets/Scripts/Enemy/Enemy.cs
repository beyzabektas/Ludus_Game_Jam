using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private EnemyData _data = null;

    [SerializeField] private State _currentState = null;

   

    private EnemyStateData _stateData = null;
    public Animator Animator => _animator;
    private Animator _animator = null;

    public event System.Action OnDeadAction = null;


    private void Awake()
    {
        _data.Initialize();

        _stateData = new(this, _data, GetComponent<SpriteRenderer>());
        _animator = GetComponent<Animator>();

        SetState<EnemyMoveState>();
    }

    private void Update()
    {

        _currentState?.Tick();

    }


    private void FixedUpdate()
    {
        _currentState?.FixedTick();
    }

    public void SetState<T>() where T : State
    {
        _currentState?.Exit();

        _currentState = ScriptableObject.CreateInstance<T>();

        _currentState?.Enter(_stateData);
    }

    /*public void PlayAnimation(string _animationKey)
    {
        int _hashCode = Animator.StringToHash(_animationKey);

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(_animationKey))
            return;

        _animator.Play(_hashCode);
    }*/

    public float GetCurrentClipLength() => _animator.GetCurrentAnimatorStateInfo(0).length;

    public void TakeDamage(int amount)
    {
        _data.Health -= amount;

        if (_data.Health > 0)
        {
            SetState<EnemyHurtState>();
            return;
        }

        SetState<EnemyDieState>();
    }

    public void InvokeOnDeadAction() => OnDeadAction?.Invoke();
}
public class EnemyStateData
{
    private Enemy _enemy = null;

    private EnemyData _data = null;


    private SpriteRenderer _spriteRenderer = null;


    public Enemy Enemy => _enemy;
    public Transform Transform => Enemy.transform;
    public Animator Animator => Enemy.Animator;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;

    public EnemyData Data => _data;


    public EnemyStateData(Enemy _enemy, EnemyData _data, SpriteRenderer _spriteRenderer)
    {
        this._enemy = _enemy;

        this._data = _data;

        this._spriteRenderer = _spriteRenderer;
    }
}