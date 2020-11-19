using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
// using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework;

public class SpaceController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    public float speed = 0.8f;
   public float maxVelocity = 1.3f;
   public float rotatespeed = 3f;
   public int key = 0;
    public ParticleSystem particles1;
     public ParticleSystem particles2;
     public ParticleSystem left;
     public ParticleSystem right;
     public ParticleSystem rotateL;
     public ParticleSystem rotateR;
      public ParticleSystem backo;
       public ParticleSystem backt;

    public AudioClip blastship;
    public AudioClip exaust;
    public AudioClip sideexaust;
    public bool isthistheend = false;

    public Transform explosion;
    
    #region Monobehaviour API


    // Start is called before the first frame update



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        AudioSource asteroidBlast1 = GetComponent<AudioSource>();
        AudioSource sidesound = GetComponent<AudioSource>();
       // Debug.Log(" my position ");
        //Debug.Log(rb.transform.position.x);
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        bool w = Input.GetKeyDown(KeyCode.R);
        bool s = Input.GetKeyDown(KeyCode.F);



        if (Input.GetKeyDown(KeyCode.D)){

            rb.velocity = new Vector2 ( rb.velocity.x,speed * -1);
                left.Play();
                sidesound.PlayOneShot(sideexaust);
        }
        if( Input.GetKeyUp(KeyCode.D)){
                rb.velocity = new Vector2 ( rb.velocity.x,0);
                
                left.Stop();
                }

        if (w)
        {

            rb.AddTorque(-2.0f, ForceMode2D.Force);
            left.Play(); sidesound.PlayOneShot(sideexaust);
        }
        if (s)
        {
            rb.AddTorque(2.0f, ForceMode2D.Force);

            right.Play(); sidesound.PlayOneShot(sideexaust);
        }

        if (Input.GetKeyDown(KeyCode.A)){
           
             rb.velocity = new Vector2 ( rb.velocity.x ,speed);
             right.Play();
            sidesound.PlayOneShot(sideexaust);
        }
            
        if( Input.GetKeyUp( KeyCode.A)){
                rb.velocity = new Vector2 ( rb.velocity.x ,0);
                right.Stop();
        }
        if( xAxis >0 && !rotateL.isPlaying){
            rotateL.Play();
            sidesound.PlayOneShot(sideexaust);
        }


        else if( xAxis <0 && !rotateR.isPlaying){

            rotateR.Play();
            sidesound.PlayOneShot(sideexaust);
        }

        else if( xAxis == 0) {
            rotateR.Stop();
            rotateL.Stop();
        }
        // else if( rotateL.isPlaying){
        //     rotateL.Stop();
        // }

        // else if( rotateR.isPlaying){
        //     rotateR.Stop();
        // }


        if( yAxis > 0 && !particles1.isPlaying){

            particles1.Play();
            particles2.Play();

            asteroidBlast1.PlayOneShot(exaust);

        }
        if ( yAxis <0 && !backo.isPlaying){
            backo.Play();
            backt.Play();
            sidesound.PlayOneShot(sideexaust);
        }
        else if( yAxis <=0 && particles1.isPlaying){
            particles1.Stop();
            particles2.Stop();
        }

        else if( yAxis >=0 && backo.isPlaying){
            backo.Stop();
            backt.Stop();
        }

        ThrustForward(Mathf.Min(yAxis , maxVelocity));
       // if( xAxis <0 || xAxis >0 )rb.AddTorque(-1*xAxis, ForceMode2D.Force); this good torque effect
        Rotate(transform , xAxis * -rotatespeed);
        if (gameObject == null) Debug.Log(" think");
        // rb.MoveRotation( rb.rotation + ( -xAxis* rotatespeed) * Time.fixedDeltaTime);
    }


    #endregion

    #region Maneuvering API

    void OnTriggerEnter2D(Collider2D col)
    {
        
        AudioSource asteroidDestroyed = GetComponent<AudioSource>();
        //Debug.Log(col.gameObject.name + " : " + gameObject.name);
        if( gameObject.name == "spaceship")
        {
            Debug.Log("blast it");
            asteroidDestroyed.PlayOneShot(blastship);
            if (explosion)
            {
                isthistheend = true;
                GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
                Destroy(exploder, 1.0f);

            }

            Destroy(gameObject);
        }

        SceneManager.LoadScene("gameover");
        //Destroy(gameObject);

    }

    void ClampVelocity(){
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp( rb.velocity.y ,-maxVelocity ,maxVelocity);

        rb.velocity = new Vector2( x,y);
    }

    void ThrustForward( float amount){

        Vector2 force = transform.up * amount;

        rb.AddForce( force);
    }

    private void Rotate( Transform t ,float amount){
        float s = 0.3f;
        t.Rotate( 0,0,amount*s);
    }

    #endregion
}

