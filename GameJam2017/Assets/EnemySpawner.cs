using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform WorldRoot;

    public int EnemyAmountStart;
    public int EnemyAmountIncrement;

    List<GameObject> enemies;

    void OnEnable()
    {
        enemies = new List<GameObject>();

        for (int i = 0; i < EnemyAmountStart; i++)
        {
            enemies.Add(Instantiate(EnemyPrefab, transform.position, transform.rotation) as GameObject);
        }
    }

    void Update()
    {
        List<GameObject> bufferedEnemeis = enemies;

        for (int i = 0; i < bufferedEnemeis.Count; i++)
        {
            if (bufferedEnemeis[i] == null)
                enemies.Remove(bufferedEnemeis[i]);

            if (bufferedEnemeis[i].transform.position.x < (transform.position.x - 0.5f))
            {
                Destroy(bufferedEnemeis[i]);
                enemies.Remove(bufferedEnemeis[i]);
            }
        }
    }


}
