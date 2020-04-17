using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class twilight_clickCircle : MonoBehaviour
{
    // pass colors to shader for a two-color gradient
    public Material gradient;
    public Color32 middleColor = new Color32(255, 157, 0, 1);
    public Color32 outerColor = new Color32(25, 53, 193, 1);
    // position of user click
    public Vector3 clickPos = new Vector4(0.5f, 0.5f, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // set initial colors
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

    // called on click
    void OnMouseDown()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast (ray, out hit))
        {
            // This plane is scaled evenly on x and z axes, but in case it's not in the future, we standardize the code

            // Trying to universalize variables, since plane was rotated, then camera rotated. 
            // But localScale and raycasthits don't have the nice "forward"/"right" variables that GameObject transforms have...

            // screen coordinates range from (-25, -25) on lower left to (25, 25) on upper right.
            // We start by making it all positive
            clickPos = new Vector3(hit.point.x + this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z, 
                hit.point.z + this.transform.localScale.x * this.transform.localScale.y * this.transform.localScale.z, 
                clickPos.z);
            // next, we need to scale so it ranges from (0, 0) to (1, 1), instead of (0, 0) to (50, 50)
            clickPos.x = clickPos.x / (this.transform.localScale.x * this.transform.localScale.z * 2);
            clickPos.y = clickPos.y / (this.transform.localScale.x * this.transform.localScale.z * 2);

            // only change center if user clicked plane
            Debug.Log(clickPos);
            gradient.SetVector("_Pos", clickPos);
        }
        
    }
}
