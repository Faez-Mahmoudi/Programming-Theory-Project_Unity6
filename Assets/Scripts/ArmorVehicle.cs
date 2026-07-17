using UnityEngine;
using System.Collections;

public class ArmorVehicle : PlayerController // INHERITTANCE
{
    [SerializeField] private GameObject armor;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private bool isFired;
    private float secondHorizontalInput;
    private ArmorRotateCamera armorCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        armorCamera = GameObject.Find("FocalPoint").GetComponent<ArmorRotateCamera>();
        isFired = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        secondHorizontalInput = Input.GetAxis("Horizontal1");

        Move();

        if(Input.GetKeyDown(KeyCode.Space) && !isFired)
        {
            SpecialMove();
            isFired = true;
            StartCoroutine(FireCountDown());
        }
        
        if(Input.GetKeyDown(KeyCode.C))
            SwitchCamera();
    }

    IEnumerator FireCountDown()
    {
        yield return new WaitForSeconds(2);
        isFired = false;
    }

    // POLYMORPHISM
    protected override void Move()
    {
        if (transform.rotation != focalPoint.transform.rotation)
        {
            base.Move();

            if(forwardInput >= 0)
            {        
                armor.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * -horizontalInput);
                armorCamera.Rotate(-horizontalInput);
            }
            else if(forwardInput < 0)
            {
                armor.transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
                armorCamera.Rotate(horizontalInput);
            }
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
