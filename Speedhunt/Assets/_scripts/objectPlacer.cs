using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPlacer : MonoBehaviour
{
    [SerializeField] Transform thisObject;
    [SerializeField] Vector2 pointA;
    [SerializeField] Vector2 pointB;
    [SerializeField] int objectCount;
    [SerializeField] float range;

    // Start is called before the first frame update
    void Start()
    {
        PlaceObjects(pointA, pointB, objectCount, range);
    }
    void PlaceObjects(Vector2 point1, Vector2 point2, int objCount, float r)
    {
        float howManyFit = Mathf.Abs(point1.x-point2.x)*Mathf.Abs(point1.y-point2.y)/(r*r);
        Vector2[] usedCoordinates = new Vector2[objCount];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
