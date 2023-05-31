using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private State _currentState = null;

    [SerializeField] private float _moveSpeed = 0.00f;
    [SerializeField] private float _airMoveSpeed = 0.00f;

    [SerializeField] private float _jumpForce = 0.00f;
    [SerializeField] private float _attackRange = 0.00f;

    [SerializeField] private int _damage = 0;

    [SerializeField] private LayerMask _layerMask = 0;


    public float MoveSpeed => _moveSpeed;
    public float AirMoveSpeed => _airMoveSpeed;
    public float JumpForce => _jumpForce;
    public float AttackRange => _attackRange;
    public int Damage => _damage;

    public LayerMask HitMask => _layerMask;


    private CharacterStateData _stateData = null;

    public void Initialize(CharacterStateData _stateData)
    {
        this._stateData = _stateData;

        SetState<CharacterIdleState>();
    }


    public void Tick()
    {
        _currentState?.Tick();

        _stateData.Renderer.flipX = GetMoveDirection().Equals(Vector2.zero) ? _stateData.Renderer.flipX : (GetMoveDirection().x < 0 ? true : false);

        if (Input.GetKeyDown(KeyCode.Mouse0) && !_currentState.GetType().Equals(typeof(CharacterAttackState)))
            SetState<CharacterAttackState>();
    }

    public void FixedTick()
    {
        _currentState?.FixedTick();
    }

    public void SetState<T>() where T : State
    {
        _currentState?.Exit();

        _currentState = CreateInstance<T>();

        _currentState?.Enter(_stateData);
    }

    public Vector2 GetMoveDirection() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
}
public class CharacterStateData
{
    private Character_Controller _controller = null;
    private Character _character = null;
    private Animator _animator = null;
    private Rigidbody2D _rigidBody2D = null;
    private SpriteRenderer _renderer = null;

    public Character_Controller Controller => _controller;
    public Character Character => _character;
    public Animator Animator => _animator;
    public Rigidbody2D RigidBody2D => _rigidBody2D;
    public SpriteRenderer Renderer => _renderer;

    public CharacterStateData(Character_Controller _controller, Character _character, Animator _animator, Rigidbody2D _rigidBody2D, SpriteRenderer _renderer)
    {
        this._controller = _controller;
        this._character = _character;
        this._animator = _animator;
        this._rigidBody2D = _rigidBody2D;
        this._renderer = _renderer;
    }
}