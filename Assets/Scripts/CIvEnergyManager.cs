using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIvEnergyManager : MonoBehaviour
{
    [Header("Event")]
    public UnityEngine.Events.UnityEvent OnLoss;
    public static int TotalEnergy;
    public int EnergyStartAmount;
    public int CivStartAmount;
    [HideInInspector] public int CivilisationPopulation;
    private bool once = false;
    public static CIvEnergyManager cIvEnergyManager;
    public int CompletedLevels;
    private bool MainMenu;
    private bool Lost;
    void Awake()
    {
        MainMenu = true;
        Reset();
        if(CIvEnergyManager.cIvEnergyManager != null) Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this.gameObject);
            CIvEnergyManager.cIvEnergyManager = this;
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
        if((CIvEnergyManager.TotalEnergy <= 0 || CivilisationPopulation <= 0) && !Lost)
        {
            OnLoss.Invoke();
            CaravanPerished();
        }
        if(CIvEnergyManager.TotalEnergy <= 100 && !once && !MainMenu)
        {
            StartPopulationLoss();
            once = true;
        }
        if(CIvEnergyManager.TotalEnergy >= 100) once = false;
    }

    public void StartPopulationLoss()
    {
        if(CIvEnergyManager.TotalEnergy < 100 && CIvEnergyManager.TotalEnergy >= 40)
        {
            CivilisationPopulation -= 1;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 40 && CIvEnergyManager.TotalEnergy >= 30)
        {
            CivilisationPopulation -= 3;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 30 && CIvEnergyManager.TotalEnergy >= 20)
        {
            CivilisationPopulation -= 6;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 20 && CIvEnergyManager.TotalEnergy >= 10)
        {
            CivilisationPopulation -= 8;
            Invoke("StartPopulationLoss",5);
        }
        else if(CIvEnergyManager.TotalEnergy < 10)
        {
            CivilisationPopulation -= 10;
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
        MainMenu = false;
    }

    public void BackToChoiceMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        MainMenu =true;
    }

    public void Reset()
    {
        TotalEnergy = EnergyStartAmount;
        CivilisationPopulation = CivStartAmount;
        Lost = false;
    }

    public void CaravanPerished()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(10);
        Lost = true;
    }

    public void PlayerPerished()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(11);
        Lost = true;
    }
}
