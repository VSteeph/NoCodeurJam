using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAbility : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private CharacterManager characterManager;

    private float shotTimer = 0;

    protected virtual void Init()
    {
        if (characterManager == null)
            characterManager = this.GetComponent<CharacterManager>();
        characterManager.onShot += PerformShot;
    }
    void Start()
    {
        Init();
    }

    protected virtual void PrepareShot()
    {
        shotTimer = 0;
        StartCoroutine(StartShotCooldown());
    }

    private void PerformShot()
    {
        PrepareShot();
        var generatedProjectile = Instantiate(projectile, bulletSpawnPoint.position, Quaternion.identity);
        var projectileBrain = generatedProjectile.GetComponent<Projectile>();
        projectileBrain.InitializeProjectile(characterManager.loadedBullet, characterManager.GetAim());
    }

    protected IEnumerator StartShotCooldown()
    {
        while (shotTimer < characterManager.shotCooldown)
        {
            shotTimer += Time.deltaTime;
            yield return null;
        }
        if (shotTimer > characterManager.shotCooldown)
        {
            Debug.Log("can shot again");
            characterManager.AfterShot();
            characterManager.canShot = true;
        }
    }
}
