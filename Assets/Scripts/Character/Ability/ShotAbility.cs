using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAbility : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private CharacterManager characterManager;

    void Start()
    {
        if (characterManager == null)
            characterManager = this.GetComponent<CharacterManager>();
        characterManager.onShot += PerformShot;
    }

    private void PerformShot()
    {
        var generatedProjectile = Instantiate(projectile, bulletSpawnPoint.position, Quaternion.identity);
        var projectileBrain = generatedProjectile.GetComponent<Projectile>();
        projectileBrain.InitializeProjectile(characterManager.loadedBullet, characterManager.GetAim());
    }
}
