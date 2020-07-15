using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickupsMovement : MonoBehaviour
{
    private bool _isMoving = false;
    private bool _isRotating = false;
    private bool _isJumping = false;
    public enum PickupColor
    {
        Gold, Red, Blue
    }
    public PickupColor pickupColor;
    public int Point { get; private set; }
    void Start()
    {
        if (pickupColor == PickupColor.Gold)
        {
            _isRotating = true;
            Point = 1;
        }
        else if (pickupColor == PickupColor.Blue)
        {
            _isJumping = true;
            Point = 2;
        }
        else if (pickupColor == PickupColor.Red)
        {
            _isMoving = true;
            Point = 3;
        }
    }

    void Rotation()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void Moving()
    {
        transform.RotateAround(new Vector3(0,0.5f,0), Vector3.up, 100 * Time.deltaTime);
    }

    int buffer = 1;
    void Jumping()
    {
        if (transform.position.y >= 5.0f || transform.position.y <= 1.0f)
            buffer *= -1;

        Vector3 temp = transform.position;
        temp.y += 2 * Time.deltaTime * buffer;

        transform.position = temp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isRotating)
        {
            Rotation();
        }
        else if(_isJumping)
        {
            Jumping();
        }
        else if(_isMoving)
        {
            Moving();
        }
    }
}
