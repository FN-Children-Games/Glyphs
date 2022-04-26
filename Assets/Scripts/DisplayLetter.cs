using TMPro;
using UnityEngine;

public class DisplayLetter : MonoBehaviour
{
    [SerializeField] bool _upperCase;
    internal void SetLetter(char letter)
    {
        if (_upperCase)
            GetComponent<TMP_Text>().text = letter.ToString().ToUpper();
        else
            GetComponent<TMP_Text>().text = letter.ToString().ToLower();
    }
}