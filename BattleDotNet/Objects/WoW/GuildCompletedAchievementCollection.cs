﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BattleDotNet.JsonConverters;


namespace BattleDotNet.Objects.WoW
{
    using Extensions;

    internal class GuildCompletedAchievementCollection : IEnumerable<GuildCompletedAchievement>
    {
        private List<int> Ids = null;
        private List<DateTime> Timestamps = null;

        internal GuildCompletedAchievementCollection(IEnumerable<int> ids, IEnumerable<long> timestamps)
        {
            Ids = new List<int>(ids);
            Timestamps = timestamps.Select(t => t.ConvertJavaScriptTimestamp()).ToList();
        }



        #region IEnumerable<GuildAchievement> Members

        public IEnumerator<GuildCompletedAchievement> GetEnumerator()
        {
            for (int ii = 0, l = Ids.Count; ii < l; ii++)
            {
                yield return new GuildCompletedAchievement
                {
                    Id = Ids[ii],
                    DateCompleted = Timestamps[ii]
                };
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            for (int ii = 0, l = Ids.Count; ii < l; ii++)
            {
                yield return new GuildCompletedAchievement
                {
                    Id = Ids[ii],
                    DateCompleted = Timestamps[ii]
                };
            }
        }

        #endregion
    }
}