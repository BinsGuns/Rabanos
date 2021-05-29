using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRockManager : MonoBehaviour
{
    public List<GameObject> rocks;
    private GameObject player;
    //private GameObject rock;
    float minX;
    float maxX;
    float yValue = 3f;

    float secondsDestroy = 15;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRocks",3,2.5f);
        player = GameObject.Find("Player");

        minX = player.transform.position.x - 1;
        maxX = player.transform.position.x  + 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRocks(){

        if(player.GetComponent<PlayerMovement>().isGameOver) {
            CancelInvoke();
        }
        
        float randomX = Random.Range(minX,maxX);
        int randomRockIndex = Random.Range(0,rocks.Count);
        float randomZ = Random.Range(player.transform.position.z + 30 ,player.transform.position.z + 30);
        float randomY = Random.Range(-100f,50f);
        

        if(player != null) {
            GameObject rock =  Instantiate(rocks[randomRockIndex],new Vector3(randomX,yValue,randomZ) , Quaternion.Euler(0,randomY,0)) as GameObject;
            //destroy rock after 3 secs
            Destroy(rock,secondsDestroy);
        }
        
    

    }
}
