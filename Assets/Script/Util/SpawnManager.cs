using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    private List<GameObject> enemys = new List<GameObject>();
    [Header("All types of enemys")]
    public GameObject[] warrior;
    public GameObject[] king;
    public GameObject[] archer;
    public GameObject[] mage;    
    public float waitUntilNextSpawn;

    [Range(0,1)]
    public float chanceOfKing, chanceOfWarrior, chanceOfMage, chanceOfArcher;
    private enum EnemyTypes {Archer, Mage, King, Warrior}
    public Transform[] spawnPos;

    private void Awake()
    {
        StartCoroutine(spawn(waitUntilNextSpawn));
    }

    IEnumerator spawn(float waitTime)
    {
        if (PlayerStats.countdown <= 0)
        {
            int i = Random.Range(0, spawnPos.Length);
            GameObject enemy = Instantiate(chooseNextSpawn(), spawnPos[i].position, Quaternion.identity);
            enemys.Add(enemy);
            yield return new WaitForSeconds(waitTime);
        }
        else
        {
            Debug.Log("Waiting" + PlayerStats.countdown);
            yield return new WaitForSeconds(0.5f);
        }        

        if(PlayerStats.time > 0)
        {
            StartCoroutine(spawn(waitUntilNextSpawn));
        }
        else
        {
            Debug.Log("StopSpawn");
            foreach (GameObject g in enemys)
            {
                Destroy(g);
            }
        }
        
    }

    private GameObject chooseNextSpawn()
    {
        float totalChance = chanceOfArcher + chanceOfKing + chanceOfMage + chanceOfWarrior;

        float nextSpawn = Random.Range(0, totalChance);
        int randomNumber;

        if(nextSpawn <= chanceOfArcher)
        {
            randomNumber = Random.Range(0, archer.Length);
            return archer[randomNumber];
        }
        else if(nextSpawn <= (chanceOfArcher + chanceOfKing))
        {
            randomNumber = Random.Range(0, king.Length);
            return king[randomNumber];
        }
        else if(nextSpawn <= chanceOfArcher + chanceOfKing + chanceOfWarrior)
        {
            randomNumber = Random.Range(0, warrior.Length);
            return warrior[randomNumber];
        }
        else if(nextSpawn <= totalChance)
        {
            randomNumber = Random.Range(0, mage.Length);
            return mage[randomNumber];
        }
        Debug.Log("nulo");
        return null;
    }
}
