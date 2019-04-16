using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcrossXR.Interactions
{
    public class SampleMappingToViveController : MonoBehaviour
    {
        public SampleControlScheme scheme;
        private void Awake()
        {
            scheme.AddOperationIdButton((int)SampleControlScheme.InteractionType.Grab, (int)ViveController.ButtonId.Trigger);
            scheme.AddOperationIdButton((int)SampleControlScheme.InteractionType.ToggleMenu, (int)ViveController.ButtonId.Menu);
        }
    }
}