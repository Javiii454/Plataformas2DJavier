using Unity.VisualScripting;
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

    private Animator animator;

    private InputAction interactAction;

    //private GroundSensor groundSensor;

    [SerializeField] private float playerVelocity = 5;

    [SerializeField] private Transform sensorPosition;
    private bool alreadyLanded = true;
    [SerializeField] private Vector2 sensorSize = new Vector2(0.5f, 0.5f);

    [SerializeField] private Vector2 interactionZone = new Vector2(1, 1);
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //groundSensor = GetComponentInChildren<GroundSensor>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"];
        attackAction = InputSystem.actions["Attack"];
        interactAction = InputSystem.actions["Interact"];

    }
    void Start()
    {

    }


    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();


        if (interactAction.WasPressedThisFrame())
        {
            Interact();
        }


        //transform.position = transform.position + new Vector3(moveInput.x,0,0) * playerVelocity * Time.deltaTime;


            if (jumpAction.WasPressedThisFrame() && IsGrounded())
            {
                Jump();
            }

        Movement();

        animator.SetBool("IsJumping", !IsGrounded());

    }

    void Jump()
    {

        rigidbody.AddForce(transform.up * Mathf.Sqrt(jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
     

        
        
    }

    void Interact()
    {
        
        Collider2D[] interactables = Physics2D.OverlapBoxAll(transform.position, interactionZone, 0);
        foreach (Collider2D item in interactables)
        {
            if (item.gameObject.tag == "Star")
            {
                Debug.Log("Desimaru muerete");
            }
        }
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = new Vector2(playerVelocity * moveInput.x, rigidbody.linearVelocity.y);
    }

    bool IsGrounded()
    {
        Collider2D[] ground = Physics2D.OverlapBoxAll(sensorPosition.position, sensorSize, 0);
        foreach (Collider2D item in ground)
        {
            if (item.gameObject.layer == 3)
            {
                return true;
            }
        }
        
        return false;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(sensorPosition.position, sensorSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, interactionZone);
    }

    void Movement()
    {
        if (moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            animator.SetBool("IsRunning", true);
        }
        else if (moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }
}
