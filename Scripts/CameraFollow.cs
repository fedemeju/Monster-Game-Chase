using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform player;

    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()    //called after all calculations in Update are finished
    {
        
        if(!player)     //test (askin if player is == NULL) when player is destroyed if it is null the function ends there
            return;
        
        tempPos = transform.position; // current position of the camera
        tempPos.x = player.position.x;  // set the camera X position to the player X position

        if(tempPos.x < minX)  // not to show the limit of the game in camera
        tempPos.x = minX;
    

        if(tempPos.x > maxX)
        tempPos.x = maxX;


        transform.position = tempPos;  // asing the value to the camera position
        
    }
}//Class
