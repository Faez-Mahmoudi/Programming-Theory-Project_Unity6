using UnityEngine;

public class ArmorParticleHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionParticle;

    public void Explosion(Vector3 pos)
    {
        explosionParticle.transform.position = pos;
        explosionParticle.Play();
    }
}
