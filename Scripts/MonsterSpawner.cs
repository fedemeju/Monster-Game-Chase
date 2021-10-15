using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;  // array with enemies

    [SerializeField]
    private Transform leftPos, rightPos; 

    private GameObject spawnedMonster;

    private int randomIndex;
    private int randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnedMonsters());
    }

    IEnumerator SpawnedMonsters() 
    {
        while(true){
        
        yield return new WaitForSeconds(Random.Range(1,5));
        
        randomIndex = Random.Range(0, monsterReference.Length);  //from 1 to 3 (amount of monster tipes)
        randomSide = Random.Range(0,2); 

        spawnedMonster = Instantiate(monsterReference[randomIndex]); // creates a copy of GameObject...

        if(randomSide == 0){
            //left
            spawnedMonster.transform.position = leftPos.position; //set side
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(4,10); // sets speed at randon values from 4 to 10
        }
        else{
            //right
            spawnedMonster.transform.position = rightPos.position;
            spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4,10);
            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f); //flip monster
        }
        }
    }//while


}//Class
