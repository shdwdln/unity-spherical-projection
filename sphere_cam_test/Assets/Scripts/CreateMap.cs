﻿using UnityEngine;
using System.Collections;

public class CreateMap : MonoBehaviour
{

    public Color gridColor = Color.grey;

    public int xOffset;
    public int yOffset;
    public bool enableGridLines;

    // Use this for initialization
    void Start ()
    {

        Map map = new Map (GlobalGameDetails.mapName);

        Texture2D texture = map.UVMappedTexture (360 * 5, 180 * 5, xOffset, yOffset, enableGridLines);

        texture.Apply ();
        renderer.material.mainTexture = texture;

    }

}
