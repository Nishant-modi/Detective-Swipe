using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Q_swipe : MonoBehaviour
{
    public bool[] swipeL;

    public void setSwipe()
    {
        swipeL[0] = true;
        swipeL[1] = false;
        swipeL[2] = false;
        swipeL[3] = true;
        swipeL[4] = true;
        swipeL[5] = false;
    }
}
