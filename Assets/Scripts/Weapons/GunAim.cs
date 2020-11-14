using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    public Transform aim;
    public Transform gunPivot;
    private Plane plane;
    [SerializeField] private Transform gunVisual;

    private void Start()
    {
        plane = new Plane(-transform.forward, transform.position);
    }
    void Update()
    {
        playerManager.mousePosition = GetMouseImpact();
        var angle = GetRadAngleBetweenGunAndPoint(playerManager.mousePosition);
        gunPivot.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (gunPivot.rotation.z < -0.7 || gunPivot.rotation.z > 0.7)
        {
            gunVisual.localRotation = Quaternion.Euler(180, 0, 0);
        }
        else
        {
            gunVisual.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private Vector3 GetMouseImpact()
    {
        Vector3 hitpoint = Vector3.zero;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;
        if (plane.Raycast(ray, out enter))
        {
            hitpoint = ray.GetPoint(enter);
        }
        return hitpoint;
    }

    private float GetRadAngleBetweenGunAndPoint(Vector3 impactPoint)
    {
        Vector3 normalizedDifference = Vector3.Normalize(impactPoint - aim.position);
        var degreeToRotate = Mathf.Atan2(normalizedDifference.y, normalizedDifference.x) * Mathf.Rad2Deg;
        return degreeToRotate;
    }

}
