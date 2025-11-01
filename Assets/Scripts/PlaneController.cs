using UnityEngine;

public class PlaneController : PlayerController //INHERITANCE
{
    private float secondHorizontalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        secondHorizontalInput = Input.GetAxis("Horizontal1");

        Move();
        SpecialMove();

        if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        } 
    }

    // POLYMORPHISM
    protected override void Move()
    {
        // Move the plane forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // Rotate the plane to upward and downward
        transform.Rotate(Vector3.right * Time.deltaTime * forwardInput * speed);
        // Rotate the plane to left and right
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
    }

    protected override void SpecialMove()
    {
        // Rotate the plane to the side
        transform.Rotate(Vector3.back * Time.deltaTime * secondHorizontalInput * turnSpeed);
    }
}
