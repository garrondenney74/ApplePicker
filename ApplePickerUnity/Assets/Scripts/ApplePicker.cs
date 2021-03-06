/***
 * Created By: Garron Denney
 * Date Created: 1/31/22
 * 
 * Last Edited: N/A
 * Last Edited By: N/A
 * 
 * Description: Master script running game, lives counter, and game reset
 * 
 ***/




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;


    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll)
    { // 2
      // Find out what hit this basket
        GameObject collidedWith = coll.gameObject; // 3
        if (collidedWith.tag == "Apple")
        { // 4
            Destroy(collidedWith);
        }
    }
    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGo in tAppleArray)
        {
            Destroy(tGo);
        }//end forEach

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if(basketList.Count == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }//end AppleDestroyed

}
