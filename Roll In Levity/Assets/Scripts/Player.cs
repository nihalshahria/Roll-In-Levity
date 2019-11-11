using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationVelocity;
    public PipeSystem pipeSystem;
    public float velocity;
    private Pipe currentPipe;
    private float distanceTraveled;
    private float deltaToRotation;
    private float systemRotation;
    private Transform world, rotater;
    private float worldRotation, avatarRotation;
    //private Rigidbody rigidbody;

    private void Start()
    {
        world = pipeSystem.transform.parent;
        rotater = transform.GetChild(0);
        currentPipe = pipeSystem.SetupFirstPipe();
        SetupCurrentPipe();
        //rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float delta = velocity * Time.deltaTime;
        distanceTraveled += delta;
        systemRotation += delta * deltaToRotation;

        if (systemRotation >= currentPipe.CurveAngle)
        {
            delta = (systemRotation - currentPipe.CurveAngle) / deltaToRotation;
            currentPipe = pipeSystem.SetupNextPipe();
            SetupCurrentPipe();
            systemRotation = delta * deltaToRotation;
        }

        pipeSystem.transform.localRotation =
            Quaternion.Euler(0f, 0f, systemRotation);

        transform.Rotate(new Vector3(0, 0, -360) * 2 * Time.deltaTime);
        UpdateAvatarRotation();
    }

    private void UpdateAvatarRotation()
    {
        avatarRotation +=
            rotationVelocity * Time.deltaTime * Input.GetAxis("Horizontal");
        if (avatarRotation < 0f)
        {
            avatarRotation += 360f;
        }
        else if (avatarRotation >= 360f)
        {
            avatarRotation -= 360f;
        }
        rotater.localRotation = Quaternion.Euler(avatarRotation, 0f, 0f);
    }

    /*float gMag = 9.8f;
    float moveForce = 5f;
    Vector3 centre = Vector3.zero;
    private Vector2 gDir = Vector3.zero;
    private Vector2 gPer = Vector3.zero;

    void FixedUpdate()
    {
        gDir = transform.position == centre ? -Vector3.up : (transform.position - centre).normalized;
        gPer = new Vector2(gDir.y, -gDir.x);

        rigidbody.AddForce(gDir * gMag, ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.AddForce(-gPer * moveForce);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.AddForce(gPer * moveForce);
        }
    }*/

    private void SetupCurrentPipe()
    {
        deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
        worldRotation += currentPipe.RelativeRotation;
        if (worldRotation < 0f)
        {
            worldRotation += 360f;
        }
        else if (worldRotation >= 360f)
        {
            worldRotation -= 360f;
        }
        world.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
    }
}