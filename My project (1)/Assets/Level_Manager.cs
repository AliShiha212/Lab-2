using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    
    void start(){
        CurrentCheckpoint = null;
    }
    void Update () {
        
    }
    public void RespawnPlayer()
    {
        FindObjectOfType<Player>().transform.position = CurrentCheckpoint.transform.position;
        
    }
}