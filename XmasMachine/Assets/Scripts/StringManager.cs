using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Linq;

public class StringManager : MonoBehaviour
{

    static public List<string> GeneratedStrings = new List<string>();

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
        if(Input.GetKeyDown(KeyCode.S))
        {
            GenerateRandomString(6);
        }
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
