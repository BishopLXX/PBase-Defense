using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon {
    protected int _atk;
    protected float _atkRangle;
    /// <summary>
    /// 暴击率
    /// </summary>
    protected int _AtkPlusValue;

    protected GameObject _gameObject;
    protected ICharacter _owner;
    protected ParticleSystem _pariticle;
    protected LineRenderer _line;
    protected Light _light;
    protected AudioSource _audio;

    protected float _effectDisplayTime = 0;

    public float atkRange { get { return _atkRangle; } }

    public void Update()
    {
        if (_effectDisplayTime > 0)
        {
            _effectDisplayTime -= Time.deltaTime;
            if (_effectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    public void Fire(Vector3 targetPosition)
    {
        // 显示枪口特效
        PlayMuzzleEffect();
        // 显示子弹轨迹特效
        PlayBulletEffect(targetPosition);
        // 设置特效显示时间
        SetEffectDisplayTime();
        // 播放开枪音效
        PlaySound();

    }

    protected abstract void SetEffectDisplayTime();

    protected virtual void PlayMuzzleEffect()
    {
        
        _pariticle.Stop();
        _pariticle.Play();
        _light.enabled = true;
    }

    protected abstract void PlayBulletEffect(Vector3 targetPosition);

    protected void DoPlayBulletEffect(float width, Vector3 targetPosition)
    {
        
        _line.enabled = true;
        _line.startWidth = width;
        _line.endWidth = width;
        _line.SetPosition(0, _gameObject.transform.position);
        _line.SetPosition(1, targetPosition);
    }

    protected abstract void PlaySound();

    protected virtual void DoPlaySound(string clipName)
    {
        AudioClip clip = null; //TODO
        _audio.clip = clip;
        _audio.Play();
    }

    private void DisableEffect()
    {
        _line.enabled = false;
        _light.enabled = false;
    }
}
