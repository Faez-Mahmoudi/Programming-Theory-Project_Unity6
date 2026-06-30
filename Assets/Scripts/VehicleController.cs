using UnityEngine;

// INHERITANCE
public class VehicleController : PlayerController
{
    [SerializeField] private VehicleJump vehicleJump;
    private Vector3 offset = new Vector3(5f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        Move();

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
        if (Input.GetKeyDown(KeyCode.A) && transform.position != -offset)
            transform.position -= offset;
        else if (Input.GetKeyDown(KeyCode.D) && transform.position != offset)
            transform.position += offset;

    }

    // POLYMORPHISM
    protected override void SpecialMove()
    {
        vehicleJump.isOnGrand = false;
        vehicleJump.Jump();
    } 
}
