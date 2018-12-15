using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCollision : MonoBehaviour
{
    public StringManager stringManager;
    public GameCoreLoop coreLoop;


    /*
     * 
     * TODO: -add points, remove points 
     * 
     * 
     * */



    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + " collided");
        GameObject tmpGO = other.gameObject;
        TextMesh currentTextMesh = tmpGO.GetComponentInChildren<TextMesh>();
        string tmpString = currentTextMesh.text;

        

        if (tmpString.Length > 0)
        {

            Debug.Log("!!!!!! " + tmpString);
            
            //TODO removeString 

            //stringManager.DisplayTexts.Remove(currentTextMesh);

            Debug.Log("..." + stringManager.DisplayTexts.Count);

            int currentLives = coreLoop.getPlayerLives() -1;

            coreLoop.PlayerLives = currentLives;
            //Debug.Log("current lives... " + currentLives);

            //Destroy(tmpGO);


            for (int i = 0; i < stringManager.DisplayTexts.Count; i++){

                Debug.Log("..." + i);

                //Debug.Log(stringManager.DisplayTexts[i].ToString());

                //Debug.Log("..." + i + ": "+ stringManager.DisplayTexts[i].text);

                if (stringManager.DisplayTexts[i] != null)
                {
                    Debug.Log("display :" + i + "::"+ stringManager.DisplayTexts[i].text);
                }
               /* if (stringManager.DisplayTexts[i].text == tmpString) {
                    Debug.Log("yeaaaaaaah");
                }*/
            }






        }


    }

}
