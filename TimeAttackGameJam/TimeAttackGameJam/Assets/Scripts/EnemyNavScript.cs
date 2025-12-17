using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent agent;
    private Vector3 target;
    public float health;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        target = player.transform.position;
        agent.SetDestination(target);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            EnemySpawningScript.enemyCount -= 1;
            TimerScript.maxTime += 5;
        }
        if (other.tag == "Player" && Time.time >= 5)
        {
            EventManager.current.onGameLoss();
        }
    }
}
