using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    public float movHor = 0f;
    public float speed = 3f;

    public bool isGroundFloor = true;
    public bool isGroundFront = false;
    public bool isMoving = false;

    public LayerMask groundLayer;
    public float frontGrndRayDist = 0.25f;
    public float floorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;

    public int scoreGive = 50;

    private RaycastHit2D hit;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        
        isMoving = (movHor != 0f);
        // Evitar caer en precipicio
        isGroundFloor = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z),
            new Vector3(movHor, 0, 0), frontGrndRayDist, groundLayer));


        if (isGroundFloor)
            movHor = movHor * -1;
            

        //Choque con pared
        if (Physics2D.Raycast(transform.position, new Vector3(movHor, 0, 0), frontCheck, groundLayer))
            movHor = movHor * -1;

        //Choque con otro enemigo    
        hit = Physics2D.Raycast(new Vector3(transform.position.x + movHor*frontCheck, transform.position.y, transform.position.z),
            new Vector3(movHor, 0, 0), frontDist);

        if (hit != null)
            if (hit.transform != null)
                if (hit.transform.CompareTag("Enemigo"))
                    movHor = movHor * -1;

        anim.SetBool("isMoving", isMoving);

        flip(movHor);


    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);

    }

    private void flip(float _xValue)
    {
        Vector3 theScale = transform.localScale;

        if(_xValue < 0)
            theScale.x = Mathf.Abs(theScale.x) * -1;
        else if (_xValue > 0)
            theScale.x = Mathf.Abs(theScale.x);

        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     // Dañar player   

        if (collision.gameObject.CompareTag("Player"))
        {
            //Dañar player
            Player.obj.getDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
       // Destruir enemigo     
        
       if (collision.gameObject.CompareTag("Player"))
        {
            //Dañar enemigo
            AudioManager.obj.playEnemyHit();
            FXManager.obj.showPuf(transform.position);
            getKilled();
            
        }
    }

    private void getKilled(){
        gameObject.SetActive(false);
    }
}
