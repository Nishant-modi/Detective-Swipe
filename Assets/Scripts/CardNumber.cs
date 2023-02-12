using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardNumber : MonoBehaviour
{
    //[SerializeField] private TextMesh uiText;
    [SerializeField] public TMP_Text uiText;
    //public void Instantiate totalcards;

    public int totalCards;
    public int cardNumber;

    private void Start()
    {
        totalCards = 5;
        cardNumber = 1;
        uiText.text = $"{cardNumber}/{totalCards}";
    }
}
