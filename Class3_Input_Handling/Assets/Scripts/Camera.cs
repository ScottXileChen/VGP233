using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject target;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.y;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y + offset, target.transform.position.z);
    }
}
