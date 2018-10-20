using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JumpController : MonoBehaviour {
    
    bool turn;
    Rigidbody2D rigid2D;
    GameObject player;
    float jumpForce = 1000.0f;

    // Use this for initialization
    void Start () {
        this.GetComponent<Image>().fillAmount = 0.0f;
        this.player = GameObject.Find("catPrefab");
        this.rigid2D = GameObject.Find("catPrefab").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(!player.GetComponent<PlayerController>().jumpMode)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {

            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (!turn)
                {
                    this.GetComponent<Image>().fillAmount += 0.03f;
                    if (this.GetComponent<Image>().fillAmount == 1.0f)
                    {
                        turn = true;
                    }
                }
                else
                {
                    this.GetComponent<Image>().fillAmount -= 0.03f;
                    if (this.GetComponent<Image>().fillAmount == 0.0f)
                    {
                        turn = false;
                    }
                }

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                this.rigid2D.AddForce(player.transform.up * this.jumpForce * this.GetComponent<Image>().fillAmount);
                GetComponent<AudioSource>().Play();
                this.GetComponent<Image>().fillAmount = 0.0f;
                player.GetComponent<PlayerController>().jumpMode = false;
            }
        }
	}
}
