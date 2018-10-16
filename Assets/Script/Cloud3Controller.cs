using UnityEngine;
using System.Collections;

public class Cloud3Controller : MonoBehaviour {

    int dir;

    // Use this for initialization
    void Start () {
        dir = 1;
	}
	
	// Update is called once per frame
	void Update () {
       // 좌우로 움직이는 구름
       transform.Translate(0.03f*dir, 0, 0);

       if(transform.position.x > 2.0f)
        {
            dir = -1;
        }
       if(transform.position.x < -2.0f)
        {
            dir = 1;
        }
	}
}
