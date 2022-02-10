/***
 * Created By: Garron Denney
 * Date Created: 2/7/22
 * 
 * Last Edited: N/A
 * Last Edited By: N/A
 * 
 * Description: Controls basket movement and score aquisition
 * 
 ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; // Get the current screen position of the mouse from Input
        mousePos2D.z = -Camera.main.transform.position.z; // The Camera's z position sets the how far to push the mouse into 3D                                              
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // Convert the point from 2D screen space into 3D game world space                                       
        Vector3 pos = this.transform.position; // Move the x position of this Basket to the x position of the Mouse
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    void OnCollisionEnter( Collision coll ) // Find out what hit this basket
    { 
         
        GameObject collidedWith = coll.gameObject; 
        if ( collidedWith.tag == "Apple" ) 
        { 
            Destroy( collidedWith );
        }
        int score = int.Parse(scoreGT.text); 
        score += 100; // Add points for catching the apple
        scoreGT.text = score.ToString();// Convert the score back to a string and display it
        if(score > HighScore.score)
        {
            HighScore.score = score;
        }
    }


}
