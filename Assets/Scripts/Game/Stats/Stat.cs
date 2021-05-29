using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private Text statValue;
    [SerializeField]
    private int baseValue;
    [SerializeField]
    private float lerpSpeed;
    private float currentFill;
    public float MyMaxValue { get; set; }
    private float currentValue;
    private List<int> modifiers = new List<int>();


    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }
            currentFill = currentValue / MyMaxValue;
            statValue.text = currentValue + "/" + MyMaxValue;
        }

    }

    // Use this for initialization
    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}

