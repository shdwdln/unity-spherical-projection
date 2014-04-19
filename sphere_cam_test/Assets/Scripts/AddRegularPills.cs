﻿using UnityEngine;
using System.Collections;

public class AddRegularPills : MonoBehaviour
{

    public GameObject pillObject;
    private float latitudeMin = GlobalGameDetails.minAngleY;
    private float latitudeMax = GlobalGameDetails.maxAngleY;

    private float gridSpacing = GlobalGameDetails.cellSpacing;

    void Start ()
    {

        Map map = new Map ("map1");

        int pillCount = 0;

        for (int gridX = 0; gridX < GlobalGameDetails.mapColumns; gridX++) {
            for (int gridY = 0; gridY < GlobalGameDetails.mapRows; gridY++) {
                if (map.PillAtGridReference (gridX, gridY)) {
                    float[] latLongRef = map.LatitudeLongitudeAtGridReference (gridX, gridY);
                    float latitude = latLongRef [0];
                    float longitude = latLongRef [1];

                    Debug.Log ("Placing pill at latitude: " + latitude + ", longitude: " + longitude);
                    SphericalCoordinates sc = new SphericalCoordinates (
    					0.5f, 
    					degreesToRadians (longitude), 
    					degreesToRadians (latitude),
    					0f, 10f, 0f, (Mathf.PI * 2f), -(Mathf.PI / 3f), (Mathf.PI / 3f)
                    );
                    Vector3 newPillPosition = sc.toCartesian;
                    GameObject pill = Instantiate (pillObject) as GameObject;
                    pillCount++;
                    pill.transform.parent = transform;
                    pill.transform.localPosition = newPillPosition;
                }
            }
        }
        Debug.Log ("Created " + pillCount + " pills");
    }

    float degreesToRadians (float degrees)
    {
        return (degrees * Mathf.PI / 180f);
    }
	
}
