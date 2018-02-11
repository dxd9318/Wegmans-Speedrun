using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDetection : MonoBehaviour {

    public Camera cam;

    //nodes for spells
    public GameObject node;
    private GameObject lastNode;

    //grid for spells
    private List<GameObject> grid = new List<GameObject>();
    //stores nodes the player touches
    public List<int> playerPath = new List<int>();

    //arrays storing lists of nodes to hit for spells
    private List<int> fireBall = new List<int>();

    //array of all spells
    private int[] spellBook;


	// Use this for initialization
	void Start () {
        //build spell arrays      
        lastNode = gameObject;
        CreateGrid();
	}

    // Update is called once per frame
    void Update() {

        //helper method
       // FindMouse();

        if(Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            CheckPath();
            ResetPlayerPath();
        }

       
    }

    //find node locations
    void FindMouse()
    {
        Vector3 loc = Input.mousePosition;

        //if clicked, print the location vector
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log(loc.x + ", " + loc.y + ", " + loc.z);
        }
    }


     void CreateGrid()
    {
        int count = 1;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Vector3 spawnPT = new Vector3(70 + (i * 105), 35 + (j * 80), 1);
                Vector3 spawn = cam.ScreenToWorldPoint(spawnPT);
                spawn.z = 0;
                GameObject newNode = Instantiate(node,spawn, Quaternion.identity);
                newNode.name = ""+count;
                count++;
                grid.Add(newNode);
            }
        }
    }

 
    void BuildSpells()
    {
        //fireball
        //3,2,1,6,7,8,9 (W shaped)
        fireBall.Add(3);
        fireBall.Add(2);
        fireBall.Add(1);
        fireBall.Add(6);
        fireBall.Add(7);
        fireBall.Add(8);
        fireBall.Add(9);


    }

    void CheckPath()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject nodeTouched = other.gameObject;
       // Debug.Log(nodeTouched.name);
       
        if(lastNode.name != nodeTouched.name)
        {
            lastNode = nodeTouched;
            int temp = int.Parse(nodeTouched.name);
            playerPath.Add(temp);
        }
    }

    void ResetPlayerPath()
    {
        playerPath.Clear();
        lastNode = gameObject;
    }
}




