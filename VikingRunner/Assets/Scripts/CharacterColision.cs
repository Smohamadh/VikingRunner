using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColision : MonoBehaviour
{
    [SerializeField] private GameObject youLostPopUp;
    [SerializeField] private Animation dangPopUp;
    public Animator collisionAnim;
    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Ohh hit to enemy");
            if (Bank.Instance.currentHealth > 1)
            {
                Bank.Instance.currentHealth--;
            }
            else
            {
                Time.timeScale = 0;
                youLostPopUp.SetActive(true);
            }
        }
        else if(other.CompareTag("Obstacle"))
        {
            if (Bank.Instance.currentHealth > 1)
            {
                Bank.Instance.currentHealth--;
                dangPopUp.Play();
                collisionAnim.SetTrigger("Collision");
            }
            else
            {
                Time.timeScale = 0;
                youLostPopUp.SetActive(true);
            }
        }
        else if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0;
            
        }
    }
}
