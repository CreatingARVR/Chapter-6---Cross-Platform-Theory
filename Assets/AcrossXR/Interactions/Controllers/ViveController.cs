using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcrossXR.Interactions
{
    public class ViveController : ControllerImplementation
    {
        public enum ButtonId
        {
            Trigger = 0,
            Menu,
            Touchpad
        }


#if XR_STEAM
        private SteamVR_TrackedObject trackedObj;
        private Hand hand;
#endif

        void Start()
        {
#if XR_STEAM
            trackedObj = GetComponent<SteamVR_TrackedObject>();
            hand = GetComponent<Hand>();
#endif
        }

#if XR_STEAM
        private SteamVR_Controller.Device controllerDevice
        {
            get
            {
                if (trackedObj != null)
                {
                    return SteamVR_Controller.Input((int)trackedObj.index);
                }
                else if (hand != null && hand.controller != null)
                {
                    return hand.controller;
                }
                return null;
            }
        }
#endif

        public ulong ButtonMap(int buttonId)
        {
#if XR_STEAM
            switch ((ButtonId)buttonId) {
            case ButtonId.Trigger:
            return SteamVR_Controller.ButtonMask.Trigger;

            case ButtonId.Menu:
            return SteamVR_Controller.ButtonMask.ApplicationMenu;

            case ButtonId.Grip:
            return SteamVR_Controller.ButtonMask.Grip;

            case ButtonId.Touchpad:
            return SteamVR_Controller.ButtonMask.Touchpad;
            }
#endif
            return 0;
        }


        public override bool ActionButtonUp(int button)
        {
#if XR_STEAM
            var device = controllerDevice;
            ulong mappedButton = ButtonMap(button);
            if (device != null && device.GetPressUp(mappedButton))
            {
                return true;
            }
#endif
            return false;
        }

        public override bool ActionButtonDown(int button)
        {
#if XR_STEAM
            var device = controllerDevice;
            ulong mappedButton = ButtonMap(button);
            if (device != null && device.GetPressDown(mappedButton))
            {
                return true;
            }
#endif
            return false;
        }
    }
}