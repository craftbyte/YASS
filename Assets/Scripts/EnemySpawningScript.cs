using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningScript : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Parent;
    void Start()
    {
        InvokeRepeating("SpawnCycle", 3, 2);
    }

    void SpawnCycle() {
        int numberOfEnemies = Random.Range(0,6);
        for (int i = 1; i <= numberOfEnemies; i++) {
            float ratio = ((float)i/((float)numberOfEnemies+1.0f));
            float height = Mathf.Lerp(0.0f,1.0f,ratio);
            Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, height, 10.0f));
            var enemy = Instantiate(Enemy);
            enemy.transform.position = v3Pos;
            enemy.transform.parent = Parent.transform;
        }
    }
}
