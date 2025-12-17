using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    public int wave;
    public int spawnCount;
    public float randSpawn;
    public int randSide; //0 = left, 1 = right, 0 = top, 1 = bottom
    public int spawnSide; //0 = Z, 1 = X
    public GameObject lastSpawn;
    public GameObject[] enemyArray;
    void Start()
    {
        EventManager.current.GameStart += onGameStart;
    }
    public void onGameStart()
    {
        wave = 1;
        spawnCount = 5;
    }
    void Update()
    {
        if (wave == 1)
        {
            for (int i = 0; i < spawnCount; i++)
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
                if (i == spawnCount -1)
                {
                    wave += 1;
                }
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
}
