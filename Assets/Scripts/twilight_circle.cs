using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twilight_circle : MonoBehaviour
{
    // pass colors to shader for a two-color gradient
    public Material gradient;
    public Color32 middleColor = new Color32(255, 157, 0, 1);
    public Color32 outerColor = new Color32(25, 53, 193, 1);

    // Start is called before the first frame update
    void Start()
    {
        gradient.SetColor("_Color0", middleColor);
        gradient.SetColor("_Color1", outerColor);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // OnValidate() called when script is loaded or value cahnged in the Inspector
    void OnValidate()
    {
        // ensure any changes made during runtime are reflected
        gradient.SetColor("_Color0", middleColor);
        gradient.SetColor("_Color1", outerColor);
    }
}
