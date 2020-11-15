using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIvEnergyManager : MonoBehaviour
{
    [Header("Event")]
    public UnityEngine.Events.UnityEvent OnLoss;
    public static int TotalEnergy;
    public int EnergyStartAmount;
    public int CivilisationPopulation;
    private bool once = false;
    public static CIvEnergyManager cIvEnergyManager;
    public int CompletedLevels;

    void Awake()
    {
        if(CIvEnergyManager.cIvEnergyManager != null) Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            CIvEnergyManager.cIvEnergyManager = this;
            TotalEnergy += EnergyStartAmount;
        }
    }

    public void ConsumeEnergy(int amount)
    {
        CIvEnergyManager.TotalEnergy -= amount;
    }

    public void GainEnergy(int amount)
    {
        CIvEnergyManager.TotalEnergy += amount;
    }

    void Update()
    {
        if(CIvEnergyManager.TotalEnergy <= 0 || CivilisationPopulation <= 0)
        {
            OnLoss.Invoke();
        }
        if(CIvEnergyManager.TotalEnergy <= 50 && !once)
        {
            StartPopulationLoss();
            once = true;
        }
        if(CIvEnergyManager.TotalEnergy > 50) once = false;
    }

    public void StartPopulationLoss()
    {
        if(CIvEnergyManager.TotalEnergy < 50 && CIvEnergyManager.TotalEnergy >= 40)
        {
            CivilisationPopulation -= 1;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 40 && CIvEnergyManager.TotalEnergy >= 30)
        {
            CivilisationPopulation -= 2;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 30 && CIvEnergyManager.TotalEnergy >= 20)
        {
            CivilisationPopulation -= 3;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 20 && CIvEnergyManager.TotalEnergy >= 10)
        {
            CivilisationPopulation -= 4;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 10)
        {
            CivilisationPopulation -= 5;
            Invoke("StartPopulationLoss",5);
        }
    }

    public void LevelComplete()
    {
        CompletedLevels++;
    }

    public void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(CompletedLevels+1);
    }

    public void BackToChoiceMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
