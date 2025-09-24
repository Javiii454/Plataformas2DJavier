using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private AudioClip starSFX;
    //private GameManager gameManager;

    void Awake()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void Interaction()
    {
        //gameManager.AddStar();
        GameManager.instance.AddStar();
        AudioManager.instance.ReproducedSound(starSFX);
        Destroy(gameObject);
        
    }
}
