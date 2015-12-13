using UnityEngine;
using System.Collections;

public class ChangeWaterOffset : MonoBehaviour 
{
    public Renderer water;

    public float MainOne;
    public float MainTwo;
    public float SecondOne;
    public float SecondTwo;

	// Use this for initialization
	void Start () 
	{

	}


	// Update is called once per frame
	void Update () 
	{
        water.material.mainTextureOffset = new Vector2(MainOne, Time.time / MainTwo);
        water.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(SecondOne, Time.time / SecondTwo));
	}
}
