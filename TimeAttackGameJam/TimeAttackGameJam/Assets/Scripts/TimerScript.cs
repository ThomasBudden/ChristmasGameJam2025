using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public bool startTimer;
    public float startTime;
    public TMP_Text timerTxt;
    public static float maxTime;
    void Start()
    {
        EventManager.current.GameStart += onGameStart;
        EventManager.current.GameWin += onGameWin;
        EventManager.current.GameLoss += onGameLoss;
        startTimer = false;
    }

    public void onGameStart()
    {
        maxTime = 30;
        startTimer = true;
        startTime = Time.time;
    }
    public void onGameWin()
    {
        maxTime = 30;
        startTimer = true;
        startTime = Time.time;
    }
    public void onGameLoss()
    {
        startTimer = false;
    }

    void Update()
    {
        if (startTimer == true)
        {
            timerTxt.text = (maxTime - (Time.time - startTime)).ToString();
        }
        if (startTimer == true && (maxTime - (Time.time - startTime)) <= 0)
        {
            EventManager.current.onGameWin();
        }
        EnemySpawningScript.spawnCount = Mathf.CeilToInt(EnemySpawningScript.startSpawnCount + (Time.time - startTime)/2);
    }
}
