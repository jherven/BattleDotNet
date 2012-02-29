using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace BattleDotNet.Objects.WoW
{
    public class Auctions
    {
        internal Auctions(IEnumerable<Auction> alliance, IEnumerable<Auction> horde, IEnumerable<Auction> neutral)
        {
            Alliance = alliance;
            Horde = horde;
            Neutral = neutral;
        }

        public IEnumerable<Auction> Alliance { get; private set; }

        public IEnumerable<Auction> Horde { get; private set; }

        public IEnumerable<Auction> Neutral { get; private set; }
    }

    public class Auction
    {
        [JsonProperty("auc")]
        public long ID { get; private set; }

        [JsonProperty("item")]
        public int ItemID { get; private set; }

        [JsonProperty("owner")]
        public string OwnerName { get; private set; }

        [JsonProperty("bid")]
        public long Bid { get; private set; }

        [JsonProperty("buyout")]
        public long Buyout { get; private set; }

        [JsonProperty("quantity")]
        public int Quantity { get; private set; }

        [JsonProperty("timeLeft")]
        public AuctionTimeLeft TimeLeft { get; private set; }
    }

    public enum AuctionTimeLeft
    {
        Short,
        Medium,
        Long,
        Very_Long
    }
}
