// Track Object Grab Attach|GrabAttachMechanics|50080
namespace VRTK.GrabAttachMechanics
{
    using UnityEngine;

    /// <summary>
    /// The Track Object Grab Attach script doesn't attach the object to the controller via a joint, instead it ensures the object tracks the direction of the controller.
    /// </summary>
    /// <remarks>
    /// This works well for items that are on hinged joints or objects that require to interact naturally with other scene rigidbodies.
    /// </remarks>
    /// <example>
    /// `VRTK/Examples/021_Controller_GrabbingObjectsWithJoints` demonstrates this grab attach mechanic on the Chest handle and Fire Extinguisher body.
    /// </example>
    public class VRTK_TrackObjectGrabAttach : VRTK_BaseGrabAttach
    {
        [Header("Track Options", order = 2)]

        [Tooltip("The maximum distance the grabbing controller is away from the object before it is automatically dropped.")]
        public float detachDistance = 1f;

        /// <summary>
        /// The StopGrab method ends the grab of the current object and cleans up the state.
        /// </summary>
        /// <param name="applyGrabbingObjectVelocity">If true will apply the current velocity of the grabbing object to the grabbed object on release.</param>
        public override void StopGrab(bool applyGrabbingObjectVelocity)
        {
            ReleaseObject(applyGrabbingObjectVelocity);
            base.StopGrab(applyGrabbingObjectVelocity);
        }

        /// <summary>
        /// The CreateTrackPoint method sets up the point of grab to track on the grabbed object.
        /// </summary>
        /// <param name="controllerPoint">The point on the controller where the grab was initiated.</param>
        /// <param name="currentGrabbedObject">The object that is currently being grabbed.</param>
        /// <param name="currentGrabbingObject">The object that is currently doing the grabbing.</param>
        /// <param name="customTrackPoint">A reference to whether the created track point is an auto generated custom object.</param>
        /// <returns>The transform of the created track point.</returns>
        public override Transform CreateTrackPoint(Transform controllerPoint, GameObject currentGrabbedObject, GameObject currentGrabbingObject, ref bool customTrackPoint)
        {
            Transform trackPoint = null;
            if (precisionGrab)
            {
                trackPoint = new GameObject(string.Format("[{0}]TrackObject_PrecisionSnap_AttachPoint", currentGrabbedObject.name)).transform;
                trackPoint.parent = currentGrabbingObject.transform;
                SetTrackPointOrientation(ref trackPoint, currentGrabbedObject.transform, controllerPoint);
                customTrackPoint = true;
            }
            else
            {
                trackPoint = base.CreateTrackPoint(controllerPoint, currentGrabbedObject, currentGrabbingObject, ref customTrackPoint);
            }
            return trackPoint;
        }

        /// <summary>
        /// The ProcessUpdate method is run in every Update method on the interactable object. It is responsible for checking if the tracked object has exceeded it's detach distance.
        /// </summary>
        public override void ProcessUpdate()
        {
            if (trackPoint && grabbedObjectScript.IsDroppable())
            {
                float distance = Vector3.Distance(trackPoint.position, initialAttachPoint.position);
                if (distance > detachDistance)
                {
                    ForceReleaseGrab();
                }
            }
        }

        /// <summary>
        /// The ProcessFixedUpdate method is run in every FixedUpdate method on the interactable object. It applies velocity to the object to ensure it is tracking the grabbing object.
        /// </summary>
        public override void ProcessFixedUpdate()
        {
            float maxDistanceDelta = 10f;
            float angle;
            Vector3 axis;
            Vector3 positionDelta;
            Quaternion rotationDelta;

            if (grabbedSnapHandle != null)
            {
                rotationDelta = trackPoint.rotation * Quaternion.Inverse(grabbedSnapHandle.rotation);
                positionDelta = trackPoint.position - grabbedSnapHandle.position;
            }
            else
            {
                rotationDelta = trackPoint.rotation * Quaternion.Inverse(grabbedObject.transform.rotation);
                positionDelta = trackPoint.position - grabbedObject.transform.position;
            }

            rotationDelta.ToAngleAxis(out angle, out axis);

            angle = ((angle > 180) ? angle -= 360 : angle);

            if (angle != 0)
            {
                Vector3 angularTarget = angle * axis;
                grabbedObjectRigidBody.angularVelocity = Vector3.MoveTowards(grabbedObjectRigidBody.angularVelocity, angularTarget, maxDistanceDelta);
            }

            Vector3 velocityTarget = positionDelta / Time.fixedDeltaTime;
            grabbedObjectRigidBody.velocity = Vector3.MoveTowards(grabbedObjectRigidBody.velocity, velocityTarget, maxDistanceDelta);
        }

        protected override void Initialise()
        {
            tracked = true;
            climbable = false;
            kinematic = false;
            FlipSnapHandles();
        }

        protected virtual void SetTrackPointOrientation(ref Transform trackPoint, Transform currentGrabbedObject, Transform controllerPoint)
        {
            trackPoint.position = currentGrabbedObject.position;
            trackPoint.rotation = currentGrabbedObject.rotation;
        }
    }
}