using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using Exiled.API.Features;
using System.Runtime.InteropServices;
using Exiled.API.Enums;

namespace FFVote_Plugin
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Plugin Singleton = new Plugin();
        public static Plugin Instance => Singleton;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Handlers.PlayerHandler player;
        private Handlers.ServerHandler server;

        private Plugin()
        {
        }

        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            player = new Handlers.PlayerHandler();
            server = new Handlers.ServerHandler();

            Server.RoundStarted += server.OnRoundStart;
            Player.Verified += player.OnPlayerJoined;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= server.OnRoundStart;
            Player.Verified -= player.OnPlayerJoined;

            player = null;
            server = null;
        }
    }
}
