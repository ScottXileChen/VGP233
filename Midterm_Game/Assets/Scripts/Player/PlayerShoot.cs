using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //public PlayerWeapon playerWeapon;

    [SerializeField]
    public GameObject bulletPrefab = null;

    [SerializeField]
    public GameObject gun = null;

    [SerializeField]
    private Camera cam = null;

    [SerializeField]
    private LayerMask mask;

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
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = gun.transform.position + cam.transform.forward;
        bulletObject.transform.forward = cam.transform.forward;
    }

}
