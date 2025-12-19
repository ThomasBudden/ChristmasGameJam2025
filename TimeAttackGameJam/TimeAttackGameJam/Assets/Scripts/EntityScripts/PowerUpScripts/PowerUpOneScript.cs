using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PowerUpOneScript : MonoBehaviour
{

    [SerializeField] PowerUpScript lastSpawnList;
    [SerializeField] GameObject powerManager;

    [SerializeField] bool isDestroyed = false;

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
        if (!isDestroyed)
        {
           lastSpawnList.lastSpawn = null;
           isDestroyed = true;
       }
       

   }

}
