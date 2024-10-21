using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;


public class SaveButton : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public AbilityTempData data;
    public TMP_InputField input;
    public Toggle toggle;
    public GameObject currentPanel;

    public void CheckingCurrentUsedPanel()
    {

    }

    public void Permanence()
    {

    }

    public void VariableCurrent(int variable)
    {
        variable = dropdown.value;
        int value;
        int.TryParse(input.text, out value);

        switch (variable)
        {
            case 0: data.SpellEffectVariableCurrent = Variable.Health; break;
        }
    }
}
