using UnityEngine;

public class PlaneController : PlayerController //INHERITANCE
{
    [SerializeField] private GameObject particle; 
    private float secondHorizontalInput;
    private bool isParticleActive = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       particle.gameObject.SetActive(false); 
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        secondHorizontalInput = Input.GetAxis("Horizontal1");

        Move();

        if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        } 

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpecialMove();
            isParticleActive = !isParticleActive;
        } 
    }

    // POLYMORPHISM
    protected override void Move()
    {
        // Move the plane forward
        transform.Translate(Vector3.forward * Time.deltaTime * m_Speed);
        // Rotate the plane to upward and downward
        transform.Rotate(Vector3.right * Time.deltaTime * forwardInput * m_Speed);
        // Rotate the plane to left and right
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * turnSpeed);
        // Rotate the plane to the side
        transform.Rotate(Vector3.back * Time.deltaTime * secondHorizontalInput * turnSpeed);
    }

    protected override void SpecialMove()
    {
        particle.gameObject.SetActive(!isParticleActive);
    }
}
