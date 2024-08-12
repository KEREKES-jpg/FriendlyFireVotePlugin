using CommandSystem;
using Exiled.API.Features;
using FFVote_Plugin.Handlers;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFVote_Plugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public sealed class VoteCommand : ICommand
    {
        public string Command { get; } = "vote";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "You can vote in lobby to turn off friendly fire";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Round.IsLobby)
            {
                response = "YOU CAN ONLY VOTE IN LOBBY";
                return true;
            }
            var player = Player.Get(((PlayerCommandSender)sender).ReferenceHub);
            if (ServerHandler.votingPlayers.Contains(player))
            {
                response = "YOU CAN ONLY VOTE ONCE";
                return true;
            }
            else
            {
                ServerHandler.votingPlayers.Add(player);
                response = "YOU VOTED TO TURN OFF FRIENDLY FIRE";
                return true;
            }
        }
    }
}
