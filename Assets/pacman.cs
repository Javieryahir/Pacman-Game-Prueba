using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pacman : MonoBehaviour
{
     public float maxspeed = 100f;
    public float dir = 1;
    public float speed;
    public float sped;
    public Rigidbody2D dri;
    public int respawn;
    public Text puntuacion;
    public int puntuacionva;
    public GameObject screenperdiste;
    // Start is called before the first frame update
    public void Start()
    {
          
           dri = GetComponent<Rigidbody2D>();
       
           
           screenperdiste.SetActive(false);

           if(Time.timeScale == 0){
                        Time.timeScale = 1;


                    }
      
        
    }
    void FixedUpdate(){
        //Agregar controles del juego pacman
        
        if (Input.GetKey("up"))
        {
            MoveArriba();
            congelarX();
        }

        if (Input.GetKey("down"))
        {
            MoverAbajo();
            congelarX();
        }
        if (Input.GetKey("left"))
        {
            Moverizquierda();
            congelar();
        }

        if (Input.GetKey("right"))
        {
            MoverDerecha();
            congelar();
        }
    }
   
    
    void Update(){
        //Textos
        puntuacion.text = "Puntuacion:" + puntuacionva;

        if(puntuacionva >= 130){
            screenperdiste.SetActive(true);
            if(Time.timeScale == 1){
                        Time.timeScale = 0;


                    }
        }
    }
    // Update is called once per frame
    public  void MoverDerecha()
    {
          dri.AddForce(Vector2.right * speed *Time.deltaTime); 
        float limitedspeed = Mathf.Clamp(dri.velocity.x, maxspeed, speed);
        dri.velocity = new Vector2( limitedspeed, dri.velocity.y); 
          
          
          
    }
       

        
        
        
        
        
       
         
         
    
    public void Moverizquierda(){
         dri.AddForce(Vector2.right * sped * Time.deltaTime);
        float limitedspeed = Mathf.Clamp(dri.velocity.x, -maxspeed, sped);
        dri.velocity = new Vector2( limitedspeed, dri.velocity.y);
         
        
    }
          
       
         
        
        
    
    public void MoverAbajo(){
        dri.AddForce(Vector2.up * sped * Time.deltaTime);
        float limitedspeed = Mathf.Clamp(dri.velocity.y, -maxspeed, sped);
        dri.velocity = new Vector2( dri.velocity.x,limitedspeed);
        
        
          

        

    }
    public void MoveArriba(){
        dri.AddForce(Vector2.up * speed * Time.deltaTime);
        float limitedspeed = Mathf.Clamp(dri.velocity.y, maxspeed, speed);
        dri.velocity = new Vector2( dri.velocity.x,limitedspeed);
        
        

    }
    public void congelar(){
        dri.constraints = RigidbodyConstraints2D.FreezePositionY;

    }
    public void congelarX(){
        dri.constraints = RigidbodyConstraints2D.FreezePositionX;
        

    }
    public void OnTriggerEnter2D(Collider2D jugador){
        if(jugador.gameObject.tag == "cookie"){
            Destroy(jugador.gameObject);
            puntuacionva ++;
        }
        

    }
    public void mainmen()
    {
        SceneManager.LoadScene("SampleScene");
          if(Time.timeScale == 0){
                        Time.timeScale = 1;


                    }
    }
    
}
