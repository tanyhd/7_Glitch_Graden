using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    [SerializeField] Attacker[] attackersPrefabArray;
    
    //float difficultyfactor;
    /*void Awake()
    {
        difficultyfactor = 1 - PlayerPrefsController.GetDifficulty();
        if (difficultyfactor == 0)
        {
            difficultyfactor = 0.99f;
        }
        minSpawnDelay *= difficultyfactor;
        maxSpawnDelay *= difficultyfactor;
    } */


    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay,maxSpawnDelay));
            if (spawn)
            {
                SpawnAttacker();
            }
        }
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackersPrefabArray.Length);
        Spawn(attackersPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;
    }

    public void StopSpawning()
    {
        spawn = false;
    }
}
