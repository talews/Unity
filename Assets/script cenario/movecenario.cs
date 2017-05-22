using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecenario : MonoBehaviour {


    private Material materialatual;
    public float velocidadeX, VelocidadeY;
    private float escalademovimento;
    
	// Use this for initialization
	void Start () {

        materialatual = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        escalademovimento = escalademovimento + 0.01f;
        materialatual.SetTextureOffset("_MainTex", new Vector2(escalademovimento * velocidadeX, escalademovimento * VelocidadeY));

	}
}
