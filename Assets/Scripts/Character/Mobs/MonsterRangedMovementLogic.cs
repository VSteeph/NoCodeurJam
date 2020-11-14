using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRangedMovementLogic : MonsterBaseMovementLogic
{
    public override Vector3 CalculateDistanceWithTarget(Vector3 monsterPos, Vector3 targetPos)
    {
        var targetDirection = targetPos - monsterPos;
        return targetDirection;
    }
}
