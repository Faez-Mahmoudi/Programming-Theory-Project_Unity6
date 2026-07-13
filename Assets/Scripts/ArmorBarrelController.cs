using UnityEngine;

public class ArmorBarrelController : MonoBehaviour
{
    [SerializeField] float armorBarrelSpeed = 30f;

    [SerializeField] float minAngle = -30f;
    [SerializeField] float maxAngle = 15f;

    float currentAngle = 0f;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical1");

        currentAngle += verticalInput * -armorBarrelSpeed * Time.deltaTime;

        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        transform.localRotation = Quaternion.Euler(currentAngle, 0f, 0f);
    }
}