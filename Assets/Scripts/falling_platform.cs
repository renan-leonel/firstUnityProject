using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_platform : MonoBehaviour
{

    public float fallingTime;

    private TargetJoint2D target;
    private BoxCollider2D boxColl;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collision){ // verifica se a plataforma bateu no personagem
        if(collision.gameObject.tag == "Player"){
            Invoke("Falling", fallingTime); //chama a funcao falling dps de X segundos
        }
    }

    void OnTriggerEnter2D(Collider2D collider){ //destroi a plataforma quando colide com algo de layer 9

        if(collider.gameObject.layer == 9){
            Destroy(gameObject);
        }
    }

    void Falling(){
        target.enabled = false; // desativa o joint
        boxColl.isTrigger = true; // faz a plataforma descer alem dos bricks
    }

}
