using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endGame : MonoBehaviour
{
    [Header ("Timer")]
    float timer=70f;
    private float maxTime=70f;

    [Header("UI")]
    [SerializeField] private Image timerUi;

   // Update is called once per frame
   void Update()
    {
        if (GameObject.FindWithTag("EnemyMother") == null)
        {
            SceneManager.LoadScene("Victory");
        }
        if (GameObject.FindWithTag("Player") == null)
        {
            SceneManager.LoadScene("Defeat");
        }
        timer -= Time.deltaTime;
        timerUi.fillAmount = timer / maxTime;
        if (timer <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }
    }
}
