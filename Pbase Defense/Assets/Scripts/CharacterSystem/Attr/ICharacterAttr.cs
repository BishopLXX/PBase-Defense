using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr {

    protected string _name;
    protected int _maxHP;
    protected float _moveSpeed;
    protected int _currentHP;
    protected string _IconSprite;

    protected int mLv;
    protected float mCritRate; // 0-1 暴击率

    // 增加的最大血量 抵御的伤害值  暴击伤害的伤害
    protected IAttrStrategy _strategy;
}
