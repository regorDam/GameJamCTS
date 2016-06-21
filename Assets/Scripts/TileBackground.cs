using UnityEngine;
using System.Collections;

public class TileBackground : MonoBehaviour 
{
    Color color = Color.blue;
    float fColor = 0f;
    float fNumber = 0f;
    bool op = true;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        fColor += 0.01f * Time.deltaTime ;

        Vector2 calc = Vector2.zero;

        if (fNumber <= 0.3)
            op = true;
        if (fNumber >= 0.85)
            op = false;
        if(op)
            fNumber += 0.15f * Time.deltaTime;
        else
            fNumber -= 0.35f * Time.deltaTime;
 
        
        color = Color.HSVToRGB(fColor, 1, fNumber, true);
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");
        rend.material.SetColor("_EmissionColor", color);

        if(fColor > 256)
        {
            fColor = 0;
        }
        
        //Debug.Log(color);
	
	}
}
