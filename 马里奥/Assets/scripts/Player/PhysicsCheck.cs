using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 bottomOffset;
    public float checkRadius;
    public LayerMask groundLayer;
    public bool isGround;
    
    // Update is called once per frame
    private void Update()
    {
        Check();
    }

    public void Check()//ºÏ≤‚µÿ√Ê
    {
      isGround =  Physics2D.OverlapCircle((Vector2)transform.position +bottomOffset, checkRadius,groundLayer);
        
    }

    private void OnDrawGizmosSelected()             //ÃΩ≤‚œﬂ
    {
        //Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRadius);
    }
}
