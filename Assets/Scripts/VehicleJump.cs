using UnityEngine;

public class VehicleJump : MonoBehaviour
{
    public bool isOnGrand = true;
    //[SerializeField] private Rigidbody vehicleRb;
    //[SerializeField] private float jumpForce = 2000;
    private Animator carAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //vehicleRb = GetComponent<Rigidbody>();
        carAnim = GetComponent<Animator>();
    }

    void Update()
    {
        //if (isOnGrand)
          //  carAnim.SetBool("isSelected", false);
    }

    public void Jump()
    {
        carAnim.SetBool("isSelected", true);
        //if (isOnGrand)
            //vehicleRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGrand = true; 
        carAnim.SetBool("isSelected", false);   
    }
}
