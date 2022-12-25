using System;
using System.Collections;
using System.Collections.Generic;



using UnityEngine;



public class Controler : MonoBehaviour
{
    [SerializeField] float maxDamagePerSec = .5f;
    float _damagePerSec = .5f;
    [SerializeField] float speedMove = 5f;
    [SerializeField] float speedRun = 5f;
    [SerializeField] GameObject walker;
    [SerializeField] GameObject arrow;
    [SerializeField] Swipe _swipe;
    [SerializeField] float leftLimit = 5f;
    [SerializeField] float rightLimit = 5f;

    Animator _animator = new Animator();
    Animator _pullArrowAnimate = new Animator();
    [SerializeField] Animator pullArrowGameObject;

    SpriteRenderer _spriteRenderer = new SpriteRenderer();
    SpriteRenderer _walkSpriteRenderer = new SpriteRenderer();
    public Animator animator;
    [SerializeField] private float yPos = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        //_animator = gameObject.GetComponent<Animator>();
        _pullArrowAnimate = pullArrowGameObject.GetComponent<Animator>();
        //_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //_walkSpriteRenderer = walker.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        _damagePerSec -= Time.deltaTime;
        
        Movement();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PullArrow();
            if (_damagePerSec < 0)
            {
                ThrowArrow();
                _damagePerSec = maxDamagePerSec;
            }
        }
        else
        {
            PullArrow(false);
        }
    }


    private int counter = 0;
    private const int resetCounter = 20;
    void Movement()
    {

        transform.position += new Vector3(0,0,speedRun * Time.deltaTime);
        if (_swipe.state == Swipe.State.Left || Input.GetKey(KeyCode.LeftArrow))
        {
            //counter = resetCounter;
            //_walkSpriteRenderer.enabled = false;
            //_spriteRenderer.enabled = true;
            if (transform.position.x > leftLimit)
                gameObject.transform.position += new Vector3(-speedMove * Time.deltaTime, 0, 0);
            //_animator.enabled = true;
        }
        else if (_swipe.state == Swipe.State.Right || Input.GetKey(KeyCode.RightArrow))
        {        //counter = resetCounter;
            //_walkSpriteRenderer.enabled = false;
            //_spriteRenderer.enabled = true;
            if (transform.position.x < rightLimit)
                gameObject.transform.position += new Vector3(speedMove * Time.deltaTime, 0, 0);
            //_animator.enabled = true;
        }
        //else
        {
            //counter--;
            //if (counter <= 0)
            {
                //_animator.enabled = false;
                //_walkSpriteRenderer.enabled = true;
                //_spriteRenderer.enabled = false;
            }
        }
        
    }

    void ThrowArrow()
    {
        Vector3 currentPos = transform.position+new Vector3(0,yPos,0);
        Instantiate(arrow, currentPos, Quaternion.Euler(90,0,0));
    }

    void PullArrow(bool statePullArrow = true)
    {
        _pullArrowAnimate.enabled = statePullArrow;
    }


}
