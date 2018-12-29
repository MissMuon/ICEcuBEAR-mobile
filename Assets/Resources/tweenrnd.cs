using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tweenrnd : MonoBehaviour {

    public Transform centrs;
    public float randLength=0.1f;
    public Vector3 randTend;
    public float randPref=0.01f;
    public float randDist=0.001f;
    float _speed;
    float _dt = 0.1f;
    public float speed=1.0f;
    Vector3 pos1;
    Vector3 pos2;
    // Use this for initialization
    float ctime = 0;
 
    void Start()
    {
        pos1=gameObject.transform.position;
        nextPoint();
    }
    void nextPoint()
    {
        pos1= gameObject.transform.position;
        _speed = speed; if (_speed < 0) _speed = Mathf.Abs(_speed); if (_speed == 0) _speed = 0.1f;
        if(centrs!=null)
        {
            randTend = centrs.position;
        }
        Vector3 pref = randTend - gameObject.transform.position;
        if (pref.magnitude < 0.0001f) pref = Random.onUnitSphere;
        float pdc = randPref+pref.magnitude * randDist;
        if (pdc < 0) pdc = 0;
        pref.Normalize();
        bool done = false;
        Vector3 resl=Vector3.zero;
        while(!done)
        {
            Vector3 cand = Random.onUnitSphere;
            float inr = cand.x * pref.x + cand.y * pref.y + cand.z * pref.z;
            float cf=Mathf.Lerp(1.0f/(1.0f+pdc),1.0f,(inr+1.0f)/2.0f);
            if(Random.Range(0.0f,1.0f)<cf)
            {
                Debug.Log(string.Format("pref: {0}, cf: {1}  inr:{2} pdc:{3}", pref, cf, inr, pdc));
                resl = cand;
                done = true;
            }
        }
        pos2 = pos1 + resl * randLength;
        _dt = (pos2 - pos1).magnitude / _speed;
    }
    // Update is called once per frame
    void Update()
    {
       
     
        ctime = ctime + Time.deltaTime;
        if (_dt < 0.0001f)
        {
            nextPoint();
            return;
        }
        while (ctime > _dt) { ctime -= _dt; nextPoint(); }
       
        gameObject.transform.position = Vector3.Lerp(pos1, pos2, ctime / _dt);
       
    }
}
