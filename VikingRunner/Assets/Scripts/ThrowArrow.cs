using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowArrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5f;
    [SerializeField] float destination = 6f;
    Vector3 _destPos;
    void Start()
    {
        _destPos = transform.position +new Vector3(0,0,destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= _destPos.z)
        {
            transform.position += new Vector3(0, 0,Time.deltaTime * speed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
