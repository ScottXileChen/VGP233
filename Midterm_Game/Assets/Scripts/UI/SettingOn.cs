using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingOn : MonoBehaviour
{
    public GameObject setting;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            setting.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
