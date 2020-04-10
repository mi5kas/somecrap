using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setVariable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] string variableName;
    [SerializeField] int variableValue;
    void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        if (variableName == "Money")
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + variableValue);
        else
            PlayerPrefs.SetInt(variableName, variableValue);
    }
    // Update is called once per frame
}
