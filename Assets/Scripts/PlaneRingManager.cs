using UnityEngine;

public class PlaneRingManager : MonoBehaviour
{
    [SerializeField] private GameObject[] rings;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var ring in rings)
        {
            ring.gameObject.SetActive(false);
        }
        rings[0].gameObject.SetActive(true);   
    }

    public void SetNextRing(int num)
    {
        int n = num % rings.Length;
        rings[n].gameObject.SetActive(false);
        rings[(n+1) % rings.Length].gameObject.SetActive(true);
    }
}
