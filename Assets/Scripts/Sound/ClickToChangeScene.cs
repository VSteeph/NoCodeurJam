using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChangeScene : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKeyDown)
        {
            CIvEnergyManager.cIvEnergyManager.Reset();
            CIvEnergyManager.cIvEnergyManager.BackToChoiceMenu();
        }
    }
}
