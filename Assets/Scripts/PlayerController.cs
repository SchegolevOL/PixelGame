using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float jumpforce;
    [SerializeField] private Animator _animator;
    private string _namePar = "isGoing";
    [SerializeField] SpriteRenderer _spriteRenderer;
    private bool _isGround;
    void Update()
    {
        if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            _animator.SetBool(_namePar, true);
        }
        else
        {
            _animator.SetBool(_namePar, false);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
        }
        if (Input.GetKeyDown(KeyCode.Space)&&_isGround)
        {
            
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            _isGround=true;
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isGround=false;
    }
}
