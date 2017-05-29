using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private int presentes;
    public Text presenteTxt;
    public Animator  Anime;
    public Rigidbody2D PlayerRigibody;
    public int ForceJump;
   // public bool jump;
    public bool slide;

    //Verifica o chão
    public Transform GroundCheck;
    public bool ground;
    public LayerMask whatisground;

    //Slide
    public float SlideTemp;
    public float TimeTemp;
    //colisor
    public Transform colisor;
    public GameObject particula;
 
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump" )&& ground == true)
        {
            PlayerRigibody.AddForce(new Vector2(0,ForceJump));
            // jump = true;
            if (slide == true)
            {
                slide = false;
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.355f);
            }
          
        }
        if (Input.GetButtonDown("Slide") && ground == true)
        {
            colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.355f);
            slide = true;
            TimeTemp = 0;
        }

        ground = Physics2D.OverlapCircle(GroundCheck.position,0.2f, whatisground); //Verificar se tem colisão com o chão

        if (slide == true)//Termina o Slide
        {
            TimeTemp += Time.deltaTime; //Calcular o tempo em cada frame
            if (TimeTemp >= SlideTemp)  //quando o tempo for alcançado ele volta ao normal
            {
                colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.355f);
                slide = false;
            }
        }

        Anime.SetBool("jump", !ground);      //a exclação torna o valor negativo,Passar valores para a variavel Anime
        Anime.SetBool("slide", slide);    
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "presente")
        {
            
            presentes += 1;
            presenteTxt.text = presentes.ToString();
             
            Destroy(col.gameObject);
            Instantiate(particula, col.transform.position, col.transform.rotation);
            
           
            
           



        }
        
    }
}

