using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackSpell
{
    Fireball
}

public enum DefendSpell
{
    Counter,
    Block,
    Shield
}

public class WizHARD : MonoBehaviour {

    public List<DefendSpell> defSpellPool;//list of defensive spells the ai wizard can pull from
    public List<AttackSpell> atkSpellPool;//list of offensive spells the ai wizard can pull from

    private bool myTurn;//whether it is the wizard's turn or not

    // Use this for initialization
    void Start () {
        myTurn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(myTurn)
        {
            Attack();
            myTurn = false;
        }
	}

    private void Defend()
    {
        int spellIndex = Random.Range(0, defSpellPool.Count - 1);
    }

    private void Attack()
    {
        int spellIndex = Random.Range(0, atkSpellPool.Count - 1);
        GameObject.Find("Player").GetComponent<Health>().TakeDamage(10);
        Debug.Log("he attac");
    }

    private void CastSpell()
    {

    }
}
