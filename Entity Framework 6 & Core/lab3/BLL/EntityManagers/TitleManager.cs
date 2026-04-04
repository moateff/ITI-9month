using BLL.Entities;
using BLL.EntityLists;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL.EntityManagers
{
    public static class TitleManager
    {
        private static readonly DBManager _manager = new();

        public static TitleList SelectAllTitles()
        {
            try
            {
                DataTable dataTable = _manager.ExecuteDataTable("SelectAllTitles");
                return DataTableToTitleList(dataTable);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve titles from database.", ex);
            }
        }

        public static bool InsertTitle(Title title)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));

            var parameters = BuildParameters(title);
            return _manager.ExecuteNonQuery("InsertTitle", parameters) > 0;
        }

        public static bool UpdateTitle(Title title)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));

            var parameters = BuildParameters(title);
            return _manager.ExecuteNonQuery("UpdateTitle", parameters) > 0;
        }

        public static bool DeleteTitle(Title title)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));

            var parameters = new Dictionary<string, object>
            {
                ["@TitleID"] = title.TitleID
            };

            return _manager.ExecuteNonQuery("DeleteTitle", parameters) > 0;
        }

        #region Private Helpers

        internal static TitleList DataTableToTitleList(DataTable dataTable)
        {
            var titles = new TitleList();
            foreach (DataRow row in dataTable.Rows)
            {
                titles.Add(DataRowToTitle(row));
            }
            return titles;
        }

        internal static Title DataRowToTitle(DataRow row)
        {
            return new Title
            {
                TitleID = row.Field<string>("title_id") ?? "NA",
                TitleName = row.Field<string>("title") ?? "NA",
                Type = row.Field<string>("type") ?? "NA",
                PubID = row.Field<string>("pub_id"),
                Price = row.Field<decimal?>("price"),
                Advance = row.Field<decimal?>("advance"),
                Royalty = row.Field<int?>("royalty"),
                YTDSales = row.Field<int?>("ytd_sales"),
                Notes = row.Field<string>("notes"),
                PubDate = row.Field<DateTime>("pubdate"),
                State = EntityState.Unchanged
            };
        }

        private static Dictionary<string, object> BuildParameters(Title title)
        {
            return new Dictionary<string, object>
            {
                ["@TitleID"] = title.TitleID,
                ["@Title"] = title.TitleName,
                ["@Type"] = title.Type,
                ["@PubID"] = title.PubID ?? (object)DBNull.Value,
                ["@Price"] = title.Price ?? (object)DBNull.Value,
                ["@Advance"] = title.Advance ?? (object)DBNull.Value,
                ["@Royalty"] = title.Royalty ?? (object)DBNull.Value,
                ["@YTDSales"] = title.YTDSales ?? (object)DBNull.Value,
                ["@Notes"] = title.Notes ?? (object)DBNull.Value,
                ["@PubDate"] = title.PubDate
            };
        }

        #endregion
    }
}