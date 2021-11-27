using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float damage = 10f;
    float range = 100f;
    float impactForce = 500f;

    public Camera playerCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public Animator gunAnimator;

    public LayerMask PlayerLayer;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        gunAnimator.SetTrigger("Shoot");
        

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range, ~PlayerLayer))
        {
            GameObject bulletEffect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(bulletEffect, 2f);
           if (hit.rigidbody != null)
           {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
           }
        }
    }
}
