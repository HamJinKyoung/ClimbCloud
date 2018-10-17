using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameDirector : MonoBehaviour {

    GameObject hpGage;
    GameObject superGage;
    GameObject superImage;
    bool superMode;
    public AudioSource audiosource;
    public AudioClip playBgm;
    public AudioClip superBgm;

	// Use this for initialization
	void Start () {
        superMode = false;
        this.hpGage = GameObject.Find("hpGage");
        this.superGage = GameObject.Find("superGage");
        this.superImage = GameObject.Find("superImage");
        superGage.GetComponent<Image>().enabled = false;
        superImage.GetComponent<Image>().enabled = false;
        audiosource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

        // hpGage가 다 닳았을 경우 게임오버
        if (this.hpGage.GetComponent<Image>().fillAmount==0)
        {
            SceneManager.LoadScene("OverScene");
        }

        // 슈퍼모드일 경우
        if (superMode)
        {
            this.superGage.GetComponent<Image>().fillAmount -= 0.003f;

            // superGage가 0이 되면 일반모드로 변경
            if (this.superGage.GetComponent<Image>().fillAmount==0)
            {
                Normal();
            }
        }
	
	}

    // Hp감소
    public void DecreaseHp()
    {
        if (!superMode)
            this.hpGage.GetComponent<Image>().fillAmount -= 0.1f;
    }

    // Hp증가
    public void IncreaseHp()
    {
        this.hpGage.GetComponent<Image>().fillAmount += 0.1f;
    }

    // 슈퍼모드
    public void Super()
    {
        superMode = true;
        hpGage.GetComponent<Image>().enabled = false;
        superGage.GetComponent<Image>().enabled = true;
        superImage.GetComponent<Image>().enabled = true;
        superImage.SetActive(true);
        superGage.SetActive(true);
        hpGage.SetActive(false);
        audiosource.Stop();
        audiosource.clip = superBgm;
        audiosource.Play();
    }

    // 일반모드
    public void Normal()
    {
        superMode = false;
        hpGage.GetComponent<Image>().enabled = true;
        superGage.GetComponent<Image>().enabled = false;
        superImage.GetComponent<Image>().enabled = false;
        superImage.SetActive(false);
        superGage.SetActive(false);
        hpGage.SetActive(true);
        audiosource.Stop();
        audiosource.clip = playBgm;
        audiosource.Play();
    }
}
