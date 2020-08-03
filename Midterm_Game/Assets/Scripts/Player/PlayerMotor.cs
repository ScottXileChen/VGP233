using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam = null;

    private Vector3 velocity;
    private Vector3 rotation;
    private float cameraRotationX;
    private float currentCameraRotationX;
    private Vector3 thrusterForce;

    [SerializeField]
    private float cameraRotationLimit;

    private Rigidbody rb;

    private void Start()
    {
        velocity = Vector3.zero;
        rotation = Vector3.zero;
        cameraRotationX = 0f;
        currentCameraRotationX = 0f;
        thrusterForce = Vector3.zero;
        cameraRotationLimit = 85f;
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Move(Vector3 Velocity)
    {
        velocity = Velocity;
    }
    public void Rotate(Vector3 Rotation)
    {
        rotation = Rotation;
    }
    public void CameraRotate(float CameraRotationX)
    {
        cameraRotationX = CameraRotationX;
    }
    public void ApplyThruster(Vector3 ThrusterForce)
    {
        thrusterForce = ThrusterForce;
    }
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (thrusterForce != Vector3.zero)
        {
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null)
        {
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        }
    }
}
