using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter {

    protected ICharacterAttr _attr;
    protected GameObject _gameObject;
    protected NavMeshAgent _navMeshAgent;
    protected AudioSource _audioSource;
    protected Animation _anim;
    protected IWeapon _weapon;

    public IWeapon weapon { set { _weapon = value; } }
    public Vector3 position {
        get
        {
            if (_gameObject == null)
            {
                Debug.LogWarning("_gameObject is null");
                return Vector3.zero;
            }
            return _gameObject.transform.position;
        }
    }

    public float atkRange { get { return _weapon.atkRange; } }

    public void Attack(ICharacter target)
    {
        //TODO
        _weapon.Fire(target.position);
    }

    public void PlayAnim(string animName)
    {
        _anim.CrossFade(animName);
    }

    public void MoveTo(Vector3 targetPosition)
    {
        _navMeshAgent.SetDestination(targetPosition);
    }
}
