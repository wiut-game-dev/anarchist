using System;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class SaveButtonBuff : MonoBehaviour
{
	public TMP_Dropdown VariableDropdown;

	public TMP_InputField ValueInput;
	public TMP_InputField DurationInput;

	public Toggle PermanentToggle;

	public TempAbilityData data;

	public TMP_Text MessageBox;

	public void SaveTempData()
	{
		try
		{
			data.AbilityType = AbilityType.Buff;
			data.BuffValue = int.Parse(ValueInput.text);
			switch(VariableDropdown.value)
			{
				case 1:
					data.BuffVariable = Variable.Health;
					break;
				case 2:
					data.BuffVariable = Variable.Mana;
					break;
				case 3:
					data.BuffVariable = Variable.Attack;
					break;
				case 4:
					data.BuffVariable = Variable.AttackSpeed;
					break;
				case 5:
					data.BuffVariable = Variable.ManaRecovery;
					break;
				case 6:
					data.BuffVariable = Variable.MaxHealth;
					break;
				case 7:
					data.BuffVariable = Variable.MaxMana;
					break;
				case 8:
					data.BuffVariable = Variable.Speed;
					break;
			}
			data.BuffType = PermanentToggle.isOn ? BuffType.Permanent : BuffType.Temporary;
			if(data.BuffType == BuffType.Temporary)
				data.BuffDuration = int.Parse(DurationInput.text);
		}
		catch(Exception ex)
		{
			MessageBox.text = ex.Message;
		}
	}
}