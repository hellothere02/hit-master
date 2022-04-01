using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private GameObject gunTrans;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPref, gunTrans.transform.position, Quaternion.identity);
    }
}
