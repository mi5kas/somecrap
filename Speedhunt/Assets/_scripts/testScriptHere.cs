using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScriptHere : MonoBehaviour
{

     [SerializeField] DamagerLevel[] voKiek;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
 [System.Serializable] 
public class DamagerLevel
 {
     public float neededDamageInPercentage = 50f;
     public int kiekSudu;
     Sprite damageSprite;
 }
