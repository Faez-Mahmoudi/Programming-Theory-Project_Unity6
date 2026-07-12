using UnityEngine;

public class ArmorBarrelController : MonoBehaviour
{
    [SerializeField] float armorBarrelSpeed = 10;

    void Update()
    {
        //Get user's input based on vertical
        float verticalInput = Input.GetAxis("Vertical1");

        // Spin the vehicle's armor to up/down(ther's a bug here)
        transform.Rotate(Vector3.left * Time.deltaTime * verticalInput * armorBarrelSpeed);
    }
}
