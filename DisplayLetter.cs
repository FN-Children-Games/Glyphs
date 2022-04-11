using TMPro;
using UnityEngine;

// This script is used to display letter
public class DisplayLetter : MonoBehaviour
{
    [SerializeField] bool _upperCase;
    internal void SetLetter(char letter)
    {
        if (_upperCase)
            // _upperCase should be changed to _syllabicGlyph
            GetComponent<TMP_Text>().text = letter.ToString().ToUpper();
        else
            // _lowercase should be removed.
            GetComponent<TMP_Text>().text = letter.ToString().ToLower();
    }
}
