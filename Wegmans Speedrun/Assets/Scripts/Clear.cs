using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

    public float timeToFade;//3 seconds
    float timer;
    private bool isBlank = true;
    private bool drawing = false;
    private TrailRenderer tr;

	// Use this for initialization
	void Start () {
        timer = timeToFade;
        tr = gameObject.GetComponent<TrailRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        
		if((Input.touchCount == 0 && Input.GetMouseButton(0)==false) && isBlank == false)
        {
            drawing = false;
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
            if(isBlank == false && drawing == false)
            {
                ClearScreen();
                timer = timeToFade;
            }
            isBlank = false;
            drawing = true;
        }

        //Fade();
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
        float alpha = 1.0f;
        while (alpha >= 0)
        {
            //Color fadeColor = tr.material.color;
            //Debug.LogWarning("couroutine");
            //// set color with i as alpha
            //for(int k = 0; k < tr.colorGradient.alphaKeys.Length; k++)
            //{
            //    Debug.Log(alpha);
            //    //Debug.LogWarning(tr.material.GetColor(""));
            //    tr.material.SetColor("_EmissionColor", new Color(1, 1, 255, alpha));
            //    tr.colorGradient.alphaKeys[k].alpha = alpha;
            //    //Debug.Log(tr.colorGradient.alphaKeys[k].alpha);
            //    Debug.Log(alpha);
            //}

            Color fadeColor = tr.material.color;
            fadeColor.a = alpha;
            gameObject.GetComponent<TrailRenderer>().material.color = fadeColor;

            alpha -= Time.deltaTime;
            yield return null;
        }
    }


}
