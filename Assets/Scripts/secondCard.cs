using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondCard : MonoBehaviour
{
    private swipe swipeEffect;
    private GameObject firstCard;
    // Start is called before the first frame update
    void Start()
    {
        swipeEffect = FindObjectOfType<swipe>();
        firstCard = swipeEffect.gameObject;
        swipeEffect.cardMoved += CardMovedFront;
        transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMoved = firstCard.transform.localPosition.x;

        if(Mathf.Abs(distanceMoved)>0)
        {
            float step = Mathf.SmoothStep(0.0f, 1, Mathf.Abs(distanceMoved) / (Screen.width / 4));
            transform.localScale = new Vector3(step, step, step);   

        }
    }

    void CardMovedFront()
    {
        gameObject.AddComponent<swipe>();
        Destroy(this);
    }
}
