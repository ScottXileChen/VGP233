using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemy;
    public GameObject target;

    private float radius = 80f;
    private float respawnTime = 5f;
    private float timer = 0;

    private void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if (distance <= radius)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Instantiate(enemy, transform.position, transform.rotation);
                timer = respawnTime;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
