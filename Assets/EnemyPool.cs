using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPool : MonoBehaviour
{
    public GameObject Enemy;
    public int count = 10;

    void Start()
    {
        StartCoroutine(CreateEnemy());
    }
    IEnumerator CreateEnemy()
    {
        for (int i = 0; i < count; i++)
        {
            var enemy = Instantiate(Enemy);
            enemy.transform.position = new Vector3(Random.value * 8f, 0, Random.value * 8f);
            enemy.GetComponent<NavMeshAgent>().avoidancePriority += i;
            yield return new WaitForSeconds(1);
        }
    }
}


