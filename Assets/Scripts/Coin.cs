using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private AudioClip coinSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag == "Player")
        {
            GameManager.instance.AddStar();
            AudioManager.instance.ReproducedSound(starSFX);
            Destroy(gameObject);
        }
    }
}
