using UnityEngine;
using System.Collections;

public class RainController : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        this.player = GameObject.Find("cat");
	
	}
	
	// Update is called once per frame
	void Update () {
        // 프레임마다 등속으로 낙하시킨다.
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나오면 소멸시킨다.
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 충돌 판정
        Vector2 p1 = transform.position;    // 빗방울의 중심 좌표
        Vector2 p2 = this.player.transform.position;    // 플레이어의 중심 좌표
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.05f;    // 빗방울 반경
        float r2 = 0.5f;    // 플레이어 반경

        if(d < r1 + r2)
        {
            // 충돌하면 소멸시킨다.
            Destroy(gameObject);

            // 감독 스크립트에 플레이어와 빗방울이 충돌햇다고 전달한다.
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();

        }


    }
}
