using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 30.0f;
    private ArmorParticleHandler particleHandler;
    private TrailRenderer trail;


    void Awake()
    {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = true;
        particleHandler = GameObject.Find("ParticleHandler").GetComponent<ArmorParticleHandler>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            Destroy(other.gameObject);

            particleHandler.Explosion(other.gameObject.transform.position);
        }
        Destroy(gameObject);
    }
}
