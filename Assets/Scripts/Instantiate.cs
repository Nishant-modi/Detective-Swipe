using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Instantiate : MonoBehaviour
{
    public GameObject[] cardPrefabs;
    //public bool[] swipeData;
    [SerializeField] public TMP_Text uiText;

    int curIndex = 0;
    
    void InstantiateCard()
    {
        

        if (curIndex < cardPrefabs.Length)
        {    
            //GameObject newCard = Instantiate(cardPrefabs[(curIndex+1)%cardPrefabs.Length], transform, false);
            GameObject newCard = Instantiate(cardPrefabs[curIndex++], transform, false);
            newCard.transform.SetAsFirstSibling();
            Debug.Log("card swiped");

            int totalCards = cardPrefabs.Length;
            int currCard = curIndex;

            uiText.text = $"{currCard}/{totalCards}";

            //bool cardMoved = FindObjectOfType<swipe>().swipeL;
            //Debug.Log("card swiped" + cardMoved);

        }
        else
        {
            FindObjectOfType<GM>().NextLevel();
        }

        //curIndex++;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount<2)
        {
            InstantiateCard();
        }
    }
}
