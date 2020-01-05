﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI(){
        MapGenerator MapGen = (MapGenerator)target;
        if(DrawDefaultInspector()){
            if(MapGen.autoUpdate){
                MapGen.DrawMapInEditor();
            }
        }

        if(GUILayout.Button("Generate")){
            MapGen.DrawMapInEditor();
        }
    }
}
