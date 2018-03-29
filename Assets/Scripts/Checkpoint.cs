using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    
    public int checkpointNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (CheckPointManager.CurrentCheckpoint == checkpointNumber)
            {
                print("Checkpoint cleared" + CheckPointManager.CurrentCheckpoint);
                CheckPointManager.CurrentCheckpoint += 1;
                
                

            }
        }
    }
}
