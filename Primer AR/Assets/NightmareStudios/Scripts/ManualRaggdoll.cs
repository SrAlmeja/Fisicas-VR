using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualRaggdoll : MonoBehaviour
{
    public GameObject ragdoll;
    public GameObject referene;

    List<ConfigurableJoint> configurableJoints;
    List<Transform> referenceJoins;
    
    //List<>

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in ragdoll.GetComponentsInChildren<ConfigurableJoint>())
        {
            configurableJoints.Add(item);
        }

        foreach (var item in referene.GetComponentsInChildren<Transform>())
        {
            for (int i = 0; i < configurableJoints.Count; i++)
            {
                if (item.name == configurableJoints[i].name)
                {
                    referenceJoins.Add(item);
                    //referenceQuaternion
                    break;
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < configurableJoints.Count; i++)
        {
            //configurableJoints[i].targetRotation = Quaternion.Inverse(referenceJoins);
        }
    }
}
