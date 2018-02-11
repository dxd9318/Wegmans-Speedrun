using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackSpell
{
    Fireball,
    Failure
}

public enum DefendSpell
{
    //Counter,
    Block,
    Shield,
    Failure
}

public class WizHARD : MonoBehaviour {

    public List<DefendSpell> defSpellPool;//list of defensive spells the ai wizard can pull from
    public List<AttackSpell> atkSpellPool;//list of offensive spells the ai wizard can pull from

    public bool myTurn;//whether it is the wizard's turn or not
    public bool attacked;

    // Use this for initialization
    void Start () {
        myTurn = true;
        attacked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(myTurn && attacked == false)
        {
            attacked = false;
            Invoke("Attack", Random.Range(2f, 7f));
            
        }
	}

    public void Defend()
    {
        int spellIndex = Random.Range(0, defSpellPool.Count);

        float block = 1;
        switch ((DefendSpell)spellIndex)
        {
            case DefendSpell.Failure:
                Debug.Log("he fail");
                block = 1;
                break;
            case DefendSpell.Block:
                Debug.Log("he bloc");
                block = .5f;
                break;
            case DefendSpell.Shield:
                Debug.Log("he sheld");
                block = 0;
                break;
        }

        gameObject.GetComponent<Health>().TakeDamage(gameObject.GetComponent<Health>().damageTaken, block);
        
    }

    private void Attack()
    {
        
        int spellIndex = Random.Range(0, atkSpellPool.Count);
        Debug.LogWarning(spellIndex);
        switch ((AttackSpell)spellIndex)
        {
            case AttackSpell.Fireball:
                GameObject.Find("Player").GetComponent<Health>().damageTaken = 10;
                break;
            case AttackSpell.Failure:
                //do nothing
                GameObject.Find("Player").GetComponent<Health>().damageTaken = 0;
                break;
        }
        //GameObject.Find("Player").GetComponent<Health>().TakeDamage(10);
        Debug.Log("he attac");
        attacked = true;
    }

    private void CastSpell()
    {

    }
}
