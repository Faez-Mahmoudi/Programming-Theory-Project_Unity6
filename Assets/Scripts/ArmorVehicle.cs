using UnityEngine;

public class ArmorVehicle : PlayerController // INHERITTANCE
{
    [SerializeField] private GameObject armor;
    [SerializeField] private float armorSpeed = 50.0f;
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
        SpecialMove();

        if(Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        } 
    }

    // POLYMORPHISM
    protected override void SpecialMove()
    {
        // Spin the vehicle's armor to the right/left
        armor.transform.Rotate(Vector3.up * Time.deltaTime * armorSpeed * secondHorizontalInput);
    }
}
