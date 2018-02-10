using UnityEngine;

public class Clear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClearScreen()
    {
        GameObject.Find("Swipe").GetComponent<TrailRenderer>().time = 0;
        Debug.Log("cleared");
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("reset");
        GameObject.Find("Swipe").GetComponent<TrailRenderer>().time = Mathf.Infinity;
    }
}
