using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float moveSpeed = 4f;
    public int damage = 10;
    private float hitTime = 2f;
    private float hitTimer = 0f;
    private void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hitTimer -= Time.deltaTime;
            if (hitTimer <= 0)
            {
                hitTimer = hitTime;
                PlayerManager.instance.player.GetComponent<PlayerState>().TakeDamage(damage);
            }
        }
    }
}
