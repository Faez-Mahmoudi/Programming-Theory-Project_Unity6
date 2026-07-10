using UnityEngine;

public class ArmorRotateCamera : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50.0f;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal1");
        Rotate(horizontalInput);
    }

    public void Rotate(float input)
    {
        transform.Rotate(Vector3.up, input * rotationSpeed * Time.deltaTime); 
    }
}
