using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcrossXR.Interactions
{
    public class SampleControlScheme : ControllerModule
    {
        public enum ProcessState
        {
            Hovered,
            Selected
        };

        public GameObject hoveredObject;
        public GameObject connectedObject;

        public enum InteractionType
        {
            Grab = 0,
            Shoot,
            ToggleMenu
        }

        protected override void ProcessInteractions()
        {
            // If we have something selected, process it
            if (connectedObject != null)
            {
                if (DriverOperationStarted((int)InteractionType.Shoot))
                {
                    ActionShoot();
                }

                if (DriverOperationEnded((int)InteractionType.Grab))
                {
                    ActionReleaseObject(connectedObject);
                }
            }

            // Otherwise, process top hovered item
            if (hoveredObject != null)
            {
                if (DriverOperationStarted((int)InteractionType.Grab))
                {
                    ActionConnectObject(hoveredObject);
                }
            }

            if (DriverOperationStarted((int)InteractionType.ToggleMenu))
            {
                ActionToggleMenu();
            }
        }

        public GameObject menu;
        void ActionToggleMenu()
        {
            menu.SetActive(!menu.activeSelf);
        }

        void ActionConnectObject(GameObject objectToConnect)
        {
            connectedObject = objectToConnect;
        }

        void ActionReleaseObject(GameObject objectToRelease)
        {
            if (connectedObject == objectToRelease)
            {
                connectedObject = null;
            }
        }

        void ActionShoot()
        {
            Debug.Log("Fire!"); // Make Pew-Pew noise
        }
    }
}