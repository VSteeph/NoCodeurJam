using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvatarManager))]
public class AvatarShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private AvatarManager avatarManager;

    void Start()
    {
        avatarManager = this.GetComponent<AvatarManager>();
        avatarManager.onShot += PerformShot;
    }

    private void PerformShot()
    {
        var generatedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        var projectileSettings = generatedProjectile.GetComponent<Projectile>();

        projectileSettings.direction = avatarManager.mousePosition;
    }
}
