using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter {
    protected string _name;
    protected int _maxHP;
    protected float _moveSpeed;

    protected int _currentHP;
    protected GameObject _gameObject;
    protected NavMeshAgent _navMeshAgent;
    protected AudioSource _audioSource;

    protected string _IconSprite;
}
