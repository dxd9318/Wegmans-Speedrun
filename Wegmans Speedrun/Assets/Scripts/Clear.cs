using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

    public float timeToFade;//3 seconds
    float timer;
    private bool isBlank = true;
    private TrailRenderer tr;

	// Use this for initialization
	void Start () {
        timer = timeToFade;
        tr = GameObject.Find("Swipe").GetComponent<TrailRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
		if((Input.touchCount == 0 && Input.GetMouseButton(0)==false) && isBlank == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                ClearScreen();
                timer = timeToFade;
                isBlank = true;
            }
        }
        if((Input.touchCount > 0 || Input.GetMouseButton(0)))
        {
            isBlank = false;
            
            
        }
	}

    public void ClearScreen()
    {
        //GL.Clear(true, true, Color.black);
        tr.Clear();
        Debug.Log("cleared");

        //StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            tr.material.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }


}
