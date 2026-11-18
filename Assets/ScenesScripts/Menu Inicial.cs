using UnityEngine;
using UnityEngine.SceneManagement;
public class menuInicial : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HowTo()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void exit()
    {
        Application.Quit(); 
    }
}
