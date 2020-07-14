using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next_level_point : MonoBehaviour
{
    public string lvlName;

    void OnCollisionEnter2D(Collision2D collision){

       if(collision.gameObject.tag == "Player"){ // se o player encosta no checkpoint, carrega a proxima fase
           SceneManager.LoadScene(lvlName);
       }
   }
}
