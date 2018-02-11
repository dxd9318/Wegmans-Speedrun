using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDetection : MonoBehaviour {

    //the radius of the acceptable range within the node
    public float bufferSize;

    //grid for spells
    private Vector2[,] grid;

    //array storing locations of nodes to hit for spell: fireball
    private int[] fireBall;

    //array of all spells
    private int[] spellBook;


	// Use this for initialization
	void Start () {
        //build spell arrays
        BuildSpells();
	}

    // Update is called once per frame
    void Update() {

        //helper method
        FindVector();
    }

    //find node locations
    void FindVector()
    {
        Vector3 loc = Input.mousePosition;

        //if clicked, print the location vector
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(loc.x + ", " + loc.y + ", " + loc.z);
        }
    }

    void BuildSpells()
    {
        //Fireball
       

    }

     
}



