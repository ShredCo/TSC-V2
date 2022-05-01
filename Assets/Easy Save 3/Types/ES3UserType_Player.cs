using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("instance", "inventory", "pickedUpMoney", "textPickedUpMoney")]
	public class ES3UserType_Player : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Player() : base(typeof(Player)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Player)obj;
			
			writer.WritePropertyByRef("instance", Player.Instance);
			writer.WritePropertyByRef("inventory", instance.Inventory);
			writer.WritePropertyByRef("pickedUpMoney", instance.pickedUpMoney);
			writer.WritePropertyByRef("textPickedUpMoney", instance.textPickedUpMoney);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Player)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "instance":
						Player.Instance = reader.Read<Player>();
						break;
					case "inventory":
						instance.Inventory = reader.Read<InventoryObject>();
						break;
					case "pickedUpMoney":
						instance.pickedUpMoney = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "textPickedUpMoney":
						instance.textPickedUpMoney = reader.Read<UnityEngine.UI.Text>(ES3Type_Text.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerArray() : base(typeof(Player[]), ES3UserType_Player.Instance)
		{
			Instance = this;
		}
	}
}