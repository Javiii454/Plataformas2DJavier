using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    private int stars = 0;
    private int coins = 0;

    [SerializeField] private Text coinCounter;
    [SerializeField] private Text starCounter;

    [SerializeField] private Image healthBar;

    [SerializeField] private GameObject winCanvas;

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

    public void ChangeCanvasStatus(GameObject canvas, bool status)
    {
        canvas.SetActive(status);
    }
    public void AddStar()
    {
        stars++;
        starCounter.text = "Stars:" + stars.ToString();
        if(stars >= 3)
        {
            ChangeCanvasStatus(winCanvas, true);
        }
    }
     public void AddCoin()
    {
        coins++;
        coinCounter.text = "Coins:" + coins.ToString();
    }



    void Start()
    {
        AudioManager.instance.ChangeBGM(AudioManager.instance.gameBGM);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void HealthBar(float currentHealth, float maxHealth)
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

   public void Replay()
    {
        SceneManager.LoadScene(1);
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }


}
