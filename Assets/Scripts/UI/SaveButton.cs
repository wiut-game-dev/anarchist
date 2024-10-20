using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public TempBuffData TempBuff;
    public TMP_InputField input;
    public Toggle toggle;

    
    public void Permanentce()
    {

    }

    public void VariableCurrent(int variable)
    {
        variable = dropdown.value;

        switch (variable)
        {
            case 1: TempBuff.Variable = Variable.Health; break;
            case 2: TempBuff.Variable = Variable.Mana; break;
            case 3: TempBuff.Variable = Variable.Attack; break;
            case 4: TempBuff.Variable = Variable.AttackSpeed; break;
            case 5: TempBuff.Variable = Variable.ManaRecovery; break;
            case 6: TempBuff.Variable = Variable.MaxHealth; break;
            case 7: TempBuff.Variable = Variable.MaxMana; break;
            case 8: TempBuff.Variable = Variable.Speed; break;
        }
    }
}
