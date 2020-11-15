using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonManager : MonoBehaviour
{
    [Header("Stats")]
    public int PopulationCost;
    public int PopulationGain;

    public int UpgradeCost;
    [Header("Refs")]
    [SerializeField] private Text Population;
    [SerializeField] private Text EnergyDisplay;

    private void Start()
    {
        UpdateDisplay();
    }

    public void PopulationGift()
    {
        if(CIvEnergyManager.TotalEnergy >= PopulationCost)
        {
            CIvEnergyManager.cIvEnergyManager.ConsumeEnergy(PopulationCost);
            CIvEnergyManager.cIvEnergyManager.CivilisationPopulation += PopulationGain;
        }
        UpdateDisplay();
    }

    public void UpgradeGift()
    {
        if(CIvEnergyManager.TotalEnergy >= UpgradeCost)
        {
            CIvEnergyManager.cIvEnergyManager.ConsumeEnergy(UpgradeCost);
        }
        UpdateDisplay();
    }

    public void LoadNextLevel()
    {
        CIvEnergyManager.cIvEnergyManager.LoadNextLevel();
    }

    public void UpdateDisplay()
    {
        Population.text = CIvEnergyManager.cIvEnergyManager.CivilisationPopulation.ToString();
        EnergyDisplay.text = CIvEnergyManager.TotalEnergy.ToString();
    }
}
