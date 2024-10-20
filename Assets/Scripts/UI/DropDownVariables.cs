 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DropDownVariables : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TempBuffData TempBuff;
    public TMP_InputField input;
    public Toggle permanent = null;
    public bool Current;
    public bool Final;

    public int GetValue()
    {
        return dropdown.value;
    }

    public void Permanentce()
    {
        if(permanent.isOn)
        {
            VariableChooserPerm(GetValue());
        }
        else
        {
            VariableChooserTemp();
        }
    }

    public void CurrentOrFinal()
    {
        if(Current)
        {
            VariableChooserPerm(1);
        }
        if(Final)
        {
            VariableChooserPerm(0);
        }
    }

    public void VariableChooserPerm(int variable)
    {
        switch (variable)
        {
            case 1: variable = 0; break;
        }
        
    }

    public void VariableChooserTemp()
    {

    }

    public void VariableChooserCurrent()
    {

    }

    public void VariableChooserFinal()
    {

    }
    
}
