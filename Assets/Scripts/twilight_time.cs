using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twilight_time : MonoBehaviour
{
    // pass colors to shader for a two-color gradient that changes over time
    public Material gradient;

    public Color32 bottomColor1 = new Color32(255, 157, 0, 1);
    public Color32 bottomColor2 = new Color32(88, 128, 214, 1);

    public Color32 topColor1 = new Color32(25, 53, 193, 1);
    public Color32 topColor2 = new Color32(0, 221, 255, 1);

    // Start is called before the first frame update
    void Start()
    {
        gradient.SetColor("_Color0", bottomColor1);
        gradient.SetColor("_Color1", topColor1);
    }

    // Update is called once per frame
    void Update()
    {
        gradient.SetColor("_Color0", Color.Lerp(bottomColor1, bottomColor2, Mathf.PingPong(Time.time, 1)));
        gradient.SetColor("_Color1", Color.Lerp(topColor1, topColor2, Mathf.PingPong(Time.time, 1)));
    }

    // OnValidate() called when script is loaded or value cahnged in the Inspector
    void OnValidate()
    {
        // ensure any changes made during runtime are reflected
        gradient.SetColor("_Color0", bottomColor1);
        gradient.SetColor("_Color1", topColor1);
    }
}
