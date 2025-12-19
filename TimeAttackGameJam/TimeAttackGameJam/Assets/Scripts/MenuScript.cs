using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameOverPanel;
    public GameObject creditsPanel;
    public GameObject winPanel;
    public float startTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        EventManager.current.GameLoss += onGameLoss;
        EventManager.current.GameWinWin += onGameWinWin;
    }
    public void OnPressPlay()
    {
        EventManager.current.onGameStart();
        mainMenu.SetActive(false);
    }
    public void onGameLoss()
    {
        startTime = Time.time;
        gameOverPanel.SetActive(true);
    }
    public void onCreditsOpen()
    {
        mainMenu.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void onCreditsClose()
    {
        mainMenu.SetActive(true);
        creditsPanel.SetActive(false);
    }
    public void onExitButtonPressed()
    {
        Application.Quit();
    }
    public void onGameWinWin()
    {
        mainMenu.SetActive(false);
        creditsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(true);
    }

    private void Update()
    {
        if (startTime + 3 < Time.time && gameOverPanel.activeInHierarchy == true)
        {
            gameOverPanel.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
