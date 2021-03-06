﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Header("Refs")]
    public static GameObject Player;
    public static RobotManager Robot;
    public GameObject player;
    public RobotManager robot;
    public bool autoRespawn = false;

    private void Awake()
    {
        Player = player;
        Robot = robot;
    }

    private void Start()
    {
        var PlayerManager = player.GetComponent<PlayerManager>();
        CIvEnergyManager.cIvEnergyManager.SyncCharacterStats(PlayerManager, Robot);
        if(!autoRespawn)
        {
            PlayerManager.onDeath += CIvEnergyManager.cIvEnergyManager.PlayerPerished;
        }
        else
        {
            PlayerManager.ActivateAutoRespawn();
        }

    }


}
