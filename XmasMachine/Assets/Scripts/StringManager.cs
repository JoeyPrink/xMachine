using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Linq;

public class StringManager : MonoBehaviour
{
    static public List<string> GeneratedStrings = new List<string>();
    public List<TextMesh> DisplayTexts = new List<TextMesh>();

    //use alphabet2 for extra difficulty
    const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    //const string alphabet_ger = "abcdefghijklmnopqrstuvwxyzöäüß";

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {


            if (GeneratedStrings.Count != 0)
            {
                CheckInputLetter(Input.inputString[0]);

            }

        }
    }

    public void AddToyString(TextMesh text)
    {
        //TODO: variable for string length
        string gen = GenerateRandomString(6);
        GeneratedStrings.Add(gen);
        DisplayTexts.Add(text);
        text.text = gen;
    }

    public bool CheckInputLetter(char letter)
    {



        // Debug.Log("Entered letter: " + letter);

        for (int i = 0; i < GeneratedStrings.Count; i++)
        {
            string current = GeneratedStrings[i];


            if (current.Length == 0)
            {

                //remove string, object

            }
            else if (current[current.Length - 1] == letter)
            {
                //Correct input
                Debug.Log("Correct Letter!");

                //remove letter from string
                GeneratedStrings[i] = current.Substring(0, current.Length - 1);

                //Check if last letter of string, delete toy object
                if (current.Length <= 1)
                {
                    Debug.Log("THIS WAS THE LAST LETTER!");

                    //remove object, remove string
                    DisplayTexts[i].text = "";
                    Destroy(DisplayTexts[i].gameObject.transform.parent.gameObject);


                    DisplayTexts.Remove(DisplayTexts[i]);
                    GeneratedStrings.Remove(GeneratedStrings[i]);


                }
                else
                {

                    if (DisplayTexts[i].text != null)
                        DisplayTexts[i].text = GeneratedStrings[i];


                }


                break;
            }
        }
        return true;
    }

    public string GenerateRandomString(int length)
    {
        string rs = new string('-', length);

        var building = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            double rand = Random.value * alphabet.Length;
            char letter = alphabet[(int)rand];

            //Debug.Log("Chosen letter: " + letter + " from index " + (int)rand);

            building.Append(letter);
        }

        rs = building.ToString();
        //Debug.Log(rs);
        return rs;
    }
}
