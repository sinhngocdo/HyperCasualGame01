using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    float jumpForce;
    [SerializeField] float gravity = 1;
    public float jumpMuliplayer = 10f;
    [SerializeField] float leftBound, rightBound;


    bool isDraging = false;
    Vector2 touchPos, playerPos, dragPos;

    public GameObject jumpEffect;
    public GameObject deathEffect;

    public GameObject touchStartText;

    bool isDead = false;
    bool isStart = false;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair"))
        {
            if(rb.velocity.y <= 0f)
            {
                jumpForce = gravity * jumpMuliplayer;
                rb.velocity = new Vector2(0, jumpForce);
                GameManager.instance.AddScore();
                SoundManager.instance.StairSound();
                Camera.main.backgroundColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
                //DestroyAndMakeNewStair(collision);
                effect();
            }
         
        }

        if (collision.CompareTag("OtherStair"))
        {
            if(rb.velocity.y <= 0f)
            {
                Deadth();
            }
            
        }

    }

    private void effect()
    {
        Destroy( Instantiate(jumpEffect, transform.position, transform.rotation), 0.5f);
    }

    private void Update()
    {
        WaitToTouch();
        if (isDead)
        {
            return;
        }
        if (!isStart)
        {
            return;
        }
        if (isStart)
        {
            GetInput();
            MovePlayer();
            CheckPlayer();
        }


    }


    private void WaitToTouch()
    {
        if (!isStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Time.timeScale = 1f;
                gravity = 1;
                isStart = true;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0.5f) * jumpForce);
                touchStartText.SetActive(false);
            }
        }
    }

    private void MovePlayer()
    {
        if (isDraging)
        {
            dragPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = new Vector2(playerPos.x + (dragPos.x - touchPos.x), transform.position.y);

            ControlPlayInScene();
        }
    }

    //Keep play in scene camera
    private void ControlPlayInScene()
    {
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector2(rightBound, transform.position.y);
        }
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector2(leftBound, transform.position.y);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        AddGravity();
    }

    /// <summary>
    /// Drag player in Scene game any position
    /// </summary>
    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            touchPos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            playerPos = transform.position;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
        }
    }

    void AddGravity()
    {
        rb.velocity = new Vector2(0, rb.velocity.y - (gravity * gravity));
    }

    void CheckPlayer()
    {
        if (!isDead && transform.position.y < Camera.main.transform.position.y - 15)
        {
            Deadth();
        }
    }

    private void Deadth()
    {
        Destroy(Instantiate(deathEffect, transform.position, transform.rotation), 0.5f);
        Destroy(gameObject, 0.5f);
        SoundManager.instance.DeathSound();
        GameManager.instance.EndGame();
    }
}
