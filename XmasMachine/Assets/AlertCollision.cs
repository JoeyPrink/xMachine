using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            if(currentLives == 0 ) {
                // TODO Game Over 

                restartLevel();

            } 
            //Debug.Log("current lives... " + currentLives);

          


            for (int i = 0; i < stringManager.DisplayTexts.Count; i++){

                Debug.Log("..." + i);

                //Debug.Log(stringManager.DisplayTexts[i].ToString());
                //Debug.Log("..." + i + ": "+ stringManager.DisplayTexts[i].text);

                if (stringManager.DisplayTexts[i] != null)
                {
                    Debug.Log("display :" + i + "::"+ stringManager.DisplayTexts[i].text);
                    if(stringManager.DisplayTexts[i].Equals(currentTextMesh)) {
                        stringManager.DisplayTexts.Remove(currentTextMesh);
                    }
                        
                }
               /* if (stringManager.DisplayTexts[i].text == tmpString) {

                }*/
            }

            Destroy(tmpGO);






        }


    }

    private void restartLevel()
    {
        SceneManager.LoadScene("0-startScreen");
        coreLoop.PlayerLives = 3;
        stringManager.DisplayTexts.Clear();
        

    }
}
