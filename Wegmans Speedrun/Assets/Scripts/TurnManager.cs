using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour {

    //characters
    public GameObject p;
    public GameObject e;

    public Text playerA;
    public Text playerD;
    public Text enemyA;
    public Text enemyD;

    private WizHARD enemy;
    private PathDetection player;

    private Health plHealth;
    private Health enHealth;

    private Timer tim;

    private float timer;
    public float startTimer;
    public string last;


	// Use this for initialization
	void Start () {
        enemy = e.GetComponent<WizHARD>();
        player = p.GetComponent<PathDetection>();

        plHealth = GameObject.Find("Player").GetComponent<Health>();
        enHealth = e.GetComponent<Health>();

        tim = GameObject.Find("Canvas").GetComponent<Timer>();

        tim.timeLeft = timer = startTimer;

        last = "";
	}
	
	// Update is called once per frame
	void Update () {
        Game();
	}

    void SwitchTurns()
    {
        //reset the time
        tim.timeLeft = timer = startTimer;
        //switch the bools
        enemy.myTurn = !enemy.myTurn;
        player.myTurn = !player.myTurn;
        last = "";
        player.lastSpell = "";

        playerA.enabled = !playerA.enabled;
        playerD.enabled = !playerD.enabled;
        enemyA.enabled = !enemyA.enabled;
        enemyD.enabled = !enemyD.enabled;
    }

    void PlayerDefense()
    {
        Debug.Log("I defend");

        last = player.lastSpell;

        //start the timer
        tim.timeLeft = timer -= Time.deltaTime;

        if(timer <=0 )
        {
            //failure to input
            last = "failure";
        }
        //what is the block modifier based on the player's input (or failure to input)
        float block = 1;
        switch(last)
        {
            case "failure":
                block = 1;
                break;
            case "block":
                block = .5f;
                break;
            case "shield":
                block = 0;
                break;
        }

        //take damage
        if (last != "")
        {
            plHealth.TakeDamage(plHealth.damageTaken, block);
            SwitchTurns();
        }
    }

    void PlayerAttack()
    {
        Debug.Log("I attac");

        last = player.lastSpell;

        //start the timer
        tim.timeLeft = timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //failure to input
            last = "failure";
        }
        //what is the damage modifier based on the player's input (or failure to input)
        float damage = 0;
        switch (last)
        {
            case "fireball":
                damage = 10;
                break;
            case "shield":
            case "block":
            case "failure":
                damage = 0;
                break;
        }

        if (last != "")
        {
            Debug.Log(last);

            //set damage modifier
            enHealth.damageTaken = damage;

            //enemy defends
            enemy.Defend();

            enemy.attacked = false;

            SwitchTurns();
        }
    }

    void Game()
    {
        //call the player's defensive turn when the enemy attacks
        if(enemy.attacked && player.myTurn == false)
        {
            PlayerDefense();
        }
        else if(player.myTurn)
        {
            PlayerAttack();
        }
    }
}
