using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 4.5f, -8);
    [SerializeField] private float rotationSpeed = 100.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Rotate(horizontalInput);
    }
    
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z)  + offset;
    }

    public void Rotate(float input)
    {
        transform.Rotate(Vector3.up, input * rotationSpeed * Time.deltaTime); 
    }
}
