using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.Models.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum StatusType
    {
        [Description("Tout les comptes")]
        All = 0,
        [Description("Comptes activés")]
        Actived = 1,
        [Description("Comptes déactivés")]
        Deactived = 2,
        [Description("Comptes bloqués")]
        Blocked = 3,
        [Description("Comptes supprimés")]
        Deleted = 4,
        [Description("Comptes en cours de suppression")]
        AskDeleted = 5,
        [Description("Comptes en cours de réinscritpion")]
        AskReactived = 6

    }
}
