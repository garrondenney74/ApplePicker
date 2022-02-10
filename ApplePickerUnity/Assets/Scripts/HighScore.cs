/***
 * Created By: Garron Denney
 * Date Created: 2/7/22
 * 
 * Last Edited: N/A
 * Last Edited By: N/A
 * 
 * Description: High score management
 * 
 ***/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static public int score = 1000;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }

        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High Score: "+score;
        if (score > PlayerPrefs.GetInt("ApplePickerHighScore")) 
        { 
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }
}
