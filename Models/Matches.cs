using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CricAPI.Models
{
    public partial class Matches
    {
  
        public long Cricsheetid { get; set; }
        internal string _Jsondata {get; set;}
        [NotMapped]
        public CricsheetInfo matchData { 
                get { return (this._Jsondata == null) ? null : JsonConvert.DeserializeObject<CricsheetInfo>(this._Jsondata); }
                set { _Jsondata = JsonConvert.SerializeObject(value); }
            
            }
       
    }
}
