using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFeedback : FeedbackManager
{
    // guns
    [Header("Gun Feedback")]
    public bool hasGuns;
    [SerializeField] private Transform gunVisual;
    [SerializeField] private Vector3 gunRecoilDistance;
    [SerializeField] private float gunRecoilSeedCoeff;
    private float gunMoveTimer = 0;
    private Vector3 gunInitalLocalPosition;
    private int recoilPhase = 0;
    [SerializeField] private SpriteRenderer muzzleFlash;
    [SerializeField] private Color muzzleColor;
    [SerializeField] private int muzzleFramesDuration;
    private int muzzleFramesCount;


    // Start is called before the first frame update
    void Start()
    {
        characterManager.onShot += SmallCameraShake;
        if (hasGuns)
        {
            gunInitalLocalPosition = gunVisual.localPosition;
            characterManager.onShot += ShakeWeapon;
            characterManager.onShot += MuzzleFlash;
        }
    }

    private void SmallCameraShake()
    {
        CameraShake.ShakeCamera(5, 0.1f);
    }

    private void ShakeWeapon()
    {
        gunMoveTimer = 0;
        recoilPhase = 0;
        StartCoroutine(ShakingWeapon());
    }

    private IEnumerator ShakingWeapon()
    {
        while (recoilPhase == 0)
        {
            gunMoveTimer += Time.deltaTime * gunRecoilSeedCoeff;
            gunVisual.localPosition = Vector2.Lerp(gunVisual.localPosition, gunInitalLocalPosition - gunRecoilDistance, gunMoveTimer);
            if (gunMoveTimer > 1)
            {
                gunVisual.localPosition = gunInitalLocalPosition - gunRecoilDistance;
                recoilPhase++;
                gunMoveTimer = 0;
            }
            yield return null;
        }
        while (recoilPhase == 1)
        {
            gunMoveTimer += Time.deltaTime * gunRecoilSeedCoeff;
            gunVisual.localPosition = Vector2.Lerp(gunVisual.localPosition, gunInitalLocalPosition, gunMoveTimer);

            if (gunMoveTimer > 1)
            {
                gunVisual.localPosition = gunInitalLocalPosition;
                recoilPhase++;
            }
        }
    }

    private void MuzzleFlash()
    {
        muzzleFramesCount = 0;
        muzzleFlash.color = muzzleColor;
        StartCoroutine(MuzzleFlashSpawn());
    }

    private IEnumerator MuzzleFlashSpawn()
    {
        while (muzzleFramesCount < muzzleFramesDuration)
        {
            muzzleFramesCount++;
            if (muzzleFramesCount == muzzleFramesDuration)
            {
                muzzleFlash.color = new Color(0, 0, 0, 0);
            }
            yield return null;
        }
    }
}
