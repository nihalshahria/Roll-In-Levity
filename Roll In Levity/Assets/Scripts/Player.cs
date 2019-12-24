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
    //private Rigidbody rigidbody;

    private void Start()
    {
        transform.position = new Vector3(0, -0.8f, 0);
        world = pipeSystem.transform.parent;
        rotater = transform.GetChild(0);
        currentPipe = pipeSystem.SetupFirstPipe();
        SetupCurrentPipe();
        velocity = 4;
        //rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        velocity = velocity + 0.15f * (Time.deltaTime % 10);
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
        /*radius = 0.8f;
        *//*vertical = radius * Mathf.Sin(moveAngle * Mathf.PI / 180);
        horizontal = radius * Mathf.Cos(moveAngle * Mathf.PI / 180);
        transform.position += new Vector3(0, vertical, horizontal);*//*
        
        if(Input.GetKey("d"))
        {

            var vector2 = Random.insideUnitCircle.normalized * radius;
            transform.position += new Vector3(0, vector2.y, vector2.x);
        }
        else if(Input.GetKey("a"))
        {
            {
                moveAngle = moveAngle;
                vertical = radius * Mathf.Sin(moveAngle * Mathf.PI / 180);
                horizontal = radius * Mathf.Cos(moveAngle * Mathf.PI / 180);
                transform.position += new Vector3(horizontal, vertical, 0);
            }
        }*/
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