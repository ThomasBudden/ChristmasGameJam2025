using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [Header("Spawner Information")]
    [SerializeField] bool hasSpawned = false;
    [SerializeField] GameObject[] powerUpArray;
    public GameObject[] lastSpawn;

    [Header("Spawner Randomisation")]
    [SerializeField] float randX;
    [SerializeField] float randY;
    [SerializeField] Vector3 randLocation;

    [Header("Spawner Cooldown")]
    [SerializeField] float cooldownTimer;
  
    
    void Start()
    {
        //EventManager.current.GameStart += onGameStart;
    }

    public void onGameStart()
    {
        hasSpawned = false;
    }


    void Update()
    {
        if (hasSpawned == false)
        {
            Debug.Log("Cycle Begins");
            SpawnCycle();
        }

        if (lastSpawn == null)
        {


            Debug.Log("Cooldown Begins");
            SpawnCooldown();
        }
    }

    void SpawnCycle()
    {
        SpawnPowerUp();

    }


    void SpawnPowerUp()
    {
        randY = Random.Range(-6f, 6f);
        randX = Random.Range(-11f, 11f);
        randLocation = new Vector3(randY, 0, randX);

        int randPower = Random.Range(0, powerUpArray.Length);
        lastSpawn[0] = Instantiate(powerUpArray[randPower], randLocation, Quaternion.identity);

        hasSpawned = true;
    }

    void SpawnCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            hasSpawned = false;
        }

    }
}

