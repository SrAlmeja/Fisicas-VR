using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyBones : MonoBehaviour
{
    [SerializeField] GameObject ragdoll;
    [SerializeField] GameObject animator;

    [SerializeField] private List<Transform> targetLimbs;
    [SerializeField] private List<ConfigurableJoint> m_ConfigurableJoints;


    [SerializeField] List<Quaternion> targetInitialRotation;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in ragdoll.GetComponentsInChildren<ConfigurableJoint>())
        {
            m_ConfigurableJoints.Add(item);
        }

        foreach (var item in animator.GetComponentsInChildren<Transform>())
        {
            foreach (var cj in m_ConfigurableJoints)
            {
                if(item.name == cj.name)
                {
                    targetLimbs.Add( item);
                    targetInitialRotation.Add(item.transform.localRotation);
                }
            }

        }
    }


    private void FixedUpdate()
    {
        for (int i = 0; i < m_ConfigurableJoints.Count; i++)
        {
          m_ConfigurableJoints[i].targetRotation = copyRotation(i);
        }
        
    }

    private Quaternion copyRotation(int i)
    {
        return Quaternion.Inverse(targetLimbs[i].localRotation) * targetInitialRotation[i];
    }
}