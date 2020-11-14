using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonManager : MonoBehaviour
{
    [Header("Stats")]
    public int PopulationCost;
    public int PopulationGain;

    public int UpgradeCost;

    public void PopulationGift()
    {
        if(CIvEnergyManager.TotalEnergy > PopulationCost)
        {
            CIvEnergyManager.cIvEnergyManager.ConsumeEnergy(PopulationCost);
            CIvEnergyManager.cIvEnergyManager.CivilisationPopulation += PopulationGain;
        }
    }

    public void UpgradeGift()
    {
        if(CIvEnergyManager.TotalEnergy > UpgradeCost)
        {
            CIvEnergyManager.cIvEnergyManager.ConsumeEnergy(UpgradeCost);
        }
    }

    public void LoadNextLevel()
    {
        CIvEnergyManager.cIvEnergyManager.LoadNextLevel();
    }
}
