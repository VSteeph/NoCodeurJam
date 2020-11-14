using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static AvatarManager avatarManager;
    public static GameObject Player;
    public GameObject player;

    private void Awake()
    {
        Player = player;
    }
}
