using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Functions : MonoBehaviour
{
   
    public int count=0;
    public int countHP = 50;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public TextMeshProUGUI hp;
    public GameObject gameOverObject;
    // Start is called before the first frame update
    void Start()
    {
        SetCountText();
        SetHPText();
        winTextObject.SetActive(false);
        gameOverObject.SetActive(false);
    }


    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 4)
        {
            winTextObject.SetActive(true);
        }
    }

    public void SetHPText()
    {
        hp.text = "HP: " + countHP.ToString();
        if(countHP == 0)
        {
            gameOverObject.SetActive(true);
        }

    }

}
