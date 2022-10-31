using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUnit : MonoBehaviour,IColorAccessible
{
    public int id;

    public string colorName;

    public int GetColorId()
    {
        return id;
    }
}
