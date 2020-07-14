using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    public float speed;
    public float moveTime;

    private bool directionR = true;
    private float timer;

    // Update is called once per frame
    void Update(){
        if(directionR){
            // se verdadeiro a serra vai pra direita
            transform.Translate(Vector2.right * speed * Time.deltaTime); 
        }
        else{
            // se falso a serra vai pra esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;
        if(timer >= moveTime){
            // quando o timer for maior que o movetime, inverte o lado do movimento da serra e zera o timer
            directionR = !directionR;
            timer = 0f;
        }
    }
}
