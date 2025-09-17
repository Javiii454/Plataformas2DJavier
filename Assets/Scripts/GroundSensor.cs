using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool isGrounded;
    private PlayerController playerController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }
        
        
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
