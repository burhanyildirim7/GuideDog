using UnityEngine;

public class TailDemo_TailCutId : MonoBehaviour
{
    public int index;
    public TailDemo_SegmentedTailGenerator owner;
    


    //void OnMouseDown()
    //{ 
    //    if (owner)
    //    {
    //        owner.ExmapleCutAt(index);
    //        Destroy(this);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
  
        //if (other.gameObject.tag == "Obstacle" && index > 1)
        //{
           
        //        owner.ExmapleCutAt(index);
       
        //        Destroy(this);
                
        //}

    }
}
