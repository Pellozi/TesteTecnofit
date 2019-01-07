using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{

    class RootObject
    {
        public AccountStatement accountStatement { get; set; }
        public Parametros parametros { get; set; }
    }
}
