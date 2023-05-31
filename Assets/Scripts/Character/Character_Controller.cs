using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] private Character _character = null;

    private Animator _animator = null;
    private Rigidbody2D _rigidBody2D = null;
    private SpriteRenderer _renderer = null;

    private CharacterStateData _stateData = null;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position , (transform.localScale.x < 0 ? Vector2.left : Vector2.right) * _character.AttackRange);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();

       // CharacterStateData _stateData = new(this, _character, _animator, _rigidBody2D, _renderer);
       // _character.Initialize(_stateData);

        //_stateData = new CharacterStateData(this, _character, _animator, _rigidBody2D, _renderer);
        //_character.Initialize(_stateData);
    }
    private void Start()
    {
        CharacterStateData _stateData = new(this, _character, _animator, _rigidBody2D, _renderer);
        _character.Initialize(_stateData);
    }

    private void Update()
    {
        _character?.Tick();
    }
  



    private void FixedUpdate()
    {
        _character?.FixedTick();
    }
}