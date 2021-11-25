using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public enum StatusArticleEnum
    {
        [Description("touts les status")]
        Tout = 0,
        [Description("Article sans status")]
        Normal = 1,
        [Description("Article signalé")]
        Signal = 2,
        [Description("Article bloqué")]
        Block = 3
        
    }
}