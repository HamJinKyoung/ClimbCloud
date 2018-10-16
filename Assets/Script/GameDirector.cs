using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    GameObject hpGage;
    GameObject superGage;
    GameObject superImage;
    bool superMode;

	// Use this for initialization
	void Start () {
        this.hpGage = GameObject.Find("hpGage");
        this.superGage = GameObject.Find("superGage");
        this.superImage = GameObject.Find("superImage");
        superGage.GetComponent<Image>().enabled = false;
        superImage.GetComponent<Image>().enabled = false;
        superMode = false;
        //superGage.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if(this.hpGage.GetComponent<Image>().fillAmount==0)
        {
            SceneManager.LoadScene("OverScene");
        }

        if (superMode)
        {
            this.superGage.GetComponent<Image>().fillAmount -= 0.003f;
            if (this.superGage.GetComponent<Image>().fillAmount==0)
            {
                Normal();
            }
        }
	
	}

    public void DecreaseHp()
    {
        if (!superMode)
            this.hpGage.GetComponent<Image>().fillAmount -= 0.1f;
    }

    public void IncreaseHp()
    {
        this.hpGage.GetComponent<Image>().fillAmount += 0.1f;
    }

    public void Super()
    {
        superMode = true;
        hpGage.GetComponent<Image>().enabled = false;
        superGage.GetComponent<Image>().enabled = true;
        superImage.GetComponent<Image>().enabled = true;
        superGage.SetActive(true);
        hpGage.SetActive(false);

    }

    public void Normal()
    {
        superMode = false;
        hpGage.GetComponent<Image>().enabled = true;
        superGage.GetComponent<Image>().enabled = false;
        superImage.GetComponent<Image>().enabled = false;
        superGage.SetActive(false);
        hpGage.SetActive(true);
    }
}
