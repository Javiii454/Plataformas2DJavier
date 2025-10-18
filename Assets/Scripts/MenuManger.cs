using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{
   public void Play()
   {
    SceneManager.LoadScene(1);
   }
}
