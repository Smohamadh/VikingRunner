using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Bank : MonoBehaviour
{
    public int currentMoney = 0;
    public int currentHealth = 5;

    [SerializeField] TextMeshProUGUI money;
    [SerializeField] TextMeshProUGUI health;

    public static Bank Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        // var earnMoney = money.text;
        money.text = currentMoney.ToString();
        health.text = currentHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        money.text = currentMoney.ToString();
        health.text = currentHealth.ToString();
    }
}
