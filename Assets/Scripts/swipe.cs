using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class swipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector3 initialPos;
    private float distanceMoved;
    public bool swipeL;
    public event Action cardMoved;

    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);
        if((transform.localPosition.x - initialPos.x) > 0)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0,-30, (initialPos.x + transform.localPosition.x)/(Screen.width/2)));
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30, (initialPos.x - transform.localPosition.x) / (Screen.width / 2)));
        }
        //throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPos = transform.localPosition;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        distanceMoved = Mathf.Abs(transform.localPosition.x - initialPos.x);
        if (distanceMoved < 0.25 * Screen.width)
        {
            transform.localPosition = initialPos;
            transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            if (transform.localPosition.x > initialPos.x)
            {
                swipeL = false;               
            }
            else
            {
                swipeL = true;
            }
            FindObjectOfType<GM>().Data(swipeL);
            //gm.Data(swipeL);


            cardMoved?.Invoke();
            StartCoroutine(MovedCard());
        }
    }

    private IEnumerator MovedCard()
    {
        float time = 0;
        while(GetComponent<Image>().color != new Color(1,1,1,0))
        {
            time += Time.deltaTime;

            if(swipeL)
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x - Screen.width,10*time), transform.localPosition.y,0);
            }
            else
            {
                transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x, transform.localPosition.x + Screen.width, 10 * time), transform.localPosition.y, 0);
            }

            GetComponent<Image>().color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4 * time));
            yield return null;
        }

        Destroy(gameObject);
        
    }
}
