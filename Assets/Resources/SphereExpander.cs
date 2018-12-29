using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereExpander : MonoBehaviour {
    public float timeRatio = 0.1f;
    public float maxTime = 0.1f;
    float curTime = 0.01f;
	// Use this for initialization
	void Start () {
        curTime = 0.01f;
       float scl = curTime * timeRatio;
        gameObject.transform.localScale = new Vector3(scl, scl, scl);
    }
	
	// Update is called once per frame
	void Update () {
        curTime += Time.deltaTime;
        if (curTime > maxTime)
        {
            Destroy(gameObject);
            return;
        }
        float scl = curTime * timeRatio;
        gameObject.transform.localScale = new Vector3(scl, scl, scl);
        
	}
}
