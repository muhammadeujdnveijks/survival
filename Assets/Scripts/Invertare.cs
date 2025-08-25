using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertare : MonoBehaviour
{
    [SerializeField] private List<InvertareSlot> slots = new List<InvertareSlot>();
    private int indexActiv = 0;

    void Start()
    {

    }

    void Update()
    {
        slot();
    }

    void slot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            indexActiv = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            indexActiv = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            indexActiv = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            indexActiv = 3;
        }
    }
}
