using UnityEngine;

public class ArmorVehicle : PlayerController // INHERITTANCE
{
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

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCamera();
        } 
    }
}
