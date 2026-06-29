using UnityEngine;

// INHERITANCE
public class VehicleController : PlayerController
{
    //[SerializeField] private Animator carAnim;
    [SerializeField] private VehicleJump vehicleJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

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
    protected override void SpecialMove()
    {
        vehicleJump.isOnGrand = false;
        vehicleJump.Jump();
    } 
}
