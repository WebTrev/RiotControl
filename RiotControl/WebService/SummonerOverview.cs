﻿using System.Collections.Generic;

using Blighttp;

namespace RiotControl
{
	partial class WebService
	{
		string GetSummonerOverview(string regionName, Summoner summoner)
		{
			string profileIcon = Markup.Image(GetImage(string.Format("Profile/profileIcon{0}.jpg", summoner.ProfileIcon)), string.Format("{0}'s profile icon", summoner.SummonerName), id: "profileIcon");

			var overviewFields1 = new Dictionary<string, string>()
			{
				{"Summoner name", Markup.Escape(summoner.SummonerName)},
				{"Internal name", Markup.Escape(summoner.InternalName)},
				{"Region", regionName},
				{"Summoner level", summoner.SummonerLevel.ToString()},
				{"Non-custom games played", summoner.GetGamesPlayed().ToString()},
				{"Account ID", summoner.AccountId.ToString()},
				{"Summoner ID", summoner.SummonerId.ToString()},
			};

			string link = string.Format("javascript:updateSummoner({0}, {1})", GetJavaScriptString(regionName), summoner.AccountId);

			var overviewFields2 = new Dictionary<string, string>()
			{
				{"First update", summoner.TimeCreated.ToString()},
				{"Last update", summoner.TimeUpdated.ToString()},
				{"Is updated automatically", summoner.UpdateAutomatically ? "Yes" : "No"},
				{"Manual update", Markup.Span(Markup.Link(link, "Update now"), id: "manualUpdate")},
			};

			string script = GetScript("Update.js");
			string container = Markup.Diverse(profileIcon + GetOverviewTable(overviewFields1) + GetOverviewTable(overviewFields2), id: "summonerHeader");
			string overview = script + container;

			return overview;
		}
	}
}