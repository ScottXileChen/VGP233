using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (Health <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("LoseUI");
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
