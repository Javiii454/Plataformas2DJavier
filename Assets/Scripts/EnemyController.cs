using UnityEngine;

public class EnemyController : MonoBehaviour
{


    public float enemySpeed = 4.5f;

    public int direction = 1;

    private Rigidbody2D rigidbody;

    private Animator animator;

    [SerializeField] private float enemyHealth = 20;

    private PlayerController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.linearVelocity = new Vector2(enemySpeed * direction, rigidbody.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && direction == 1 )
        {
            direction = -1;
        }
        else if (collision.gameObject.layer == 6 && direction == -1 )
        {
            direction = 1;
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("IsAttacking");
        }

        if (collision.gameObject.tag == "Player" && direction == 1)
        {
            direction = -1;
        }
        else if (collision.gameObject.tag == "Player" && direction == -1)
        {
            direction = 1;
        }
        

       
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}
