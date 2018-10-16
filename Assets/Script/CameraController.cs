using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        this.player = GameObject.Find("cat");
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
	
	}
}
