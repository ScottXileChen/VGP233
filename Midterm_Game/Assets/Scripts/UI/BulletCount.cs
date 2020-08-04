using UnityEngine;
using UnityEngine.UI;

public class BulletCount : MonoBehaviour
{
    public GameObject player;
    public Text m_MyText;
    private int bullets;
    void Start()
    {
        bullets = player.GetComponent<PlayerShoot>().bullets;
        m_MyText.text = "Bullets count: " + bullets.ToString();
    }

    void Update()
    {
        bullets = player.GetComponent<PlayerShoot>().bullets;
        bool isreloading = player.GetComponent<PlayerShoot>().isReload;
        int reloadTime = (int)player.GetComponent<PlayerShoot>().reloadTimer;
        if(isreloading)
        {
            m_MyText.text = "Reloading " + reloadTime.ToString() + " s";
        }
        else
        {
            m_MyText.text = "Bullets count: " + bullets.ToString();
        }
    }
}
