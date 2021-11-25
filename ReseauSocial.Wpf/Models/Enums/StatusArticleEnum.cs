using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.Models.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum StatusArticleEnum
    {
        [Description("Tous les status")]
        Tout = 0,
        [Description("Normal")]
        Normal = 1,
        [Description("Article signalé")]
        Signal = 2,
        [Description("Article bloqué")]
        Block = 3
        
    }
}