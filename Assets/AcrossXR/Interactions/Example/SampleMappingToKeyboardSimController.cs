using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcrossXR.Interactions
{
    public class MappingToKeyboardSimController : MonoBehaviour
    {
        public SampleControlScheme scheme;
        private void Awake()
        {
            scheme.AddOperationIdButton((int)SampleControlScheme.InteractionType.Grab, (int)KeyboardSimController.ButtonId.SpaceBar);
            scheme.AddOperationIdButton((int)SampleControlScheme.InteractionType.ToggleMenu, (int)KeyboardSimController.ButtonId.EqualsSign);
        }
    }
}