using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int TotalPoints;
    // Start is called before the first frame update
    void Start()
    {
        TotalPoints = 0;
    }

    public void GetPoint(int point)
    {
        TotalPoints += point;
    }
}
