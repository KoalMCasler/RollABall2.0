//Koal Casler
//GameDev 1
//NSCC Truro 2023

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelMove : MonoBehaviour
{
     public int sceneBuildIndex;
     public Animator Transition;
 
    // Level move zoned enter, if collider is a player
    // Move game to another scene
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            if(sceneBuildIndex >= 3)
            {
                other.GetComponent<PlayerControl>().EndGame();
            }
            else
            {
                Transition.SetBool("Leave", true);
                SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                Transition.SetBool("Leave", false);
            }
        }
    }
    
}
