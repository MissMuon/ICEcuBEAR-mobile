using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpitter : MonoBehaviour {
    public SphereExpander prefab;
    public float secperSphere=0.2f;
    public float sphereDuration=3.0f;
    public float sphereRatio=0.5f;
    float curTimerem = 0;
    Vector3 lastPos;
    // Use this for initialization
    void Start () {
        curTimerem = 0;
        lastPos = gameObject.transform.position;
        if (secperSphere <= 0) secperSphere = 0.1f;
    }
	void spawnSphere(Vector3 pos)
    {
       SphereExpander sph=(SphereExpander) Instantiate(prefab, pos, Quaternion.identity);
        sph.maxTime = sphereDuration;
        sph.timeRatio = sphereRatio;
    }
	// Update is called once per frame
	void Update () {
        Vector3 dpos= gameObject.transform.position;
        float dt= Time.deltaTime;
        float oldTime = curTimerem;
        curTimerem += dt;
        int cphc = 0;
        while (curTimerem >secperSphere)
        {
            cphc += 1;
            spawnSphere(Vector3.Lerp(lastPos, dpos, (secperSphere* (float)cphc - oldTime)/dt));
            curTimerem -= secperSphere;
        }
      lastPos = dpos;
    }
}
