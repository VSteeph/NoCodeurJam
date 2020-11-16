using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

public class CIvEnergyManager : MonoBehaviour
{
    [Header("Event")]
    public UnityEngine.Events.UnityEvent OnLoss;
    [Header("Stats")]
    public float TimerInterval = 1;
    public static int TotalEnergy;
    public int EnergyStartAmount;
    public int CivStartAmount;
    [HideInInspector] public int CivilisationPopulation;
    private bool once = false;
    public static CIvEnergyManager cIvEnergyManager;
    public int CompletedLevels;
    private bool MainMenu;
    private bool Lost;

    //Upgrade
    [HideInInspector] public float speed;
    [SerializeField] public float speedPlayerIncrease;
    [HideInInspector] public int health;
    [SerializeField] public int hpPlayerIncrease;
    [HideInInspector] public float lifeDurationBullet;
    [SerializeField] public float lifeDurationBulletIncrease;
    [HideInInspector] public float speedBullet;
    [SerializeField] public float speedBulletIncrease;
    [HideInInspector] public int damageBullet;
    [SerializeField] public int damageBulletIncrease;
    [HideInInspector] public float shootCooldown;
    [SerializeField] public float shootCooldownIncrease;
    [HideInInspector] public float dodgeCooldown;
    [SerializeField] public float dodgeCooldownIncrease;
    [HideInInspector] public int dodgeDuration;
    [SerializeField] public int dodgeDurationIncrease;
    [HideInInspector] public float pushBackOnHit;
    [SerializeField] public float pushBackMonsterIncrease;
    [Header("Refs")]
    [SerializeField] private SceneChanger sceneChanger;

    private Dictionary<string, object> UpgradeWithBasedIncrease;
    private System.Random rand = new System.Random();

    private string lastMessage;

    void Awake()
    {
        GenerateUpgrade();
        MainMenu = true;
        if(CIvEnergyManager.cIvEnergyManager != null) Destroy(this.gameObject);
        else
        {
            Reset();
            DontDestroyOnLoad(this.gameObject);
            CIvEnergyManager.cIvEnergyManager = this;
            StartPopulationLoss();
        }
    }

    private void GenerateUpgrade()
    {
        UpgradeWithBasedIncrease = new Dictionary<string, object>();
        UpgradeWithBasedIncrease.Add("speed", speedPlayerIncrease);
        UpgradeWithBasedIncrease.Add("health", hpPlayerIncrease);
        UpgradeWithBasedIncrease.Add("lifeDurationBullet", lifeDurationBulletIncrease);
        UpgradeWithBasedIncrease.Add("speedBullet", speedBulletIncrease);
        UpgradeWithBasedIncrease.Add("damageBullet", damageBulletIncrease);
        UpgradeWithBasedIncrease.Add("shootCooldown", shootCooldownIncrease);
        UpgradeWithBasedIncrease.Add("dodgeCooldown", dodgeCooldownIncrease);
        UpgradeWithBasedIncrease.Add("dodgeDuration", dodgeDurationIncrease);
        UpgradeWithBasedIncrease.Add("pushBackOnHit", pushBackMonsterIncrease);

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
        if((CivilisationPopulation <= 0) && !Lost)
        {
            OnLoss.Invoke();
            CaravanPerished();
        }
    }

    public void StartPopulationLoss()
    {
        if(!MainMenu)
        {
            if(CIvEnergyManager.TotalEnergy >= 40)
            {
                CivilisationPopulation -= 1;
            }
            else if(CIvEnergyManager.TotalEnergy < 40 && CIvEnergyManager.TotalEnergy >= 30)
            {
                CivilisationPopulation -= 3;
            }
            else if(CIvEnergyManager.TotalEnergy < 30 && CIvEnergyManager.TotalEnergy >= 20)
            {
                CivilisationPopulation -= 6;
            }
            else if(CIvEnergyManager.TotalEnergy < 20 && CIvEnergyManager.TotalEnergy >= 10)
            {
                CivilisationPopulation -= 8;
            }
            else if(CIvEnergyManager.TotalEnergy < 10)
            {
                CivilisationPopulation -= 10;
            }
        }
        Invoke("StartPopulationLoss",TimerInterval);
        
    }

    public void LevelComplete()
    {
        CompletedLevels++;
    }

    public void LoadNextLevel()
    {
        sceneChanger.LoadScene(CompletedLevels+1);
        MainMenu = false;
    }

    public void BackToChoiceMenu()
    {
        sceneChanger.LoadScene(0);
        MainMenu =true;
        Lost = false;
    }

    public void Reset()
    {
        TotalEnergy = EnergyStartAmount;
        CivilisationPopulation = CivStartAmount;
        Lost = false;
    }

    public void CaravanPerished()
    {
        sceneChanger.LoadScene(10);
        Lost = true;
    }

    public void PlayerPerished()
    {
        sceneChanger.LoadScene(11);
        CivilisationPopulation -= 10;
        Lost = true;
    }

    public void Upgrade()
    {
        var increase = rand.Next(0, UpgradeWithBasedIncrease.Count);
        var element = UpgradeWithBasedIncrease.ElementAt(increase);
        var parameters = this.GetType().GetField(element.Key);
        var oldValue = parameters.GetValue(this);

        if (element.Value is int)
        {
            var newValue = (int)parameters.GetValue(this) + (int)element.Value;
            parameters.SetValue(this, newValue);
            lastMessage = element.Key + " was upgraded from " + oldValue + " to " + newValue;
        }
        else
        {
            var newValue = (float)parameters.GetValue(this) + (float)element.Value;
            parameters.SetValue(this, newValue);
            lastMessage = element.Key + " was upgraded from " + oldValue + " to " + newValue;
        }
        
    }

    public string GetLastMessage()
    {
        return lastMessage;
    }

    public void SyncCharacterStats(PlayerManager player, RobotManager robot)
    {
        foreach (KeyValuePair<string, object> entry in UpgradeWithBasedIncrease)
        {
            Debug.Log("update");
            switch (entry.Key)
            {
                case ("speed"):
                    player.speed += (float)GetValue(entry.Key);
                    break;

                case ("health"):
                    player.currentHealth += (int)GetValue(entry.Key);
                    break;

                case ("lifeDurationBullet"):
                    player.loadedBullet.lifeDuration += (float)GetValue(entry.Key);
                    break;

                case ("speedBullet"):
                    player.loadedBullet.speed += (float)GetValue(entry.Key);
                    break;

                case ("damageBullet"):
                    player.loadedBullet.damage += (int)GetValue(entry.Key);
                    break;

                case ("shootCooldown"):
                    player.shotCooldown += (float)GetValue(entry.Key);
                    break;

                case ("dodgeCooldown"):
                    player.dodgeCooldown += (float)GetValue(entry.Key);
                    break;

                case ("dodgeDuration"):
                    player.dodgeDurationInFrames += (int)GetValue(entry.Key);
                    break;

                case ("pushBackOnHit"):
                    robot.SyncEveryRobotPushBack((float)GetValue(entry.Key));
                    break;


                default:
                    break;
            }

        }
    }


    public object GetValue(string key)
    {
        var parameters = this.GetType().GetField(key);
        return parameters.GetValue(this);
    }
}
