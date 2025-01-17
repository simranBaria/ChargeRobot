using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class CrushAT : ActionTask {
		public Compactor compactor;
		public float crushDuration, energyUseRate;

		private float timeCompacting = 0;
		public BBParameter<float> energy;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			timeCompacting = 0;
			compactor.Crush();
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			timeCompacting += Time.deltaTime;

			// Change the value of the energy
			float currentEnergy = energy.value;
			currentEnergy -= energyUseRate * Time.deltaTime;
			energy.value = currentEnergy;

			if (timeCompacting > crushDuration) EndAction(true);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            compactor.Stop();
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}