using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("pitch")]
	public class ES3UserType_AudioSource : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_AudioSource() : base(typeof(UnityEngine.AudioSource)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.AudioSource)obj;
			
			writer.WriteProperty("pitch", instance.pitch, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.AudioSource)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "pitch":
						instance.pitch = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_AudioSourceArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AudioSourceArray() : base(typeof(UnityEngine.AudioSource[]), ES3UserType_AudioSource.Instance)
		{
			Instance = this;
		}
	}
}