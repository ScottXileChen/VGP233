using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    private int HealthLimit = 100;
    public int Health = 100;
    public int AttackPower = 5;
    private int heal = 5;

    private float healTime = 5f;
    private float healTimer = 5f;


    private void Update()
    {
        healTimer -= Time.deltaTime;
        if(Health > 0 && Health + heal < HealthLimit && healTimer <=0)
        {
            Health += heal;
            healTimer = healTime;
        }

       // if (Health <= 0)
            //Destroy(gameObject);

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
