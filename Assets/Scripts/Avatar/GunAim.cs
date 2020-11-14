using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    [SerializeField] private AvatarManager avatarManager;
    public Transform aim;
    public Transform gun;
    private Plane plane;

    private void Start()
    {
        plane = new Plane(-transform.forward, transform.position);
    }
    void Update()
    {
        avatarManager.mousePosition = GetMouseImpact();
        var angle = GetRadAngleBetweenGunAndPoint(avatarManager.mousePosition);
        gun.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
