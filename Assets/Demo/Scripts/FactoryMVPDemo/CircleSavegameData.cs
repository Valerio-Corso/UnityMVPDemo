using System;
using System.Collections.Generic;

namespace Demo.Scripts.FactoryMVPDemo
{
	public class CircleSavegameData
	{
		public List<CircleScreenData> CircleData { get; set; }
	}
	
	[Serializable]
	public class CircleScreenData
	{
		public int Count;
	}
}