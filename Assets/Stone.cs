using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Stone : MonoBehaviour
{
    public HandTracking handTracking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slot"))
        {
            this.gameObject.transform.parent = other.gameObject.transform;
            this.gameObject.transform.localPosition = Vector3.zero;
            other.GetComponent<Collider>().enabled = false;
            handTracking.SetStone(gameObject.name);
            //this.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
        }
    }
}
