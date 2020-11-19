






















using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ltwo : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float dis = 100;
    public Transform firePoint;
    public LineRenderer linerend;
    Transform trans;
    public int damage = 50;
    // public LineRenderer linerenderer; 
    // Update is called once per frame

    private void Awake(){
        trans = GetComponent<Transform>();
    } 

    void Update()
    {
        Shoot(); 
        // if( Input.GetButtonDown("Fire1")){  
        //       Shoot();        }
    }

    void Shoot(){

        // Debug.DrawRay( firePoint.position , firePoint.TransformDirection( Vector2.up)*10f , Color.red);
        // RaycastHit2D hitinfo = Physics2D.Raycast( firePoint.position, firePoint.TransformDirection( Vector2.up) ,10f);

        if( Physics2D.Raycast( trans.position , transform.right)){

            RaycastHit2D hit = Physics2D.Raycast( firePoint.position, transform.right);
            Draw2DRay( firePoint.position , hit.point);
        }
        else{
            Draw2DRay( firePoint.position , firePoint.transform.right*dis);
        }

        void Draw2DRay( Vector2 start , Vector2 end){

            linerend.SetPosition( 0, start);
            linerend.SetPosition( 1, end);
        }

        // if( hitinfo){
        //     Debug.Log( hitinfo.collider.name);
        //     // if( hitinfo.collider ==)

        //     asteroid a1 = hitinfo.transform.GetComponent<asteroid>();
        //     if( a1 != null){
        //         a1.takeDamage(damage);
        //     }

        //     // linerenderer.SetPosition(0, firePoint.position);
        //     // linerenderer.SetPosition( 1, hitinfo.point);
        // }

        // else{
        //     linerenderer.SetPosition(0, firePoint.position);
        //     linerenderer.SetPosition( 1, firePoint.position + firePoint.right* 100);
        // }

        // linerenderer.enabled = true;
        // yield return 0;
        // linerenderer.enabled = false;
    }


    
}
