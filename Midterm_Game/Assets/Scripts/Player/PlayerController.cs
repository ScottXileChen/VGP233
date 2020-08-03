using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(ConfigurableJoint))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotateSensitivity;
    [SerializeField]
    private float thrusterForce;

    [Header("Spring Settings:")]
    [SerializeField]
    private float jointSpring;
    [SerializeField]
    private float jointMaxForce;

    private PlayerMotor motor;
    private ConfigurableJoint joint;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();
        speed = 5f;
        rotateSensitivity = 10f;
        thrusterForce = 1500f;
        jointSpring = 20f;
        jointMaxForce = 40f;
        SetJointSettings(jointSpring);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");    
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveHorizontal = transform.right * horizontal;
        Vector3 moveVertical = transform.forward * vertical;

        // Find movement vector
        // (moveHorizontal + moveVertical).normalized got direction
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        // Apply movement
        motor.Move(velocity);



        // Calculate rotation ---  Only rotating base on Y axis
        float rotationY = Input.GetAxis("Mouse X");

        Vector2 rotationVector = new Vector3(0f, rotationY, 0f) * rotateSensitivity;

        // Apply rotation
        motor.Rotate(rotationVector);

        // Calculate rotation ---  Camera rotation based on X axis
        float rotationX = Input.GetAxis("Mouse Y");

        float cameraRotationVectorX = rotationX * rotateSensitivity;

        // Apply rotation
        motor.CameraRotate(cameraRotationVectorX);

        Vector3 ThrusterForce = Vector3.zero;
        // Calculate the thrusterforce based on player input
        if (Input.GetButton("Jump"))
        {
            ThrusterForce = Vector3.up * thrusterForce;
            SetJointSettings(0f);
        }
        else
        {
            SetJointSettings(jointSpring);
        }

        // Apply the thruster force
        motor.ApplyThruster(ThrusterForce);
    }

    private void SetJointSettings(float JointSpring)
    {
        joint.yDrive = new JointDrive { positionSpring = jointSpring, maximumForce = jointMaxForce };
    }
}
