using UnityEngine;

public class VehicleJump : MonoBehaviour
{
    public bool isOnGrand = true;
    private Animator carAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carAnim = GetComponent<Animator>();
    }

    public void Jump()
    {
        // set jump animation
        carAnim.SetBool("isSelected", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGrand = true; 
        carAnim.SetBool("isSelected", false);   
    }
}
