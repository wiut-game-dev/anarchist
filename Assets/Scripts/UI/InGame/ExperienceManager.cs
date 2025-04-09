using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Slider slider;
    public int currentLevel;
    public int totalExperience;
    public int previousLevelExperience;
    public int nextLevelExperience;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI experienceText;

    void Start()
    {
        SetMaxValue(nextLevelExperience);
        SetValue(totalExperience);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddExperience(10);
        }
    }

    public void ChangeLevelVariable()
    {
        previousLevelExperience = nextLevelExperience;
        nextLevelExperience += ((currentLevel + 1) * 100);
    }

    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }   
    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    public void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelExperience)
        {
            currentLevel++;
            ChangeLevelVariable();
            UpdateLevel();
        }
    }


    public void UpdateLevel()
    {
        nextLevelExperience -= previousLevelExperience;
        totalExperience -= previousLevelExperience;
        UpdateInterface();
    }

    public void UpdateInterface()
    {
        levelText.text = currentLevel.ToString() + " level";
        experienceText.text = totalExperience.ToString() + " exp" + " / "  + nextLevelExperience.ToString() + " exp";
        SetMaxValue(nextLevelExperience);
        SetValue(totalExperience);
    }
}
