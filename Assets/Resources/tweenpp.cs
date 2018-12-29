using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tweenpp : MonoBehaviour {
    public Vector3 pos1;
    public Vector3 pos2;
    float _speed;
    float _dt = 0.1f;
    public float speed;
    
    // Use this for initialization
    float ctime = 0;
    bool cdir = true;
    void Start () {
        gameObject.transform.position = pos1;
	}
	
	// Update is called once per frame
	void Update () {
        _speed = speed; if (_speed < 0) _speed = Mathf.Abs(_speed); if (_speed == 0) _speed = 0.1f;
        _dt = (pos2 - pos1).magnitude / _speed;
        ctime = ctime+Time.deltaTime;
        if (_dt < 0.0001f) return;
        while (ctime > _dt) { ctime -= _dt;cdir = !cdir; }
        if (cdir)
            gameObject.transform.position = Vector3.Lerp(pos2, pos1, ctime / _dt);
        else
            gameObject.transform.position = Vector3.Lerp(pos1, pos2, ctime / _dt);
        
    }
}
