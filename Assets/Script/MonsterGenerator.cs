using UnityEngine;
using System.Collections;

public class MonsterGenerator : MonoBehaviour {

    public GameObject monster1Prefab;
    float span = 5.0f;
    float delta = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(monster1Prefab) as GameObject;
            go.transform.position = new Vector3(-2, 25, 0);
        }

    }
}
