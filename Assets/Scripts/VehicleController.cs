using UnityEngine;

// INHERITANCE
public class VehicleController : PlayerController
{
    [SerializeField] private VehicleJump vehicleJump;
    [SerializeField] private float laneDistance = 5f;
    [SerializeField] private float tiltAngle = 15f;
    [SerializeField] private float tiltSpeed = 8f;
    private int currentLane = 0;
    private float targetRotationY = 0f;

    

    // Update is called once per frame
    void Update()
    {   
        Move();

        // move smoothly
        Vector3 pos = transform.position;
        float targetX = currentLane * laneDistance;
        pos.x = Mathf.MoveTowards(pos.x, targetX, speed * Time.deltaTime);
        transform.position = pos;

        // rotate smoothly
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, targetRotationY, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);

        // make straigh on y
        if (Mathf.Abs(pos.x - targetX) < 0.05f)
            targetRotationY = 0f;

        if(Input.GetKeyDown(KeyCode.C))
            SwitchCamera();

        if(Input.GetKeyDown(KeyCode.Space))
            SpecialMove();    
    }

    // POLYMORPHISM  
    protected override void Move()
    {
        // Move the player to the left and right
        if (Input.GetKeyDown(KeyCode.A) && currentLane > -1)
        {
            currentLane--;
            targetRotationY = -tiltAngle;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 1)
        {
            currentLane++;
            targetRotationY = tiltAngle;
        }
    }

    // POLYMORPHISM
    protected override void SpecialMove()
    {
        vehicleJump.isOnGrand = false;
        vehicleJump.Jump();
    } 
}
