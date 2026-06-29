using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -7);
    
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z)  + offset;
    }
}
