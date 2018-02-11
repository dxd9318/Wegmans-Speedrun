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
    private List<int> block1 = new List<int>();
    private List<int> block2 = new List<int>();
    private List<int> block3 = new List<int>();
    private List<int> shield = new List<int>();

    //array of all spells
    private List<List<int>> spellBook = new List<List<int>>();
    private List<string> spellNames = new List<string>();

    public bool myTurn = false;
    public string lastSpell;

    //test stuff
    public GameObject bg;
    private SpriteRenderer sr;


    // Use this for initialization
    void Start () {
        //build spell arrays   
        BuildSpells();
        lastNode = gameObject;
        CreateGrid();

        sr = bg.GetComponent<SpriteRenderer>();

        //nothing
        lastSpell = "";
	}

    // Update is called once per frame
    void Update() {

        //helper method
       // FindMouse();

        if(Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            lastSpell = "";
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
        //basic attack (med damage, med difficulty)
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

        //block
        //halves damage (low dif)
        //3,6,9
        //2,5,8
        //1,4,7
        block1.Add(3);
        block1.Add(6);
        block1.Add(9);
        block2.Add(2);
        block2.Add(5);
        block2.Add(8);
        block3.Add(1);
        block3.Add(4);
        block3.Add(7);
        spellBook.Add(block1);
        spellNames.Add("block1");
        spellBook.Add(block2);
        spellNames.Add("block2");
        spellBook.Add(block3);
        spellNames.Add("block3");

        //shield
        //blocks damage (med dif)
        //1,2,3,6,9,8,7 (U shaped)
        shield.Add(1);
        shield.Add(2);
        shield.Add(3);
        shield.Add(6);
        shield.Add(9);
        shield.Add(8);
        shield.Add(7);
        spellBook.Add(shield);
        spellNames.Add("shield");

        //counter
        //reflects damage (high difficulty)

    }

    void CheckPath()
    {        
        //check each spell to see if the players path matches
        for(int i = 0; i < spellBook.Count; i ++)
        {
            if(CompareLists(spellBook[i], playerPath))
            {
                CastSpell(spellNames[i]);
                return;
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
                if(!myTurn)
                {
                    spell = "failure";
                }
                lastSpell = "fireball";
                sr.color = Color.red;
                break;
            case "block1":
            case "block2":
            case "block3":
                Debug.Log("BLOCK");
                sr.color = Color.gray;
                lastSpell = "block";
                break;
            case "shield":
                Debug.Log("SHIELD");
                sr.color = Color.blue;
                lastSpell = "shield";
                break;
            case "counter":
                Debug.Log("COUNTER");
                sr.color = Color.yellow;
                lastSpell = "counter";
                break;
            case "failure":
                Debug.Log("FAILURE");
                sr.color = Color.white;
                lastSpell = "failure";
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




