using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class IndicatorPointer : MonoBehaviour
{
    [SerializeField]
    private Transform targetPillar;
    [SerializeField]
    private Transform indicator;
    private float angle;
    private PillarBehavior thisPillar;
    void OnEnable()
    {
        //checks if the target pillar has pillar script, and then caches it. 
        if(targetPillar.gameObject.TryGetComponent<PillarBehavior>(out PillarBehavior pillar))
        {
            thisPillar = pillar;
        }
    }
    //Rotates the indicator to point at the target pillar. 
    void Update()
    {
        angle = Mathf.Rad2Deg * Mathf.Atan2( targetPillar.position.y - indicator.position.y, targetPillar.position.x - indicator.position.x);
        indicator.rotation = Quaternion.Euler(new Vector3(0,0,angle));
        if(thisPillar.pillarActivated)
        {
            Destroy(this.gameObject);
        }
        
    }

}
