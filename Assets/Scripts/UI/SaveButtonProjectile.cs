using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class SaveButtonProjectile : MonoBehaviour
{

	public TMP_Dropdown VariableCurrentDropdown;
	public TMP_Dropdown VariableFinalDropdown;

	public TMP_InputField ValueCurrentInput;
	public TMP_InputField ValueFinalInput;

	public TMP_InputField DamageInput;
	public TMP_InputField Radius_or_HeightInput;
	public TMP_InputField WidthInput;

	public TMP_InputField DurationInput;
	public TMP_InputField SpeedInput;
	public TMP_InputField LifeTimeInput;

	public TMP_InputField TimesInput;
	public TMP_InputField TravelDistanceInput;

	public Toggle ToggleTrackMouse;

	public AbilityTempData data;

	public TMP_Text MessageBox;

	public void SaveTempData()
	{
		try
		{
			#region VariableCurrent
			switch(VariableCurrentDropdown.value)
			{
				case 1:
					data.SpellEffectVariableCurrent = Variable.Health;
					break;
				case 2:
					data.SpellEffectVariableCurrent = Variable.Mana;
					break;
				case 3:
					data.SpellEffectVariableCurrent = Variable.Attack;
					break;
				case 4:
					data.SpellEffectVariableCurrent = Variable.AttackSpeed;
					break;
				case 5:
					data.SpellEffectVariableCurrent = Variable.ManaRecovery;
					break;
				case 6:
					data.SpellEffectVariableCurrent = Variable.MaxHealth;
					break;
				case 7:
					data.SpellEffectVariableCurrent = Variable.MaxMana;
					break;
				case 8:
					data.SpellEffectVariableCurrent = Variable.Speed;
					break;
			}
			#endregion
			#region VariableFinal
			switch(VariableFinalDropdown.value)
			{
				case 1:
					data.SpellEffectVariableFinal = Variable.Health;
					break;
				case 2:
					data.SpellEffectVariableFinal = Variable.Mana;
					break;
				case 3:
					data.SpellEffectVariableFinal = Variable.Attack;
					break;
				case 4:
					data.SpellEffectVariableFinal = Variable.AttackSpeed;
					break;
				case 5:
					data.SpellEffectVariableFinal = Variable.ManaRecovery;
					break;
				case 6:
					data.SpellEffectVariableFinal = Variable.MaxHealth;
					break;
				case 7:
					data.SpellEffectVariableFinal = Variable.MaxMana;
					break;
				case 8:
					data.SpellEffectVariableFinal = Variable.Speed;
					break;
			}
			#endregion

			data.SpellEffectValueCurrent = int.Parse(ValueCurrentInput.text);
			data.SpellEffectValueFinal = int.Parse(ValueFinalInput.text);
			data.SpellDamage = int.Parse(DamageInput.text);
			data.HitBoxRadius_or_Height = int.Parse(Radius_or_HeightInput.text);
			data.HitBoxWidth = int.Parse(WidthInput.text);
			data.SpellEffectDuration = float.Parse(DurationInput.text);
			data.ProjectileSpeed = float.Parse(SpeedInput.text);
			data.ProjectileLifeTime = float.Parse(LifeTimeInput.text);
			data.SpellEffectTimes = int.Parse(TimesInput.text);
			data.ProjectileTravelDistance = float.Parse(TravelDistanceInput.text);

			data.AbilityType = AbilityType.Spell;
			data.ProjectileTrackMouse = ToggleTrackMouse.isOn;
			data.SpellType = SpellType.Projectile;
		}
		catch(Exception ex)
		{
			MessageBox.text = ex.Message;
		}
	}
}
