using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RechargeAT : ActionTask {
		public float rechargeRate, maxEnergy;
		public BBParameter<float> energy;
		public BBParameter<GameObject> powerStationObject;

		private Blackboard powerStationBlackboard;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			powerStationBlackboard = powerStationObject.value.GetComponent<Blackboard>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			Debug.Log("We are charging at: " + powerStationBlackboard.GetVariableValue<string>("powerStationName"));
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			float currentEnergy = energy.value;
            currentEnergy += rechargeRate * Time.deltaTime;

			if (currentEnergy >= maxEnergy) {
				currentEnergy = maxEnergy;
				EndAction(true);
			}

            energy.value = currentEnergy;
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}