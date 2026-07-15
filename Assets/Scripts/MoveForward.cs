using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    private TrailRenderer trail;


    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
