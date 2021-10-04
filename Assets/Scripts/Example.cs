using UnityEngine;

namespace Assets.Scripts
{
	public class Example : MonoBehaviour
	{
		public Animator animator;

		private bool ikActiveR = false;
		private bool ikActiveL = false;
		private bool ikActiveLook = false;
		private bool isRagdoll = false;
		public Transform rightHandObj = null;
		public Transform leftHandObj = null;
		public Transform LookObj = null;

        private void Start()
        {
			Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (var item in rbs)
            {
				item.isKinematic = true;
            }
		}

        private void OnValidate()
		{
			animator = GetComponent<Animator>();
		}

		//a callback for calculating IK
		private void OnAnimatorIK()
		{

			if (!animator) return;

            if (ikActiveLook)
            {
                // Set the look target position, if one has been assigned
                if (LookObj != null)
                {
                    if (Vector3.Distance(transform.position, LookObj.position) <= 3)
                    {
                        animator.SetLookAtWeight(1);
                        animator.SetLookAtPosition(LookObj.position);
                    }
                }
            }
            else animator.SetLookAtWeight(0);

            if (ikActiveR)
			{
				if (rightHandObj)
				{
					animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
					animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
					animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
				}
			}
			else animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);

            if (ikActiveL)
            {
                if (leftHandObj)
                {
                    animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                    animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
                    animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);
                }

            }
            else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            }

            if (isRagdoll)
			{
				RagdollActivation();
			}
		}

		private void OnGUI()
		{
			GUI.Box(new Rect(10, 10, 200, 200), " Menu");
			if (GUI.Button(new Rect(20, 40, 180, 30), "ikActiveR"))
			{
				ikActiveR = !ikActiveR;
			}
			if (GUI.Button(new Rect(20, 75, 180, 30), "ikActiveL"))
			{
				ikActiveL = !ikActiveL;
			}
			if (GUI.Button(new Rect(20, 110, 180, 30), "ikActiveLook"))
				ikActiveLook = !ikActiveLook;

			if (GUI.Button(new Rect(20, 145, 180, 30), "Ragdoll"))
				isRagdoll = !isRagdoll;

		}

		private void RagdollActivation()
		{
           		Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
				foreach (var item in rbs)
				{
					item.isKinematic = false;
				}

			gameObject.GetComponent<Animator>().enabled = false;
			gameObject.GetComponent<CapsuleCollider>().enabled = false;
			gameObject.GetComponent<CapsuleCollider>().enabled = false;
		}

	}
}