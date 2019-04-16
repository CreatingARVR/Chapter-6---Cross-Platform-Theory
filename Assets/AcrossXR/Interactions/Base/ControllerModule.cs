using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AcrossXR.Interactions
{
    #region Action Definition
    public class ControllerModule : MonoBehaviour
    {
        public Component controllerImplementation;

        [SerializeField]
        private ControllerImplementation _impl;
        public ControllerImplementation impl
        {
            get
            {
                if (_impl == null && controllerImplementation != null)
                {
                    _impl = (ControllerImplementation)controllerImplementation;
                }
                return _impl;
            }
        }

        private void Update()
        {
            ProcessInteractions();
        }

        protected virtual void ProcessInteractions()
        {
        }

        public bool DriverOperationStarted(int operationId)
        {
            if (OperationDidStart(operationId))
            {
                return true;
            }
            return false;
        }

        public bool DriverOperationEnded(int operationId)
        {
            if (OperationDidEnd(operationId))
            {
                return true;
            }
            return false;
        }

        public virtual bool OperationDidStart(int operationId)
        {
            if (operationIdToButton.ContainsKey(operationId))
            {
                foreach (int button in operationIdToButton[operationId])
                {
                    if (impl.ActionButtonDown(button))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public virtual bool OperationDidEnd(int operationId)
        {
            if (operationIdToButton.ContainsKey(operationId))
            {
                foreach (int button in operationIdToButton[operationId])
                {
                    if (impl.ActionButtonUp(button))
                    {
                        //Debug.Log("Operation ended: " + operationId);
                        return true;
                    }
                }
            }
            return false;
        }

        public Dictionary<int, List<int>> operationIdToButton = new Dictionary<int, List<int>>();
        public void AddOperationIdButton(int operationId, int buttonId, bool clearOthers = false)
        {
            if (!operationIdToButton.ContainsKey(operationId))
            {
                operationIdToButton[operationId] = new List<int>();

            }
            else if (clearOthers)
            {
                // This is for straight remapping instead of appending
                operationIdToButton[operationId].Clear();
            }

            if (!operationIdToButton[operationId].Contains(buttonId))
            {
                operationIdToButton[operationId].Add(buttonId);
            }
        }
    }
    #endregion
}