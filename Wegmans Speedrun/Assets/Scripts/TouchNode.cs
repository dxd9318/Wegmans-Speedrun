using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchNode : MonoBehaviour {

    private bool isActivated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Swipe")
        {
            isActivated = true;
        }
    }
}
