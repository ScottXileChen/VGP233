using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //public PlayerWeapon playerWeapon;

    [SerializeField]
    private GameObject bulletPrefab = null;

    [SerializeField]
    private GameObject gun = null;

    [SerializeField]
    private Camera cam = null;

    [SerializeField]
    private LayerMask mask;

    [SerializeField]
    private GameObject shootingEffect = null;

    private void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        //RaycastHit hit;
        //if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, playerWeapon.range, mask))
        //{
        //    Debug.Log("We hit " + hit.collider.name);
        //}
        // Shooting effect
        Instantiate(shootingEffect, gun.transform.position, gun.transform.rotation);

        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = gun.transform.position + cam.transform.forward;
        bulletObject.transform.forward = cam.transform.forward;
    }
}
