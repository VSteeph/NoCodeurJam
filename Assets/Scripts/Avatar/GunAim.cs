using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{
    public bool player;
    void Update()
    {
        if(player)
        {
            Vector3 MousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
            float angle = Vector3.Angle(this.transform.parent.position-this.transform.parent.right, this.transform.parent.position-MousePos);
            this.transform.rotation = Quaternion.Euler(0.0f,0.0f, angle);
            this.transform.LookAt(MousePos, this.transform.forward);
        }
    }
}
