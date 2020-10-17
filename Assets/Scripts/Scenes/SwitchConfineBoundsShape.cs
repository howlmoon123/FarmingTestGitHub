using Cinemachine;
using System;
using UnityEngine;

public class SwitchConfineBoundsShape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SwitchBoundingShape();
    }

    /// <summary>
    /// Switches the confiner that the cinemachine uses to define screen shape.
    /// </summary>
    private void SwitchBoundingShape()
    {
        //Get polygon collider used by cinemachine
        PolygonCollider2D polygonCollider2D =  GameObject.FindGameObjectWithTag(Tags.BoundConfiner).GetComponent<PolygonCollider2D>();
        CinemachineConfiner cinemachineConfiner = GetComponent<CinemachineConfiner>();
        cinemachineConfiner.m_BoundingShape2D = polygonCollider2D;

        //Special function to clear cache
        cinemachineConfiner.InvalidatePathCache();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
