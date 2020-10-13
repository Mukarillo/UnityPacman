using PacEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HudView : MonoBehaviour
{
    [SerializeField] private Image lifeIconRef;
    [SerializeField] private Transform lifeCountContainer;
    [SerializeField] private Text gameOverLabel;

    void Awake()
    {
        gameOverLabel.gameObject.SetActive(false);
    }

    void Start()
    {
        PacmanEngine.OnDie += UpdateLife;
        PacmanEngine.OnGameOver += FinishGame;

        UpdateLife();
    }

    private void UpdateLife()
    {
        Debug.Log("UpdateLife : " + PacmanEngine.Instance.LifeCount);
        ClearLifeCount();

        for (int i = 0; i < PacmanEngine.Instance.LifeCount; i++)
        {
            Instantiate(lifeIconRef, lifeCountContainer);
        }
        
    }

    private void ClearLifeCount()
    {
        for (int i = 0; i < lifeCountContainer.childCount; i++)
        {
            Destroy(lifeCountContainer.GetChild(i).gameObject);
        }
    }

    private void FinishGame()
    {
        ClearLifeCount();
        //gameOverLabel.gameObject.SetActive(true);
        SceneManager.LoadScene("Title");
    }

}
