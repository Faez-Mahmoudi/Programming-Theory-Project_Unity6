using UnityEngine;

public class MainManager : MonoBehaviour
{
    //ENCAPSULATION
    public static MainManager Instance{get; private set;}
    
    public int sceneNum = 0;
    public string playerName;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
