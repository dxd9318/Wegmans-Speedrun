using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathDetection : MonoBehaviour {

    public Camera cam;

    //nodes for spells
    public GameObject node;
    private GameObject lastNode;
    private float height;

    //grid for spells
    private List<GameObject> grid = new List<GameObject>();
    //stores nodes the player touches
    public List<int> playerPath = new List<int>();

    //arrays storing lists of nodes to hit for spells
    private List<int> fireBall = new List<int>();

    //array of all spells
    private List<List<int>> spellBook = new List<List<int>>();
    private List<string> spellNames = new List<string>();


	// Use this for initialization
	void Start () {
        //build spell arrays   
        BuildSpells();
        lastNode = gameObject;
        CreateGrid();
        height = Screen.height / 3;
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
                Vector3 spawnPT = new Vector3(Screen.width/6 + (Screen.width/3 * i), (Screen.height/6 + (Screen.height/3 * j)) / 3, 0);
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
        spellBook.Add(fireBall);
        spellNames.Add("fireball");

    }

    void CheckPath()
    {        
        //check each spell to see if the players path matches
        for(int i = 0; i < spellBook.Count; i ++)
        {
            if(CompareLists(spellBook[i], playerPath))
            {
                CastSpell(spellNames[i]);
                return;// FIGURE OUT WHERE THIS GOES
            }
        }
        //if does not match a spell
        CastSpell("failure");
    }

    bool CompareLists(List<int> list1, List<int> list2)
    {       
        bool eq = false;

        if (list1.Count != list2.Count)
        {
            return false;
        }

        for(int i = 0; i < list1.Count; i++)
        {
            if(list1[i] != list2[i])
            {
                eq = false;
                break;
            }
            else
            {
                eq = true;
            }
        }
        return eq;        
    }

        void CastSpell(string spell)
    {
         switch(spell)
        {
            case "fireball":
                Debug.Log("FIREBALL");
                break;
            case "failure":
                Debug.Log("FAILURE");
                break;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject nodeTouched = other.gameObject;
       //Debug.Log(nodeTouched.name);
       
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
        Debug.Log("CLEAR");
    }
}




