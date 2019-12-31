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
    private float radius, horizontal, vertical;
    public float moveAngle;
    public float startVelocity;

    public float[] accelerations;

    private float acceleration;

    private float time;
    public float accelaration;
    //private Rigidbody rigidbody;

    private void Start()
    {
        time = 0;
        //accelaration = 0;
        transform.position = new Vector3(0, -0.8f, 0);
        world = pipeSystem.transform.parent;
        rotater = transform.GetChild(0);
        currentPipe = pipeSystem.SetupFirstPipe();
        SetupCurrentPipe();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if(time % 5 == 0) {
            velocity *= accelaration;
        }
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

    private void velocityChange()
    {
        velocity = 0;
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