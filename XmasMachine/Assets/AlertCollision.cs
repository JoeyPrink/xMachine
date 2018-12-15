using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCollision : MonoBehaviour
{
    public StringManager stringManager;

    /*
     * 
     * TODO: -add points, remove points 
     * 
     * 
     * */


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " collided");

        GameObject tmpGO = other.gameObject;
        TextMesh currentTextMesh = tmpGO.GetComponentInChildren<TextMesh>();
        string tmpString = currentTextMesh.text;



        if (tmpString.Length > 0)
        {

            Debug.Log("!!!!!! " + tmpString);

            // TODO life -- 

            //TODO removeString 

            stringManager.DisplayTexts.Remove(currentTextMesh);
            // stringManager.GeneratedStrings.Remove(currentTextMesh);
        }
        //stringManager.DisplayTexts[i].text = "";
        //stringManager.Destroy(DisplayTexts[i].gameObject.transform.parent.gameObject);


        //stringManager.DisplayTexts.Remove(DisplayTexts[i]);
        //stringManager.GeneratedStrings.Remove(GeneratedStrings[i]);

    }

}
