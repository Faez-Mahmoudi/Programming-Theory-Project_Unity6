using UnityEngine;

// INHERITANCE
public class VehicleController : PlayerController
{
    private Rigidbody vehicleRb;
    [SerializeField] private float jumpForce = 2000;
    [SerializeField] private bool isOnGrand = true;
    private Animator carAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        carAnim = GetComponent<Animator>();
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

        if(Input.GetKeyDown(KeyCode.Space) && isOnGrand)
        {
            SpecialMove();
            isOnGrand = false;
        }  
    }

    // POLYMORPHISM
    protected override void SpecialMove()
    {
        vehicleRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        carAnim.SetBool("isSelected", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGrand = true;
        carAnim.SetBool("isSelected", false);
    }
}
