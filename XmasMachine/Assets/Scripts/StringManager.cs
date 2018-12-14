using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Linq;

public class StringManager : MonoBehaviour
{
    static public List<string> GeneratedStrings = new List<string>();
    public Text DisplayString;

    //use alphabet2 for extra difficulty
    const string alphabet = "abcdefghijklmnopqrstuvwxyz";
    const string alphabet_ger = "abcdefghijklmnopqrstuvwxyzöäüß";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!DisplayString)
        {
            SetDisplayText();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            string gen = GenerateRandomString(6);

            DisplayString.text = gen;
            if(GeneratedStrings[0] == null)
            {
                GeneratedStrings.Add(gen);
            }
            else
            {
                GeneratedStrings[0] = gen;
            }
        }

        if(Input.anyKeyDown)
        {
            CheckInputLetter(Input.inputString[0]);
        }
    }

    public void SetDisplayText()
    {
        if (!DisplayString)
        {
            Debug.Log("Reconnected Debug Text Component");
            DisplayString = GameObject.Find("DebugDisplayString").GetComponent<Text>();
        }
    }

    public bool CheckInputLetter(char letter)
    {
        Debug.Log("Entered letter: " + letter);

        string current = GeneratedStrings[0];

        if (current[current.Length - 1] == letter)
        {
            //Correct input
            Debug.Log("Correct Letter!");

            //remove letter from string
            GeneratedStrings[0] = current.Substring(current.Length - 1);
            DisplayString.text = GeneratedStrings[0];
        }
        else
        {
            return false;
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
