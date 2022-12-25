using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] float speed = 2.45f;

    [SerializeField] int health = 3;

    [SerializeField] Animator destroyPaper;

    [SerializeField] int howMuch = 2;

    SpriteRenderer _character;

    // Start is called before the first frame update
    void Start()
    {
        _character = gameObject.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position -= new Vector3(0, 0,Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Arrow"))
        {

            if (health <= 1)
            {
                _character.enabled = false;
                destroyPaper.enabled = true;
                GetComponent<Collider>().enabled = false;
                StartCoroutine(WaitForAnimationThenDestroy());
            }
            else
            {
                health--;
            }
        }
    }

    IEnumerator WaitForAnimationThenDestroy()
    {
        yield return 0;
        while (destroyPaper.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return 0;
        }
        Bank.Instance.currentMoney += howMuch;
        Destroy(this.gameObject);
        
    }
}
