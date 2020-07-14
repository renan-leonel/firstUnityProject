using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;

    public Transform headPoint;

    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    private bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed,rig.velocity.y); //movimenta o sapo 
        // nesse (speed,rig.velocity.y) basicamente diz pro rigidbody pra nao alterar o y
        
        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
        // physics2d.linecast desenha um colisor invisivel em formato de linha em duas posições, no caso o rightcol e o leftcol
        
        if(colliding){
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y); //rotaciona o eixo x do transform do personagem, invertendo a rotação
            speed *= -1f; // inverte a variavel, se era positivo fica negativo, se era negativo fica positivo
        }
    
    
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            float height = col.contacts[0].point.y - headPoint.position.y; //checa se o personagem ta batendo na cabeça do inimigo, subtraindo headpoint do ponto onde o personagem bateu no inimigo, pra verificar se é > 0

            if(height > 0){
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse); // faz o personagem dar um pulo pra cima quando bate na cabeça do inimigo
                speed = 0; // faz ele parar de andar quando levar o hit
                anim.SetTrigger("die"); // faz a animação do sapo morrendo
                boxCollider2D.enabled = false; // desativa o box collider
                circleCollider2D.enabled = false; // desativa o circle collider
                rig.bodyType = RigidbodyType2D.Kinematic; // muda o body time do rigidbody pra kinematic
                Destroy(gameObject,0.33f); // destroi o sapo dps de 0.33s
            }
        }
    }
}
