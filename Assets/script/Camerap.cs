using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerap : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;

    private void FixedUpdate(){

        transform.position = new Vector3(target.position.x, target.position.y,-5f) + offset;
    }
}
