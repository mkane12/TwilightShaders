using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twilight_twocolor : MonoBehaviour
{
    // pass colors to shader for a two-color gradient
    public Material gradient;
    public Color32 bottomColor = new Color32(255, 157, 0, 1);
    public Color32 topColor = new Color32(25, 53, 193, 1);

    // Start is called before the first frame update
    void Start()
    {
        gradient.SetColor("_Color0", bottomColor);
        gradient.SetColor("_Color1", topColor);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
