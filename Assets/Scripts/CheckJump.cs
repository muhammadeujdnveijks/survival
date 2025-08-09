using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CheckJump : MonoBehaviour
{
    [SerializeField] private Vector3 Nnapravlenie;
    [SerializeField] private float ugol;
    [SerializeField] private float dlina;
    private List<Vector3> spisokluch = new List<Vector3>();
    [SerializeField] private int luchiki;
    void Start()
    {
        
    }

    void jenirate()
    {
        spisokluch.Clear();
        int kolichestvo = 5;
        int sigmente = luchiki / kolichestvo;
    }

    void Update()
    {
        jenirate();
    }
}
