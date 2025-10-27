using UnityEngine;

public class PlaneController : PlayerController //INHERITANCE
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCamera();
        } 
    }
}
