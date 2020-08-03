using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rigidbody;
    [SerializeField]
    private float MaxSpeed = 0;
    [SerializeField]
    private float Accelerate = 0;

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(vertical, 0.0f, horizontal);
        
        rigidbody.AddForce(force * Time.deltaTime * Accelerate);
    }
}
