using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{   
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float spawnTime = 5.0f;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

    [SerializeField]
    private GameObject[] powerups; //list of powerups
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(spawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //COROUTINE
    //spawn game objects every 5 sec
    //Coroutines can be used for something to happen in certain intervals of time  ,   can pause execution, return control and come back to where it paused
    //Create a couroutine of time IEnumerator which yield events

    IEnumerator SpawnEnemyRoutine()
    {
        //yield return null    -   waits 1 frame

        //then this line is called
        //yield return new WaitForSeconds(5.0f); 
        //waits for 5 sec then this line called
        //while loop infinite

        //we need this to happen forever so infinite loop
        while(_stopSpawning == false){
            Vector3 posToSpawn = new Vector3(Random.Range(-9f,9f),6.4f,0);
            GameObject newEnemy = Instantiate(_enemyPrefab,posToSpawn,Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;  // both should be transform for enemies to be child of container
            yield return new WaitForSeconds(spawnTime);
        }
        //we will never get here
    }

    IEnumerator spawnPowerUpRoutine(){

        while(_stopSpawning == false){
            Vector3 posToSpawn = new Vector3(Random.Range(-9f,9f),6.4f,0);
            int randomPowerUp = Random.Range(0,3); //3 excluded
            Instantiate(powerups[randomPowerUp],posToSpawn,Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(6,10));
        }

    }

    public void onPlayerDeath(){
        _stopSpawning = true;  // its always better to create changes made by other classes in a sepaarte function
    }

}