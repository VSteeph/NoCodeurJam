using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeShotAbility : ShotAbility
{
    // Start is called before the first frame update
    void Start()
    {
        base.Init();
    }

    // Update is called once per frame
    private void PerformShot()
    {
        base.PrepareShot();
        Debug.Log("hello melee");
    }
}
