using System;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private RotationAngle neededAngle;
    [SerializeField] private Material newMaterial;
    [SerializeField] private List<GameObject> meshRenderer;

    public float NeededAngle => (float) neededAngle;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Figure"))
        {
            foreach (var m in meshRenderer)
            {
                m.GetComponent<MeshRenderer>().material = newMaterial;
            }
        }
    }
}

public enum RotationAngle
{
    Forward = 0,
    Right = 90,
    Backward = 180,
    Left = 270
}
