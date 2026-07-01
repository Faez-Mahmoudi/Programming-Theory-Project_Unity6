using UnityEngine;

// INHERITANCE
public class VehicleController : PlayerController
{
    [SerializeField] private VehicleJump vehicleJump;
    private Vector3 offset = new Vector3(5f, 0f, 0f);

    //private Vector3 targetPosition;
    [SerializeField] private float laneDistance = 5f;
    private int currentLane = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        Move();

        // move smoothly
        //transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        Vector3 pos = transform.position;

        float targetX = currentLane * laneDistance;

        pos.x = Mathf.MoveTowards(pos.x, targetX, speed * Time.deltaTime);

        transform.position = pos;

        if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpecialMove();   
        }  
    }

    // POLYMORPHISM  
    protected override void Move()
    {
        // Move the player to the left and right
        if (Input.GetKeyDown(KeyCode.A) && currentLane > -1)
            currentLane--;
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 1)
            currentLane++;

    }

    // POLYMORPHISM
    protected override void SpecialMove()
    {
        vehicleJump.isOnGrand = false;
        vehicleJump.Jump();
    } 
}
