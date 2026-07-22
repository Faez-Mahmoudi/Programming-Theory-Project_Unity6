using UnityEngine;

public class MoveRight : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (gameObject.transform.position.z < -10.0f || gameObject.transform.position.y < 0)
            Destroy(gameObject);
    }
}
