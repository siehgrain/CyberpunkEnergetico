using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WaveEnemy : MonoBehaviour
{
    [System.Serializable]
    public class WaveContent
    {
        [SerializeField][NonReorderable] GameObject[] monsterSpawner;

        public GameObject[] GetMonsterSpawnList()
        {
            return monsterSpawner;
        }
    }


    [SerializeField][NonReorderable] WaveContent[] waves;
    public int currentWave = 0;
    float spawnRange = 10;
    public List<GameObject> currentMonster;
    
    void Start()
    {
        SpawnWave();
    }

    
    void Update()
    {
        if(currentMonster.Count == 0)
        {
            currentWave++;
            SpawnWave();
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < waves[currentWave].GetMonsterSpawnList().Length; i++)
        { 
            GameObject newspawn = Instantiate(waves[currentWave].GetMonsterSpawnList()[i], FindSpawnLoc(), Quaternion.identity);
            currentMonster.Clear();

            Enemy monster = newspawn.GetComponent<Enemy>();
            //monster.SetSpawner(this);
        }
    }
    Vector3 FindSpawnLoc()
    {
        Vector3 SpawnPos;


        float xLoc = Random.Range(-spawnRange, spawnRange) + transform.position.x;
        float zLoc = Random.Range(-spawnRange, spawnRange) + transform.position.z;
        float yLoc = transform.position.y;

        SpawnPos = new Vector3(xLoc, yLoc, zLoc);       
    
        if(Physics.Raycast(SpawnPos, Vector3.down, 5))
        {
            return SpawnPos;
        }
        else
        {
            return FindSpawnLoc();
        }
    }
}