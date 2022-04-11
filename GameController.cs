using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<AudioClip> _audioClips;

    // List of unicode characters.
        /*  
    "/u1401, /u1403, /u1405, /u1408, /u1409, /u140A, /u140F, /u1420, /u1423,
    /u1425, /u1426, /u1427, /u142A, /u142F, /u1431, /u1433, /u1436, /u1437,
    /u1438, /u144A, /u144B, /u144C, /u144E, /u1450, /u1453, /u1454, /u1455,
    /u14A1, /u14BC, /u14D1, /u1506, /u18F5, /u15C4, /u15C5, /u15C6, /u15C7,
    /u15C8, /u15C9, /u15CA, /u15CB, /u15CC, /u15CD, /u15CE, /u15CF, /u15D0,
    /u15D1, /u15D2, /u15D3, /u15D4, /u15D5, /u15D6, /u15D7, /u15D8, /u15D9,
    /u15DA, /u15DB, /u15DC, /u15DD, /u15DE, /u15DF, /u15E0, /u15E1, /u15E2,
    /u15E3, /u15E4, /u15E5, /u15E6, /u15E7, /u15E8, /u15E9, /u15EA, /u15EB,
    /u15EC, /u15ED, /u15EE, /u15EF, /u15F0, /u15F1, /u15F2, /u15F3, /u15F4,
    /u15F5, /u15F6, /u15F7, /u15F8, /u15F9, /u15FA, /u15FB, /u15FC, /u15FD,
    /u15FE, /u15FF, /u1600, /u1601, /u1602, /u1603, /u1604, /u1605, /u1606,
    /u1607, /u1608, /u1609, /u160A, /u160B, /u160C, /u160D, /u160E, /u160F,
    /u1610, /u1611, /u1612, /u1613, /u1614, /u1615, /u1616, /u1617, /u1618,
    /u1619, /u161B, /u161C, /u161D, /u161E, /u161F, /u1620, /u1621, /u1622,
    /u1623, /u1624, /u1625, /u1626, /u1627, /u1628, /u1629, /u162A, /u162B,
    /u162C, /u162D, /u162E, /u162F, /u1630, /u1631, /u1632, /u1633, /u1634,
    /u1635, /u1636, /u1637, /u1638, /u1639, /u163A, /u163B, /u163C, /u163D,
    /u163E, /u163F, /u1640, /u1641, /u1642, /u1643, /u1644, /u1645, /u1646,
    /u1647, /u1648, /u1649, /u164A, /u164B, /u164C, /u164D, /u164E, /u164F,
    /u1650, /u1651, /u1652, /u1653, /u1654, /u1655, /u1656, /u1657, /u1658,
    /u1659, /u165A, /u165B, /u165C, /u165D, /u165E, /u165F, /u1660, /u1661,
    /u1662, /u1663, /u1664, /u1665, /u1666, /u1667, /u1668, /u1669, /u166A,
    /u166B, /u166C"
        */ 
     
    // This is the char that will be replaced by the unicode characters.
    public char Letter = 'a';
    
    int _correctAnswers = 5;
    int _correctClicks;
    
    public static GameController Instance { get; private set; }

    AudioSource _audioSource;

    void Awake()
    {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        GenerateBoard();
        UpdateDiplayLetters();
    }

    void GenerateBoard()
    {
        var clickables = FindObjectsOfType<ClickableLetter>();

        List<char> charsList = new List<char>();

        for (int i = 0; i < _correctAnswers; i++)
            charsList.Add(Letter);

        for (int i = _correctAnswers; i < clickables.Length; i++)
        {
            var chosenLetter = ChooseInvalidRandomLetter();
            charsList.Add(chosenLetter);
        }

        charsList = charsList
            .OrderBy(t => UnityEngine.Random.Range(0, 10000))
            .ToList();

        for (int i = 0; i < clickables.Length; i++)
        {
            clickables[i].SetLetter(charsList[i]);
        }

        FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
    }

    internal void HandleCorrectLetterClick(bool upperCase)
    {
        var clip = _audioClips.FirstOrDefault(t => t.name == Letter.ToString());
        if (upperCase)
            clip = _audioClips.FirstOrDefault(t => t.name == Letter.ToString() + Letter.ToString());

        _audioSource.PlayOneShot(clip);

        _correctClicks++;
        FindObjectOfType<RemainingCounterText>().SetRemaining(_correctAnswers - _correctClicks);
        if (_correctClicks >= _correctAnswers)
        {
            MoveToNextLetter();
            UpdateDiplayLetters();
            _correctClicks = 0;
            GenerateBoard();
        }
    }

    private void MoveToNextLetter()
    {
        Letter++;
        var clip = _audioClips.FirstOrDefault(t => t.name == Letter.ToString());
        if (clip == null)
            Letter = 'a';
    }

    private void UpdateDiplayLetters()
    {
        foreach (var displayletter in FindObjectsOfType<DisplayLetter>())
        {
            displayletter.SetLetter(Letter);
        }
    }

    private char ChooseInvalidRandomLetter()
    {
        int a = UnityEngine.Random.Range(0, 26);
        var randomLetter = (char)('a' + a);
        while (randomLetter == Letter)
        {
            a = UnityEngine.Random.Range(0, 26);
            randomLetter = (char)('a' + a);
        }

        return randomLetter;
    }
}
