using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;

    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();

    }

    void OnTriggerEnter2D(Collider2D collider){

        if(collider.gameObject.tag == "Player"){ // quando o player colidir com o objeto
            sr.enabled = false; // desativa o sprite da maçã
            circle.enabled = false; // desativa o collider da maçã
            collected.SetActive(true); //ativa a fumaça

            gamecontroller.instance.totalScore += Score; //aumenta a pontuação
            gamecontroller.instance.updateScoreText();

            Destroy(gameObject, 0.25f); // destroi o objeto dps de X segundos

        }
    }
}
