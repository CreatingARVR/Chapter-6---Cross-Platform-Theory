using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcrossXR.Interactions
{
    public class KeyboardSimController : ControllerImplementation
    {
        public enum ButtonId
        {
            SpaceBar = 0,
            EqualsSign
        }

        public KeyCode ButtonMap(int buttonId)
        {
            switch ((ButtonId)buttonId)
            {
                case ButtonId.SpaceBar:
                    return KeyCode.Space;

                case ButtonId.EqualsSign:
                    return KeyCode.Equals;
            }
            return KeyCode.Alpha0;
        }

        public override bool ActionButtonUp(int button)
        {
            return Input.GetKeyUp(ButtonMap(button));
        }

        public override bool ActionButtonDown(int button)
        {
            return Input.GetKeyDown(ButtonMap(button));
        }
    }
}