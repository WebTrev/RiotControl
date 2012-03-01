﻿using System.Collections.Generic;

using LibOfLegends;

namespace RiotControl
{
	public class Configuration
	{
		public DatabaseConfiguration Database;
		public AuthenticationProfile Authentication;
		public ProxyProfile Proxy;
		public List<EngineRegionProfile> RegionProfiles;

		public Configuration()
		{
			Database = new DatabaseConfiguration();
			RegionProfiles = new List<EngineRegionProfile>();
		}
	}
}
