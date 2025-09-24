using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private int stars = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void AddStar()
    {
        stars++;
        Debug.Log("Estrellas recogidas" + stars);
    }

    void Start()
    {
        AudioManager.instance.ChangeBGM(AudioManager.instance.gameBGM);
    }
}
