﻿using System.Collections;
using UnityEngine;
using UnityEditor;

/*
[CustomEditor(typeof(CameraEnemy))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        CameraEnemy fow = (CameraEnemy)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up * 10, Vector3.forward, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);
        Handles.color = Color.red;
    }
}
*/
