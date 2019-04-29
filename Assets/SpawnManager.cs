using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject warrior;
    public GameObject king;
    public GameObject archer;
    public GameObject mage;

    public List<GameObject> enemys = new List<GameObject>();


    public float waitUntilNextSpawn;

    public float chanceOfKing;
    public float chanceOfWarrior;
    public float chanceOfMage;
    public float chanceOfArcher;

    public Transform[] spawnPos;


    private void Awake()
    {
        StartCoroutine(spawn(waitUntilNextSpawn));
    }

    IEnumerator spawn(float waitTime)
    {
        int i = Random.Range(0, spawnPos.Length);
        enemys.Add(Instantiate(chooseNextSpawn(), spawnPos[i].position, Quaternion.identity));
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(spawn(waitUntilNextSpawn));
    }

    private GameObject chooseNextSpawn()
    {
        float totalChance = chanceOfArcher + chanceOfKing + chanceOfMage + chanceOfWarrior;

        float nextSpawn = Random.Range(0, totalChance);

        if(nextSpawn <= chanceOfArcher)
        {
            return archer;
        }
        else if(nextSpawn <= (chanceOfArcher + chanceOfKing))
        {
            return king;
        }
        else if(nextSpawn <= chanceOfArcher + chanceOfKing + chanceOfWarrior)
        {
            return warrior;
        }
        else if(nextSpawn <= totalChance)
        {
            return mage;
        }
        Debug.Log("nulo");
        return null;
    }
}
