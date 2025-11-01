using UnityEngine;

public class FollowPlane : MonoBehaviour
{
    [SerializeField] protected float turnSpeed = -45.0f;
    private float secondHorizontalInput;

    void LateUpdate()
    {
        secondHorizontalInput = Input.GetAxis("Horizontal1");

        // Rotate the camera to the side
        transform.Rotate(Vector3.back * Time.deltaTime * secondHorizontalInput * turnSpeed);
    }
}
