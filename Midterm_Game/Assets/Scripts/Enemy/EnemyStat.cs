﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public int Health = 10;
    public int AttackPower = 5;

    private void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
