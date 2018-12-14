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

    public Text DisplayString1;
    public Text DisplayString2;
    public Text DisplayString3;

    //use alphabet2 for extra difficulty
    const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    const string alphabet_ger = "abcdefghijklmnopqrstuvwxyzöäüß";

    // Start is called before the first frame update
    void Start()
    {
        GeneratedStrings.Add("------");
    }

    // Update is called once per frame
    void Update()
    {
        if(!DisplayString1)
        {
            SetDisplayTexts();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            string gen1 = GenerateRandomString(6);
            string gen2 = GenerateRandomString(6);
            string gen3 = GenerateRandomString(6);

            DisplayString1.text = gen1;
            GeneratedStrings[0] = gen1;

            DisplayString2.text = gen2;
            GeneratedStrings[1] = gen2;

            DisplayString3.text = gen3;
            GeneratedStrings[2] = gen3;

        }

        if(Input.anyKeyDown)
        {
            CheckInputLetter(Input.inputString[0]);
        }
    }

    public void SetDisplayTexts()
    {
        if (!DisplayString1)
        {
            Debug.Log("Reconnected Debug Text Component");
            DisplayString1 = GameObject.Find("DebugDisplayString1").GetComponent<Text>();
        }
        if (!DisplayString2)
        {
            //Debug.Log("Reconnected Debug Text Component");
            DisplayString2 = GameObject.Find("DebugDisplayString2").GetComponent<Text>();
        }
        if (!DisplayString3)
        {
            //Debug.Log("Reconnected Debug Text Component");
            DisplayString3 = GameObject.Find("DebugDisplayString3").GetComponent<Text>();
        }
    }

    public bool CheckInputLetter(char letter)
    {
        Debug.Log("Entered letter: " + letter);

        for(int i = 0; i < 3; i++)
        {
            string current = GeneratedStrings[i];

            if (current[current.Length - 1] == letter)
            {
                //Correct input
                Debug.Log("Correct Letter!");

                //remove letter from string
                GeneratedStrings[i] = current.Substring(0, current.Length - 1);
                switch (i)
                {
                    case 0:
                        DisplayString1.text = GeneratedStrings[i];
                        break;
                    case 1:
                        DisplayString2.text = GeneratedStrings[i];
                        break;
                    case 2:
                        DisplayString3.text = GeneratedStrings[i];
                        break;
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

        for(int i = 0; i < length; i++)
        {
            double rand = Random.value * alphabet.Length;

            char letter = alphabet[(int)rand];

            Debug.Log("Chosen letter: " + letter + " from index " + (int)rand);

            building.Append(letter);
        }

        rs = building.ToString();

        Debug.Log(rs);
        return rs;
    }
}
