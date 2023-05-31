using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Data/Enemy")]
public class EnemyData : ScriptableObject
{

    [SerializeField, Range(0.00f, 20.00f)] private float _moveSpeed = 0.00f;
    [SerializeField, Range(0.00f, 20.00f)] private float _attackRange = 0.00f;
    [SerializeField] private int _damage = 0;
    [SerializeField] private int _initializeHealth = 0;

    [SerializeField] private List<GameObject> _lootList = new List<GameObject>();

    private int _health = 0;


    public float MoveSpeed => _moveSpeed;
    public float AttackRange => _attackRange;
    public int Damage => _damage;

    public int Health { get => _health; set => _health = value; }

    public void Initialize()
    {
        _health = _initializeHealth;
    }
    public bool GetRandomLootDrop(out GameObject _randomObject)
    {
        if (_lootList.Count == 0)
        {
            _randomObject = null;
            return false;
        }


        int randomIndex = Random.Range(0, _lootList.Count);

        _randomObject = _lootList[randomIndex];
        return true;
    }
}