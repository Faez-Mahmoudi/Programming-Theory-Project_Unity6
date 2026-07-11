using UnityEngine;

public class ArmorVehicle : PlayerController // INHERITTANCE
{
    [SerializeField] private GameObject armor;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject focalPoint;
    //[SerializeField] private float armorSpeed = 50.0f;
    private float secondHorizontalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        secondHorizontalInput = Input.GetAxis("Horizontal1");

        Move();

        if(Input.GetKeyDown(KeyCode.Space))
            SpecialMove();
        
        if(Input.GetKeyDown(KeyCode.C))
            SwitchCamera();
    }

    // POLYMORPHISM
    protected override void Move()
    {
        if (transform.rotation != focalPoint.transform.rotation)
        {
            //Quaternion targetRotation = Quaternion.Euler(focalPoint.transform.eulerAngles.x, 0f, focalPoint.transform.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            Debug.Log("That's the point");
            base.Move();
                    
            armor.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * -horizontalInput);
        }
        else
            base.Move();
            
        // Spin the vehicle's armor to the right/left
        armor.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * secondHorizontalInput);
    }

    protected override void SpecialMove()
    {
        Instantiate(projectilePrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
