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

    void Start()
    {
        characterManager.onShot += SpawnCartouche;
    }

    public void SpawnCartouche()
    {
        Cartouches cart = Instantiate(this.Cartouche, this.bulletSpawnPoint.position, Quaternion.identity).GetComponent<Cartouches>();
        cart.force = cartoucheTravelCoeff;
        Vector3 dir = aim.aim.position - this.bulletSpawnPoint.position;
        if(dir.x >= 0) cart.AimDir = new Vector2(-Random.value,Random.value);
        else cart.AimDir = new Vector2 (Random.value, Random.value);
    }
}
