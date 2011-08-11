﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleDotNet.Objects.WoW;
using Newtonsoft.Json;

namespace BattleDotNet
{
    public class WoWClient : Client
    {
        public WoWClient(ClientRegion? region = null, string publicKey = null, string privateKey = null)
            : base("wow", region, publicKey, privateKey)
        {
        }

        #region Private Types
        private class RealmStatusData
        {
            [JsonProperty("realms")]
            public IEnumerable<RealmStatus> Realms { get; private set; }
        }

        private class RacesData
        {
            [JsonProperty("races")]
            public IEnumerable<Race> Races { get; private set; }
        }
        #endregion

        public IEnumerable<RealmStatus> GetRealmStatuses(params string[] realms)
        {
            return this.Get<RealmStatusData>("realm/status", new Parameters { { "realms", string.Join(",", realms) } }).Realms;
        }

        public IEnumerable<Race> GetRaces()
        {
            return this.Get<RacesData>("data/character/races").Races;
        }

        public Character GetCharacter(string name, string realm, CharacterFields fields = CharacterFields.None)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(realm))
                throw new ArgumentNullException("realm");

            return this.Get<Character>(string.Format("character/{0}/{1}", realm, name), fields: fields);
        }

        public Guild GetGuild(string name, string realm, GuildFields fields = GuildFields.None)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(realm))
                throw new ArgumentNullException("realm");

            return this.Get<Guild>(string.Format("guild/{0}/{1}", realm, name), fields: fields);
        }
    }

    [Flags]
    public enum CharacterFields
    {
        None = 0x0,

        Guild = 0x1,
        Stats = 0x2,
        Talents = 0x4,
        Items = 0x8,
        Reputation = 0x10,
        Titles = 0x20,
        Professions = 0x40,
        Appearance = 0x80,
        Companions = 0x100,
        Mounts = 0x200,
        Pets = 0x400,
        Achievements = 0x800,
        Progression = 0x1000,

        All = 0x7FFFFFFF,
    }

    [Flags]
    public enum GuildFields
    {
        None = 0x0,
        Members = 0x1,
        Achievements = 0x2,

        All = 0x7FFFFFFF
    }
}