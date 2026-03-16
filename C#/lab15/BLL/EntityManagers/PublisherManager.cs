using BLL.Entities;
using BLL.EntityLists;
using DAL;
using System;
using System.Data;
using System.Collections.Generic;

namespace BLL.EntityManagers
{
    public static class PublisherManager
    {
        private static readonly DBManager _manager = new();

        public static PublisherList SelectAllPublishers()
        {
            try
            {
                DataTable dataTable = _manager.ExecuteDataTable("SelectAllPublishers");
                return DataTableToPublisherList(dataTable);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to retrieve publishers from database.", ex);
            }
        }

        #region Private Helpers

        private static PublisherList DataTableToPublisherList(DataTable dataTable)
        {
            var publishers = new PublisherList();

            foreach (DataRow row in dataTable.Rows)
            {
                publishers.Add(DataRowToPublisher(row));
            }

            return publishers;
        }

        private static Publisher DataRowToPublisher(DataRow row)
        {
            return new Publisher
            {
                PubID = row["pub_id"] == DBNull.Value ? "NA" : row["pub_id"].ToString()!,
                PubName = row["pub_name"] == DBNull.Value ? "NA" : row["pub_name"].ToString()!,
                City = row["city"] == DBNull.Value ? string.Empty : row["city"].ToString()!,
                StateName = row["state"] == DBNull.Value ? string.Empty : row["state"].ToString()!,
                Country = row["country"] == DBNull.Value ? string.Empty : row["country"].ToString()!,
                State = EntityState.Unchanged
            };
        }

        #endregion
    }
}