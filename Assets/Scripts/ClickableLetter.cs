using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableLetter : MonoBehaviour, IPointerClickHandler
{
    char _randomLetter;
    bool _upperCase;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"Clicked on letter {_randomLetter}");
        if (_randomLetter == GameController.Instance.Letter)
        {
            GetComponent<TMP_Text>().color = Color.green;
            enabled = false;
            GameController.Instance.HandleCorrectLetterClick(_upperCase);
        }
    }

    public void SetLetter(char letter)
    {
        enabled = true;
        GetComponent<TMP_Text>().color = Color.white;
        _randomLetter = letter;

        if (Random.Range(0, 100) > 50)
        {
            _upperCase = false;
            GetComponent<TMP_Text>().text = _randomLetter.ToString();
        }
        else
        {
            _upperCase = true;
            GetComponent<TMP_Text>().text = _randomLetter.ToString().ToUpper();
        }
    }
}