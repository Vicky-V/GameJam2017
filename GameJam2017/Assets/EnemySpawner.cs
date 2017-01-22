using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public int EnemyAmount;

    List<GameObject> enemies;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("Wizard"))
        {
            StartCoroutine(Spawn());
        }
    }

    void Update()
    {
        if (enemies == null)
            return;

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

    IEnumerator Spawn()
    {
        int startAmount = 0;

        enemies = new List<GameObject>();


        while (startAmount < EnemyAmount)
        {
            enemies.Add(Instantiate(EnemyPrefab, transform.position + new Vector3(Random.Range(0, 0.25f), 0, Random.Range(0, 0.25f)), transform.rotation) as GameObject);
            startAmount++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
