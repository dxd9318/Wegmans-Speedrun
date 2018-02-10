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
        //GL.Clear(true, true, Color.black);
        GameObject.Find("Swipe").GetComponent<TrailRenderer>().Clear();
        Debug.Log("cleared");
    }

    
}
