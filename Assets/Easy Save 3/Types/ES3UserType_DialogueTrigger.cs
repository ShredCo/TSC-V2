using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("NpcType")]
	public class ES3UserType_DialogueTrigger : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_DialogueTrigger() : base(typeof(DialogueTrigger)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (DialogueTrigger)obj;
			
			writer.WriteProperty("NpcType", instance.NpcType, ES3Type_enum.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (DialogueTrigger)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "NpcType":
						instance.NpcType = reader.Read<NpcType>(ES3Type_enum.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_DialogueTriggerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DialogueTriggerArray() : base(typeof(DialogueTrigger[]), ES3UserType_DialogueTrigger.Instance)
		{
			Instance = this;
		}
	}
}