using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowFriend : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject follower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(0, 0,Time.deltaTime * 2.45f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BodyPlayer"))
        {
            GameObject newFollower = Instantiate(follower);
            newFollower.transform.position = new Vector3(1,1, -0.726f);
            newFollower.transform.rotation = new Quaternion(0f, 0f, 0f,0);
            Destroy(this.gameObject);
        }
    }
}
