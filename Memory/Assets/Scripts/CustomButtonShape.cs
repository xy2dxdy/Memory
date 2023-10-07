using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButtonShape : MonoBehaviour
{
    public float alpha = 0f;
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alpha;
    }

}
