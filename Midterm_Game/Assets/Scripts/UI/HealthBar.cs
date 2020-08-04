using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    int health;
    public Text m_MyText;

    void Start()
    {
        health = player.GetComponent<PlayerState>().Health;
        m_MyText.text = "Health: " + health.ToString();

    }

    void Update()
    {
        health = player.GetComponent<PlayerState>().Health;
        m_MyText.text = "Health: " + health.ToString();
    }

}
