using NUnit.Framework;
using UnityEngine;
using Unity.Collections;

public class EnemySpawningScript : MonoBehaviour
{
    public int wave;
    public int spawnCount;
    public float randSpawn;
    public int randSide; //0 = left, 1 = right, 0 = top, 1 = bottom
    public int spawnSide; //0 = Z, 1 = X
    public GameObject lastSpawn;
    public GameObject[] enemyArray;
    [SerializeField] public static int enemyCount;
    public bool newWave;
    void Start()
    {
        EventManager.current.GameStart += onGameStart;
        EventManager.current.GameWin += onGameWin;
        EventManager.current.GameLoss += onGameLoss;
    }
    public void onGameStart()
    {
        wave = 1;
        spawnCount = 10;
    }
    void Update()
    {
        if (wave > 0)
        {
            if (enemyCount < spawnCount)
            {
                for (int i = 0; i< spawnCount - enemyCount; i++)
                {
                    int firstRandSpawn = Random.Range(0, 2);
                    if (firstRandSpawn == 0)
                    {
                        randSpawn = Random.Range(-6f, 6f);
                        spawnSide = 0;
                    }
                    else if (firstRandSpawn == 1)
                    {
                        randSpawn = Random.Range(-11f, 11f);
                        spawnSide = 1;
                    }
                    randSide = Random.Range(0, 2);
                    spawnEnemy();
                    enemyCount += 1;
                }
            }
        }
        Debug.Log(enemyCount);
        if (newWave == true)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                newWave = false;
            }
        }
    }
    public void spawnEnemy()
    {
        int randEnemy = Random.Range(0, enemyArray.Length);
        if (spawnSide == 0)
        {
            if (randSide == 0)
            {
                lastSpawn = Instantiate(enemyArray[randEnemy], new Vector3(-13, 0 , randSpawn), Quaternion.identity);
            }
            else if (randSide == 1)
            {
                lastSpawn = Instantiate(enemyArray[randEnemy], new Vector3(13, 0, randSpawn), Quaternion.identity);
            }
        }
        else if (spawnSide == 1)
        {
            if (randSide == 0)
            {
                lastSpawn = Instantiate(enemyArray[randEnemy], new Vector3(randSpawn, 0, 8), Quaternion.identity);
            }
            else if (randSide == 1)
            {
                lastSpawn = Instantiate(enemyArray[randEnemy], new Vector3(3, 0, -8), Quaternion.identity);
            }
        }
    }
    public void onGameWin()
    {
        wave += 1;
        newWave = true;
        enemyCount = 0;
        spawnCount = 10 + ((wave - 1) * 5);
    }
    public void onGameLoss()
    {
        wave = 0;
        newWave = true;
        enemyCount = 0;
    }
}
