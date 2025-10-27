using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    protected float horizontalInput;
    protected float forwardInput;

    public Camera mainCamera;
    public Camera hoodCamera;

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

    // ABSTRACTION
    protected virtual void Move()
    {
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        // Rotate the vehicle to left and right
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * forwardInput * turnSpeed);
    }

    protected void SwitchCamera()
    {
        // Switch between hood and main camera
        mainCamera.enabled = !mainCamera.enabled;
        hoodCamera.enabled = !hoodCamera.enabled;
    }
}
