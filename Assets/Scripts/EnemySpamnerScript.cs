using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpamnerScript : MonoBehaviour
{
    public GameObject enemy;
    public int CountOfEnemys = 1;

    // Start is called before the first frame update
    void Start()
    {
        float randX, randZ;
        Vector3 whereSpawn;
        for (int i = 1; i < CountOfEnemys; i++)
        {
            randX = Random.Range(-2.4f, 1.581f);
            randZ = Random.Range(-7.5f, -4.16f);
            whereSpawn = new Vector3(randX, 0.782f, randZ);
            Instantiate(enemy, whereSpawn, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
