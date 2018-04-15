using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Variables._Definitions;

public class TextFieldUpdater : MonoBehaviour
{
    private Text text;
    public StringVariable stringVariable;


    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = stringVariable.Value;
    }
}
