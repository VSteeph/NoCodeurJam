using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartouchesSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject Cartouche;
    [Header("Refs")]
    [SerializeField] private GunAim aim;
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private float cartoucheTravelCoeff;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private bool Robot;

    void Start()
    {
        if(!Robot) characterManager.onShot += SpawnCartouche;
        else this.GetComponent<MonsterManager>().onDeath += EnergyPellet;
    }

    public void SpawnCartouche()
    {
        Cartouches cart = Instantiate(this.Cartouche, this.bulletSpawnPoint.position, Quaternion.identity).GetComponent<Cartouches>();
        cart.force = cartoucheTravelCoeff;
        Vector3 dir = new Vector3();
        if(aim) 
        {
            dir = aim.aim.position - this.bulletSpawnPoint.position;
        }
        else dir = new Vector3(Random.value, Random.value);

        if(dir.x >= 0) cart.AimDir = new Vector2(-Random.value,Random.value);
        else cart.AimDir = new Vector2 (Random.value, Random.value);
    }

    public void EnergyPellet()
    {
        int amount = Random.Range(1,7);
        for(int i = 0; i < amount; i++)
        {
            SpawnCartouche();
        }
    }
}
