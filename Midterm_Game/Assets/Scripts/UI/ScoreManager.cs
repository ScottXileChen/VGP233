using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Singleton

    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    int Score = 0;
    public Text m_MyText;

    public void AddScore(int point)
    {
        Score += point;
    }
    void Start()
    {
        m_MyText.text = "Score: " + Score.ToString();
    }

    void Update()
    {
        m_MyText.text = "Score: " + Score.ToString();
    }

}
