using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariableFeedbacks : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] Text CivText;
    [SerializeField] Text EnergyText;
    [SerializeField] Image HealthBar;
    private PlayerManager playerManager;
    private int Health;
    private int Civ;
    private int Energy;
    
    void Start()
    {
        playerManager = GameManager.Player.GetComponent<PlayerManager>();
        UpdateDisplay();
    }

    void Update()
    {
        if(Health != playerManager.currentHealth || Civ != CIvEnergyManager.cIvEnergyManager.CivilisationPopulation || Energy != CIvEnergyManager.TotalEnergy)
        {
            UpdateDisplay();
        }
    }

    void UpdateDisplay()
    {
        Health = playerManager.currentHealth;
        if(CIvEnergyManager.cIvEnergyManager != null)
        {
            Civ = CIvEnergyManager.cIvEnergyManager.CivilisationPopulation;
            Energy = CIvEnergyManager.TotalEnergy;
        }
        HealthBar.fillAmount = (float)Health / 20f;
        CivText.text = Civ.ToString();
        EnergyText.text = Energy.ToString();
    }
}
