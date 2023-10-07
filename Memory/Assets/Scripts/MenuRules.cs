using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRules : MonoBehaviour
{
    [SerializeField] private Pause pause;
    void Start()
    {
        pause.SetPause();
        pause.GetMenu().SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            pause.SetPause();
        }
    }
}
