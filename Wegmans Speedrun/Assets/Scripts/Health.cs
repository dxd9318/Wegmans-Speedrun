using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int startHealth;//starting health for this entity
    private int health;

    public Slider healthBar;

	// Use this for initialization
	void Start () {
        health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = (float)health/startHealth;
	}

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(gameObject.name+"health: "+health);
    }

    public void RestoreHealth(int healthRestored)
    {
        health += healthRestored;
    }
}
