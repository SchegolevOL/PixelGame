using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private float speed;
    [SerializeField] private Button _restarButton;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpforce;
    [SerializeField] private Animator _animator;
    [SerializeField] private Text _countAplLeText;
    private string _namePar = "isGoing";
    [SerializeField] SpriteRenderer _spriteRenderer;
    private bool _isGround;
    private string _nameParJump="isJump";
    private string _nameGround="Ground";
    private string _nameApple="Apple";
    private string _nameFinish="Finish";
    private int _countApple=0;
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
            _animator.SetTrigger(_nameParJump);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==_nameGround)
        {
            _isGround=true;
            
        }
        if (collision.gameObject.tag==_nameApple)
        {

            _countApple++;
            _countAplLeText.text = _countApple.ToString();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag==_nameFinish)
        {
            _winPanel.isStatic = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag==_nameGround)
        {
            _isGround=false;
            
        }
    }

    private void OnDestroy()
    {
        _restarButton.gameObject.SetActive(true);
    }
}
