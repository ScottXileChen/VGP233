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

    private int bulletsNum = 30;
    public int bullets;
    private float reloadTime = 3;
    public float reloadTimer = 0;
    public bool isReload = false;

    private void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }
        bullets = bulletsNum;
        reloadTimer = reloadTime;
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && bullets > 0 && !isReload)
        {
            Shoot();
            bullets--;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            isReload = true;
        }

        if (isReload)
        {
            Reload();
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
        GameObject ShootEffect = Instantiate(shootingEffect, gun.transform.position, gun.transform.rotation);
        ParticleSystem parts = shootingEffect.GetComponent<ParticleSystem>();
        float totalDuration = parts.main.duration + parts.main.startLifetimeMultiplier;
        Destroy(ShootEffect, totalDuration);

        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = gun.transform.position + cam.transform.forward;
        bulletObject.transform.forward = cam.transform.forward;
    }

    void Reload()
    {
        reloadTimer -= Time.deltaTime;
        if (reloadTimer <= 0)
        {
            bullets = bulletsNum;
            reloadTimer = reloadTime;
            isReload = false;
        }
    }

}
