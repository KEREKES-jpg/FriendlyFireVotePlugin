using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFVote_Plugin
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Broadcast sent when voting starts")]
        public string votingMessage { get; set; } = "Prebieha hlasovanie o vypnutie FF, napis .vote do konzole aby si hlasoval o vypnutie FF na toto kolo";
        [Description("Broadcast send when friend fire is turned off. [voters = amount of votes, pCount = amount of votes needed]")]
        public string ffOffMessage { get; set; } = "<color=#ff0000>{voters}/{pCount}</color> Enough votes, FF is off this round!";
        [Description("Broadcast send when friend fire stays on. [voters = amount of votes, pCount = amount of votes needed]")]
        public string ffOnMessage { get; set; } = "<color=#ff0000>{voters}/{pCount}</color> Not enough votes, FF is on this round!";

    }
}
