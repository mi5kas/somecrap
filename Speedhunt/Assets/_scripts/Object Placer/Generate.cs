using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public int baseStartX = -5;
    public int baseStartY = 5;
    public int baseEndX = 5;
    public int baseEndY = -5;
    public int r = 2;
    public int objCOunt = 5;

    public GameObject[] toPlace;

    int randomX;
    int randomY;
    List<Coordinate> coordinates = new List<Coordinate>();

    private void Start()
    {
        BoxCollider colliderObj = this.GetComponent<BoxCollider>();
        baseStartX = Mathf.RoundToInt(this.transform.position.x-colliderObj.size.x*0.5f);
        baseStartY = Mathf.RoundToInt(this.transform.position.z-colliderObj.size.z*0.5f);
        baseEndX = Mathf.RoundToInt(this.transform.position.x+colliderObj.size.x*0.5f);
        baseEndY = Mathf.RoundToInt(this.transform.position.y+colliderObj.size.z*0.5f);
        while(coordinates.Count != objCOunt)
        {
            randomX = Random.Range(baseStartX, baseEndX + 1);
            randomY = Random.Range(baseEndY, baseStartY + 1);
            if (randomX % r == 0 && randomY % r == 0 && !coordinates.Contains(new Coordinate(randomX, randomY)))
            {
                int whichToPlace = Random.Range(0, toPlace.Length);
                coordinates.Add(new Coordinate(randomX, randomY));
                Instantiate(toPlace[whichToPlace], new Vector3(randomX, toPlace[whichToPlace].transform.position.y, randomY), Quaternion.Euler(0, Random.Range(0, 360f), 0));
            }
        }                 
    }   
}
