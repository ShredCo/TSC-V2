using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_UserInterfaceOverworld : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_UserInterfaceOverworld() : base(typeof(UserInterfaceOverworld)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UserInterfaceOverworld)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UserInterfaceOverworld)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_UserInterfaceOverworldArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_UserInterfaceOverworldArray() : base(typeof(UserInterfaceOverworld[]), ES3UserType_UserInterfaceOverworld.Instance)
		{
			Instance = this;
		}
	}
}