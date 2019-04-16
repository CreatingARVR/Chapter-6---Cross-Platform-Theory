using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcrossXR.Interactions
{
    public class ControllerImplementation : MonoBehaviour
    {
        public virtual bool ActionButtonUp(int button)
        {
            return false;
        }

        public virtual bool ActionButtonDown(int button)
        {
            return false;
        }
    }
}