using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float startHealth;//starting health for this entity
    private float health;

    public Slider healthBar;

    public string hitRecieved;
    public float damageTaken;

    public float blockMod = 1f;

	// Use this for initialization
	void Start () {
        health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.value = (float)health/startHealth;
	}

    public void TakeDamage(float damage, float mod)
    {
        health -= damage * mod;
        Debug.Log(gameObject.name+"health: "+health);
    }

    public void RestoreHealth(float healthRestored)
    {
        health += healthRestored;
    }
}
