using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace CricAPI.Models
{
    public class CricsheetInfo
    {
        //[JsonProperty("meta")]
        //public Meta Meta { get; set; }

        [JsonProperty("info")]
        public Info Info { get; set; }  

        [JsonProperty("innings")]
        public Inning[] Innings { get; set; }
    }

    public class Meta
    {
        [JsonProperty("data_version")]
        public double DataVersion { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("revision")]
        public long Revision { get; set; }
    }

    public class Info
    {
        [JsonProperty("city",NullValueHandling = NullValueHandling.Ignore)]
        public string city { get; set; }

        [JsonProperty("competition",NullValueHandling = NullValueHandling.Ignore)]
        public string competition {get; set;}

        [JsonProperty("dates")]
        public IList<DateTime> dates { get; set; }
        [JsonProperty("gender")]
        public string gender { get; set; }
        [JsonProperty("match_type")]
        public string match_type { get; set; }

        [JsonProperty("neutral_venue")]
        public bool neutral_venue { get; set; }

        [JsonProperty("outcome")]
        public Outcome outcome { get; set; }
        [JsonProperty("overs")]
        public int overs { get; set; }
        [JsonProperty("player_of_match")]
        public IList<string> player_of_match { get; set; }
        [JsonProperty("teams")]
        public IList<string> teams { get; set; }
        [JsonProperty("toss")]
        public Toss toss { get; set; }
        [JsonProperty("umpires")]
        public IList<string> umpires { get; set; }
        [JsonProperty("venue")]
        public string venue { get; set; }
    }

    public class Outcome
    {
        [JsonProperty("bowl_out",NullValueHandling = NullValueHandling.Ignore)]
        public string bowl_out {get; set;}

        [JsonProperty("by",NullValueHandling = NullValueHandling.Ignore)]
        public By by { get; set; }

        [JsonProperty("eliminator",NullValueHandling = NullValueHandling.Ignore)]
        public string eliminator {get; set;}

        [JsonProperty("method",NullValueHandling = NullValueHandling.Ignore)]
        public string method {get; set;}

        [JsonProperty("result",NullValueHandling = NullValueHandling.Ignore)]
        public string result {get; set;}

        [JsonProperty("winner",NullValueHandling = NullValueHandling.Ignore)]
        public string winner { get; set; }
    }

    public class By
    {
        [JsonProperty("runs", NullValueHandling = NullValueHandling.Ignore)]
        public int? runs { get; set; }
        [JsonProperty("wickets", NullValueHandling = NullValueHandling.Ignore)]
        public int? Wickets {get; set;}
    }

    public class Toss
    {
        [JsonProperty("decision")]
        public string decision { get; set; }
        [JsonProperty("winner")]
        public string winner { get; set; }
    }

    public class Inning
    {
        [JsonProperty("1st innings", NullValueHandling = NullValueHandling.Ignore)]
        public Innings The1StInnings { get; set; }

        [JsonProperty("2nd innings", NullValueHandling = NullValueHandling.Ignore)]
        public Innings The2NdInnings { get; set; }

        [JsonProperty("3rd innings", NullValueHandling = NullValueHandling.Ignore)]
        public Innings The3RdInnings { get; set; }

        [JsonProperty("4th innings", NullValueHandling = NullValueHandling.Ignore)]
        public Innings The4ThInnings { get; set; }
    }

    public class Innings
    {
        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("deliveries")]
        public Dictionary<string, Delivery>[] Deliveries { get; set; }
    }

    public class Delivery
    {
        [JsonProperty("batsman")]
        public string Batsman { get; set; }

        [JsonProperty("bowler")]
        public String Bowler { get; set; }

        [JsonProperty("non_striker")]
        public string NonStriker { get; set; }

        [JsonProperty("runs", NullValueHandling = NullValueHandling.Ignore)]
        public Runs Runs { get; set; }

       [JsonProperty("extras", NullValueHandling = NullValueHandling.Ignore)]
        public Extras Extras { get; set; }

        [JsonProperty("wicket", NullValueHandling = NullValueHandling.Ignore)]
        public Wicket Wicket { get; set; }
    }

    public class Extras
    {
        [JsonProperty("noballs", NullValueHandling = NullValueHandling.Ignore)]
        public long? Noballs { get; set; }

        [JsonProperty("wides", NullValueHandling = NullValueHandling.Ignore)]
        public long? Wides { get; set; }

        [JsonProperty("legbyes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Legbyes { get; set; }

        [JsonProperty("byes", NullValueHandling = NullValueHandling.Ignore)]
        public long? Byes { get; set; }
    }

    public class Runs
    {
        [JsonProperty("batsman", NullValueHandling = NullValueHandling.Ignore)]
        public long? Batsman { get; set; }

        [JsonProperty("extras", NullValueHandling = NullValueHandling.Ignore)]
        public long? Extras { get; set; }

        [JsonProperty("total", NullValueHandling = NullValueHandling.Ignore)]
        public long? Total { get; set; }
    }

    public class Wicket
    {
        [JsonProperty("fielders", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Fielders { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("player_out")]
        public string PlayerOut { get; set; }
    }


}