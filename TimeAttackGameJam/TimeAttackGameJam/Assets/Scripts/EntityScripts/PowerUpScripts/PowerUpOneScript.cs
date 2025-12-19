using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PowerUpOneScript : MonoBehaviour
{

    [SerializeField] PowerUpScript lastSpawnList;
    [SerializeField] GameObject powerManager;

    private void Start()
    {
        powerManager = GameObject.FindWithTag("PowerManager");
        lastSpawnList = GetComponent<PowerUpScript>();

    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);


        }

    }

    private void OnDestroy()
    {
        GameObject.Destroy(lastSpawnList.lastSpawn);
        
    }

}
