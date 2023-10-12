using System;

namespace Models
{
	[Serializable]
	public class LoginRequest
	{
		

		public string userName;

		public string password;

		public override string ToString(){
			return UnityEngine.JsonUtility.ToJson (this, true);
		}
	}
}

