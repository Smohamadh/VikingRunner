using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControler : MonoBehaviour
{
    SpriteRenderer _changeOffset = new SpriteRenderer();

    [SerializeField] float speed = 1f;

    [SerializeField] float interval = .1f;
    // Start is called before the first frame update
    void Start()
    {
        _changeOffset = gameObject.GetComponent<SpriteRenderer>();
        //InvokeRepeating("ChangeOffset", interval, interval);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeOffset();
    }

    void ChangeOffset()
    {
        _changeOffset.sharedMaterial.mainTextureOffset += new Vector2(0, .05f*Time.deltaTime*speed);
    }
}
