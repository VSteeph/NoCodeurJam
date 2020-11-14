using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeShotAbility : ShotAbility
{
    // Start is called before the first frame update
    void Start()
    {
        base.Init();
        characterManager.onShot += PerformShot;
    }

    // Update is called once per frame
    private void PerformShot()
    {
        base.PrepareShot();
        var direction = Vector3.Normalize(characterManager.direction);
        Debug.DrawRay(transform.position, direction);
        RaycastHit2D hit = Physics2D.Raycast(bulletSpawnPoint.position + (direction / 1.2f), direction, characterManager.loadedBullet.range);
        if(hit.collider != null)
        {
            if(gameObject == hit.collider.gameObject)
            {
                return;
            }
            else
            {
                var targetCharacterManager = hit.collider.GetComponent<CharacterManager>();
                if(targetCharacterManager != null )
                {
                    targetCharacterManager.OnHit(characterManager.loadedBullet.damage, transform.position);
                }
            }
        }
    }
}
