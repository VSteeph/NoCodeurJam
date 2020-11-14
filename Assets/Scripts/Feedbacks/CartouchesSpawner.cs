using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartouchesSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject Cartouche;
    [Header("Refs")]
    [SerializeField] private GunAim aim;
    [SerializeField] private AvatarManager avatarManager;

    void Awake()
    {
        avatarManager.onShot += SpawnCartouche;
    }

    public void SpawnCartouche()
    {
        Cartouches cart = Instantiate(this.Cartouche, this.transform.position, Quaternion.identity).GetComponent<Cartouches>();
        Vector3 dir = aim.aim.position - this.transform.position;
        if(dir.x >= 0) cart.AimDir = new Vector2(-Random.value,Random.value);
        else cart.AimDir = new Vector2 (Random.value, Random.value);
    }
}
