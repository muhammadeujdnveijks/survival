using System;
using System.Collections.Generic;
using UnityEngine;

public class TerrainChecker : MonoBehaviour
{
    [SerializeField] private Vector3 coneDirection = Vector3.down;
    [SerializeField] private float coneAngle = 45f;
    [SerializeField] private float rayLength = 1f;
    [SerializeField] private int rayCount = 400;
    [SerializeField] private Vector3 offset;
    public bool IsColayder { get; private set; } = false;

    private List<Vector3> coneDirections = new List<Vector3>();

    void Start()
    {

        GenerateConeDirections(coneDirection.normalized);
    }

    private void Luch(List<Vector3> directions)
    {
        foreach (Vector3 luch in directions)
        {
            RaycastHit jump;
            if (Physics.Raycast(transform.position + offset, luch, out jump, 1.05f))
            {
                IsColayder = true;
                return;
            }
        }

        IsColayder = false;
    }

    void Update()
    {
        DrawCone(transform.position + offset, coneDirections, rayLength);

    }

    private void FixedUpdate()
    {
        Luch(coneDirections);
    }

    void GenerateConeDirections(Vector3 direction)
    {
        coneDirections.Clear();

        int rings = 10; 
        int segmentsPerRing = rayCount / rings;

        Quaternion toDirection = Quaternion.FromToRotation(Vector3.forward, direction.normalized);
        float maxAngle = coneAngle;

        for (int ring = 0; ring < rings; ring++)
        {
            float ringAngle = Mathf.Lerp(0f, maxAngle, (float)ring / (rings - 1));
            for (int seg = 0; seg < segmentsPerRing; seg++)
            {
                float azimuth = 360f * seg / segmentsPerRing;

                Quaternion rot = Quaternion.Euler(ringAngle * Mathf.Sin(azimuth * Mathf.Deg2Rad),
                                                  ringAngle * Mathf.Cos(azimuth * Mathf.Deg2Rad),
                                                  0f);

                Vector3 localDir = rot * Vector3.forward;
                Vector3 worldDir = toDirection * localDir.normalized;

                coneDirections.Add(worldDir);
            }
        }
    }

    void DrawCone(Vector3 origin, List<Vector3> directions, float length)
    {
        foreach (Vector3 dir in directions)
        {
            Debug.DrawRay(origin, dir * length, Color.red);
        }
    }
}
