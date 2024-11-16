using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class Tabbing : MonoBehaviour
{
    public InputField nextField;
    InputField myField;

    void Start()
    {
        if (nextField == null) 
        {
            Destroy(this);
            return;
        }
        myField = GetComponent<InputField>();
    }

    void Update()
    {
        if (myField.isFocused && Input.GetKeyDown(KeyCode.Tab)) 
        {
            nextField.ActivateInputField();
        }
    }
}
