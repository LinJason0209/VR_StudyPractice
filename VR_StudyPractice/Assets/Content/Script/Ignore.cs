using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore : MonoBehaviour
{
    public int PlayerLayer;
    public int grabbleLayer;
    // Start is called before the first frame update
    void Start()
    {
        ignore();
        //ignoreCollision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ignore()
    {
        Physics.IgnoreLayerCollision(PlayerLayer,grabbleLayer);
    }
    public void ignoreCollision()
    {
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Default"), LayerMask.NameToLayer("Grabbable"));
    }
}
