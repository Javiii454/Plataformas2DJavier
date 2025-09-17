using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private InputAction moveAction;
    private Vector2 moveInput;

    private InputAction jumpAction;

    private float jumpHeight = 3;

    private InputAction attackAction;

    //private GroundSensor groundSensor;

    [SerializeField]private float playerVelocity = 5;

    [SerializeField]private Transform sensorPosition;
    [SerializeField]private Vector2 sensorSize = new Vector2(0.5f,0.5f);
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //groundSensor = GetComponentInChildren<GroundSensor>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"];
        attackAction = InputSystem.actions["Attack"];
    }
    void Start()
    {
        
    } 

    
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        

        //transform.position = transform.position + new Vector3(moveInput.x,0,0) * playerVelocity * Time.deltaTime;
       

        if(jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }
    }

    void Jump()
    {
       
        rigidbody.AddForce(transform.up * Mathf.Sqrt(jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
    
     
        
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = new Vector2(playerVelocity * moveInput.x, rigidbody.linearVelocity.y);
    }

    bool IsGrounded()
    {
        Collider2D[] ground = Physics2D.OverlapBoxAll(sensorPosition.position,sensorSize,0);
        foreach(Collider2D item in ground)
        {
            if(item.gameObject.layer == 3)
            {
                return true;
            }
        }

        return false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(sensorPosition.position,sensorSize);
    }
}
