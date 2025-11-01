using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    // ENCAPSULATION
    [SerializeField] protected float m_Speed = 20.0f;
    public float speed{
        get { return m_Speed;}
        set {
            if( value < 0.0f && value > 100.0f)
                Debug.LogError("You can't set a negative or more than 100 speed!");
            else 
                m_Speed = value;
        }
    }
    [SerializeField] protected float turnSpeed = 45.0f;
    protected float horizontalInput;
    protected float forwardInput;

    public Camera mainCamera;
    public Camera hoodCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // ABSTRACTION
    protected virtual void Move()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * m_Speed);
        // Rotate the player to left and right
        transform.Rotate(Vector3.up * Time.deltaTime * horizontalInput * forwardInput * turnSpeed);
    }

    protected abstract void SpecialMove();

    protected void SwitchCamera()
    {
        // Switch between hood and main camera
        mainCamera.enabled = !mainCamera.enabled;
        hoodCamera.enabled = !hoodCamera.enabled;
    }
}
