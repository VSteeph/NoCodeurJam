using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChangeScene : MonoBehaviour
{
    public bool Caravan;
    void Update()
    {
        if(Input.anyKeyDown)
        {
            if(Caravan) CIvEnergyManager.cIvEnergyManager.Reset();
            CIvEnergyManager.cIvEnergyManager.BackToChoiceMenu();
        }
    }
}
