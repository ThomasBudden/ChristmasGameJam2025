using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainMenu.SetActive(true);
        EventManager.current.GameLoss += onGameLoss;
    }
    public void OnPressPlay()
    {
        EventManager.current.onGameStart();
        mainMenu.SetActive(false);
    }
    public void onGameLoss()
    {
        mainMenu.SetActive(true);
    }
}
