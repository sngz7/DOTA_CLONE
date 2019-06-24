using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyKilling : MonoBehaviour
{
    //Variables
    public float health = 100;
    public Image healthBar;
    private float startHealth ;
    //Methods
    public void Start()
    {
        startHealth = health;
    }
    public void Update()
    {
        healthBar.fillAmount = health / startHealth;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        print("Ënemy" + this.gameObject.name + "has died!");
        Destroy(this.gameObject);
    }



}
