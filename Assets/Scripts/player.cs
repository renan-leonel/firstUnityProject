using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start(){
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * Speed;
       
        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("walk", true); // faz a animação do personagem andar
            transform.eulerAngles =  new Vector3(0f,0f,0f); // faz o boneco olhar pra direita
        }

        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("walk", true); // faz a animação do personagem andar
            transform.eulerAngles =  new Vector3(0f,180f,0f); // faz o boneco olhar pra direita

        }

        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("walk", true); // faz a animação do personagem andar
        }
        
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(isJumping == false){              

                rig.AddForce(new Vector2(0f,JumpForce),ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true); // faz a animação do personagem pular

            }
            else{
                if(doubleJump == true){
                    rig.AddForce(new Vector2(0f,JumpForce),ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
            anim.SetBool("jump", false); // para a animação do pulo

        }

        if(collision.gameObject.tag == "Spike"){
            gamecontroller.instance.showGameOver();
            Destroy(gameObject);   
        }

    }
    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = true;
        }    
    }
}
