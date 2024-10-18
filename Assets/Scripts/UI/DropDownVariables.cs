using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDownVariables : MonoBehaviour
{
    public TempBuffData TempBuff;
    public InputField input;
    public Toggle permanent;

    public void Permanentce()
    {
        if(permanent.isOn)
        {
            VariableChooserPerm();
        }
        else
        {
            VariableChooserTemp();
        }
    }

    public void VariableChooserPerm()
    {
        int variable = 0;
        if(variable == 0) //HealthPoints
        {  
            
        }
    }

    public void VariableChooserTemp()
    {

    }
    
}
