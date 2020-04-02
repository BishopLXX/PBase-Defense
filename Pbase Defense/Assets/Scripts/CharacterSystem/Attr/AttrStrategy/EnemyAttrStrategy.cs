using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttrStrategy : IAttrStrategy
{
    public int GetCritDmg(int critRate)
    {
        return Random.Range(0, 1f) < critRate ?  (int)(10 * Random.Range(0, 1f)) : 0;
    }

    public int GetDmgDescValue(int lv)
    {
        return 0;
    }

    public int GetExtraHPValue(int lv)
    {
        return 0;
    }
}
