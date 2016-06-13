using combit.ListLabel20.DataProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace combit.RedmineReports
{
    abstract class RedmineDataAccessBase : IDisposable
    {
        protected IDbConnection _connection;

        protected RedmineDataAccessBase()
        {
        }

        public DataProviderCollection GetRedmineData(string projectId, string sqlCommand, int startDate, string trackerIDs)
        {
            DataProviderCollection collection = new DataProviderCollection();
            DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
            provider.MinimalSelect = false;
            IDbCommand cmd = _connection.CreateCommand();

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, issues.id AS IssueID, issues.subject AS IssueName, issue_statuses.name AS IssueStatus, u1.login AS LoginName, u1.status AS LoginNameStatus , u1.firstname AS FirstName, u1.lastname AS LastName, versions.name AS Version, projects.name AS ProjectName, enumerations.name AS Priority, issue_statuses.is_closed AS IsClosed, u2.login AS AssignedToUser, u2.status AS AssignedToUserStatus, issue_categories.name AS Category"
                            + " FROM (issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id)"
                            + " INNER JOIN users u1 ON issues.author_id = u1.id"
                            + " LEFT OUTER JOIN users u2 ON issues.assigned_to_id = u2.id"
                            + " INNER JOIN projects ON issues.project_id = projects.id"
                            + " LEFT OUTER JOIN versions ON issues.fixed_version_id = versions.id"
                            + " INNER JOIN enumerations ON issues.priority_id = enumerations.id"
                            + " LEFT OUTER JOIN issue_categories ON issues.category_id = issue_categories.id"
                            + " WHERE issues.project_id = '" + projectId + "'" + sqlCommand + " and issues.tracker_id IN(" + trackerIDs + ")";
            provider.AddCommand(cmd, "Issues", "`{0}`", "?{0}");

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, issues.id AS IssueID, issues.subject as IssueName, issue_statuses.name as IssueStatus, u1.login as LoginName, u1.status AS LoginNameStatus, u1.firstname as FirstName, u1.lastname as LastName, versions.name AS Version, projects.name AS ProjectName, enumerations.name AS Priority, issue_statuses.is_closed AS IsClosed, u2.login AS AssignedToUser, u2.status AS AssignedToUserStatus, issue_categories.name AS Category"
                            + " FROM (issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id)"
                            + " INNER JOIN users u1 ON issues.author_id = u1.id"
                            + " LEFT OUTER JOIN users u2 ON issues.assigned_to_id = u2.id"
                            + " INNER JOIN projects ON issues.project_id = projects.id"
                            + " LEFT OUTER JOIN versions ON issues.fixed_version_id = versions.id"
                            + " INNER JOIN enumerations ON issues.priority_id = enumerations.id"
                            + " LEFT OUTER JOIN issue_categories ON issues.category_id = issue_categories.id"
                            + " WHERE issues.project_id = '" + projectId + "'" + sqlCommand + " AND issue_statuses.is_closed = '0' AND issues.done_ratio != '100' and issues.tracker_id IN(" + trackerIDs + ")";

            provider.AddCommand(cmd, "OpenIssues", "`{0}`", "?{0}");

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, Count(status_id) AS Count, issue_statuses.name AS StatusName"
                            + " FROM issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id"
                            + " WHERE issues.project_id = " + projectId + "" + sqlCommand + " and issues.tracker_id IN(" + trackerIDs + ") GROUP BY status_id";
            provider.AddCommand(cmd, "IssuesByStatus", "`{0}`", "?{0}");

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, issues.id AS IssueID, issues.subject as IssueName, issue_statuses.name as IssueStatus, u1.login as LoginName, u1.status AS LoginNameStatus, u1.firstname as FirstName, u1.lastname as LastName, versions.name AS Version, projects.name AS ProjectName, enumerations.name AS Priority, issue_statuses.is_closed AS IsClosed, u2.login AS AssignedToUser, u2.status AS AssignedToUserStatus, issue_categories.name AS Category"
                            + " FROM (issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id)"
                            + " INNER JOIN users u1 ON issues.author_id = u1.id"
                            + " LEFT OUTER JOIN users u2 ON issues.assigned_to_id = u2.id"
                            + " INNER JOIN projects ON issues.project_id = projects.id"
                            + " LEFT OUTER JOIN versions ON issues.fixed_version_id = versions.id"
                            + " INNER JOIN enumerations ON issues.priority_id = enumerations.id"
                            + " LEFT OUTER JOIN issue_categories ON issues.category_id = issue_categories.id"
                            + " WHERE issues.project_id = '" + projectId + "'" + sqlCommand + " AND issue_statuses.is_closed = '0' AND issues.done_ratio = '100'"
                            + "and issues.tracker_id IN(" + trackerIDs + ")";

            provider.AddCommand(cmd, "FixedIssues", "`{0}`", "?{0}");

            provider.SupportSorting = true;
            collection.Add(provider);
            collection.Add(new AdoDataProvider(CreateIssueHistory(projectId, sqlCommand, startDate, trackerIDs)));
            collection.Add(new AdoDataProvider(CreateChangeSetTable(projectId, startDate)));
            collection.Add(new AdoDataProvider(GetOpenTicketTimeSpan(projectId, sqlCommand, trackerIDs)));
            return collection;
        }

        public DataProviderCollection GetRedmineData(string projectId, string sqlCommand, DateTime fromDate, DateTime toDate, string trackerIDs)
        {
            DataProviderCollection collection = new DataProviderCollection();
            DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
            provider.MinimalSelect = false;
            IDbCommand cmd = _connection.CreateCommand();

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, issues.id AS IssueID, issues.subject AS IssueName, issue_statuses.name AS IssueStatus, u1.login AS LoginName, u1.status AS LoginNameStatus, u1.firstname AS FirstName, u1.lastname AS LastName, versions.name AS Version, projects.name AS ProjectName, enumerations.name AS Priority, issue_statuses.is_closed AS IsClosed, u2.login AS AssignedToUser, u2.status AS AssignedToUserStatus, issue_categories.name AS Category"
                            + " FROM (issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id)"
                            + " INNER JOIN users u1 ON issues.author_id = u1.id"
                            + " LEFT OUTER JOIN users u2 ON issues.assigned_to_id = u2.id"
                            + " INNER JOIN projects ON issues.project_id = projects.id"
                            + " LEFT OUTER JOIN versions ON issues.fixed_version_id = versions.id"
                            + " INNER JOIN enumerations ON issues.priority_id = enumerations.id"
                            + " LEFT OUTER JOIN issue_categories ON issues.category_id = issue_categories.id"
                            + " WHERE issues.project_id = '" + projectId + "'" + sqlCommand + " and issues.tracker_id IN(" + trackerIDs + ")";
            provider.AddCommand(cmd, "Issues", "`{0}`", "?{0}");

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, issues.id AS IssueID, issues.subject as IssueName, issue_statuses.name as IssueStatus, u1.login as LoginName, u1.status AS LoginNameStatus, u1.firstname as FirstName, u1.lastname as LastName, versions.name AS Version, projects.name AS ProjectName, enumerations.name AS Priority, issue_statuses.is_closed AS IsClosed, u2.login AS AssignedToUser, u2.status AS AssignedToUserStatus, issue_categories.name AS Category"
                            + " FROM (issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id)"
                            + " INNER JOIN users u1 ON issues.author_id = u1.id"
                            + " LEFT OUTER JOIN users u2 ON issues.assigned_to_id = u2.id"
                            + " INNER JOIN projects ON issues.project_id = projects.id"
                            + " LEFT OUTER JOIN versions ON issues.fixed_version_id = versions.id"
                            + " INNER JOIN enumerations ON issues.priority_id = enumerations.id"
                            + " LEFT OUTER JOIN issue_categories ON issues.category_id = issue_categories.id"
                            + " WHERE issues.project_id = '" + projectId + "'" + sqlCommand + " AND issue_statuses.is_closed = '0' AND issues.done_ratio != '100' and issues.tracker_id IN(" + trackerIDs + ")";

            provider.AddCommand(cmd, "OpenIssues", "`{0}`", "?{0}");

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, Count(status_id) AS Count, issue_statuses.name AS StatusName"
                            + " FROM issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id"
                            + " WHERE issues.project_id = " + projectId + "" + sqlCommand + " and issues.tracker_id IN(" + trackerIDs + ") GROUP BY status_id";
            provider.AddCommand(cmd, "IssuesByStatus", "`{0}`", "?{0}");

            cmd.CommandText = "SELECT issues.tracker_id AS TrackerID, issues.id AS IssueID, issues.subject as IssueName, issue_statuses.name as IssueStatus, u1.login as LoginName, u1.status AS LoginNameStatus, u1.firstname as FirstName, u1.lastname as LastName, versions.name AS Version, projects.name AS ProjectName, enumerations.name AS Priority, issue_statuses.is_closed AS IsClosed, u2.login AS AssignedToUser, u2.status AS AssignedToUserStatus, issue_categories.name AS Category"
                            + " FROM (issues INNER JOIN issue_statuses ON issues.status_id = issue_statuses.id)"
                            + " INNER JOIN users u1 ON issues.author_id = u1.id"
                            + " LEFT OUTER JOIN users u2 ON issues.assigned_to_id = u2.id"
                            + " INNER JOIN projects ON issues.project_id = projects.id"
                            + " LEFT OUTER JOIN versions ON issues.fixed_version_id = versions.id"
                            + " INNER JOIN enumerations ON issues.priority_id = enumerations.id"
                            + " LEFT OUTER JOIN issue_categories ON issues.category_id = issue_categories.id"
                            + " WHERE issues.project_id = '" + projectId + "'" + sqlCommand + " AND issue_statuses.is_closed = '0' AND issues.done_ratio = '100'" 
                            + " and issues.tracker_id IN(" + trackerIDs + ")";

            provider.AddCommand(cmd, "FixedIssues", "`{0}`", "?{0}");

            provider.SupportSorting = true;
            collection.Add(provider);
            collection.Add(new AdoDataProvider(CreateIssueHistory(projectId, sqlCommand, fromDate, toDate, trackerIDs)));
            collection.Add(new AdoDataProvider(CreateChangeSetTable(projectId, fromDate, toDate)));
            collection.Add(new AdoDataProvider(GetOpenTicketTimeSpan(projectId, sqlCommand, trackerIDs)));
            return collection;
        }

        private DataTable GetOpenTicketTimeSpan(string projectId, string sqlCommand, string trackerIds)
        {
            DataTable dtClosedIssueStatuses;
            DataTable dtClosedIssues;
            int i = 0;
            StringBuilder closedIssuesSqlCommand = new StringBuilder();

            String sql = "SELECT issue_statuses.id AS StatusID FROM issue_statuses WHERE issue_statuses.is_closed = '1'";
            dtClosedIssueStatuses = GetDataTable(sql);

            foreach (DataRow dr in dtClosedIssueStatuses.Rows)
            {
                
                if (i == 0)
                    closedIssuesSqlCommand.Append(" AND (issues.status_id = " + dr["StatusID"].ToString());
                else
                    closedIssuesSqlCommand.Append(" OR issues.status_id = " + dr["StatusID"].ToString());
                i++;
            }
            closedIssuesSqlCommand.Append(")");

            // get all issues of the selected project and version    
            sql = "SELECT issues.tracker_id AS TrackerID, issues.id, issues.created_on, issues.updated_on FROM issues"
                      + " WHERE issues.project_id = " + String.Format(GetParameterFormat(), "PROJECTID") + " " + String.Format(GetParameterFormat(), "SQLCOMMAND") + closedIssuesSqlCommand.ToString() + "" + " and issues.tracker_id IN(" + trackerIds + ")";

            // create parameters
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter param = GetParameter();
            IDbDataParameter sqlCommandparam = GetParameter();
            parameters.Add(param);
            param.ParameterName = String.Format(GetParameterFormat(), "PROJECTID");
            param.Value = projectId;
            parameters.Add(sqlCommandparam);
            sqlCommandparam.ParameterName = String.Format(GetParameterFormat(), "SQLCOMMAND");
            sqlCommandparam.Value = sqlCommand;

            dtClosedIssues = GetDataTable(sql, parameters.ToArray<IDbDataParameter>(), false);

            Dictionary<int, int> daysVsFixCount = new Dictionary<int, int>();

            foreach (DataRow drIssue in dtClosedIssues.Rows)
            {
                DateTime openingDate = (DateTime)drIssue["created_on"];
                DateTime closingDate = (DateTime)drIssue["updated_on"];
                int days = (closingDate - openingDate).Days;
                if (daysVsFixCount.ContainsKey(days))
                {
                    daysVsFixCount[days]++;
                }
                else
                {
                    daysVsFixCount.Add(days, 1);
                }
            }

            DataTable dtClosingTime = new DataTable("ClosingTime");
            dtClosingTime.Columns.Add("Days", typeof(int));
            dtClosingTime.Columns.Add("Count", typeof(int));

            foreach (KeyValuePair<int, int> kvp in daysVsFixCount)
            {
                dtClosingTime.Rows.Add(kvp.Key, kvp.Value);
            }

            return dtClosingTime;
        }

        private DataTable CreateChangeSetTable(string projectId, int startDate)
        {
            DateTime date = DateTime.Now.AddDays(-startDate);
            string formatForDatabase = date.ToString("yyyy-MM-dd");
            string dateSQL = " AND changesets.commit_date >= '" + formatForDatabase + "'";
            return CreateChangeSetTable(projectId, dateSQL);
        }

        private DataTable CreateChangeSetTable(string projectId, DateTime fromDate, DateTime toDate)
        {
            string fromFormatForDatabase = fromDate.ToString("yyyy-MM--dd");
            string toFormatForDatabase = toDate.ToString("yyyy-MM--dd");
            string dateSQL = " AND changesets.commit_date >= '" + fromFormatForDatabase + "' AND changesets.commit_date <= '" + toFormatForDatabase + "'";
            return CreateChangeSetTable(projectId, dateSQL);
        }

        private DataTable CreateChangeSetTable(string projectId, string dateSQL)
        {

            string sql = "SELECT repositories.id FROM repositories"
                       + " INNER JOIN projects ON projects.parent_id = " + String.Format(GetParameterFormat(), "PROJECTID")
                       + " WHERE repositories.project_id = projects.id"
                       + " OR repositories.project_id = " + String.Format(GetParameterFormat(), "PROJECTID")  
                       + " ORDER BY id";
            
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter param = GetParameter();
            parameters.Add(param);
            param.ParameterName = String.Format(GetParameterFormat(), "PROJECTID");
            param.Value = projectId;

            DataTable dtProjects = GetDataTable(sql, parameters.ToArray<IDbDataParameter>(), false);
            DataTable dtChangeSets = new DataTable();
            dtChangeSets.Columns.Add("Committed_on", typeof(DateTime));
            dtChangeSets.Columns.Add("Committer");
            dtChangeSets.Columns.Add("Changes", typeof(int));
            dtChangeSets.Columns.Add("Committer_status");

            // loop trough each project
            foreach (DataRow project in dtProjects.Rows)
            {
                sql = "SELECT changesets.id, changesets.committed_on, changesets.repository_id , changesets.committer, users.status AS Committer_status FROM changesets"
                +" INNER JOIN  users ON changesets.user_id = users.id WHERE changesets.repository_id = " + project[0].ToString() + dateSQL;
                DataTable dtChangeSetsThisProject = GetDataTable(sql);
                // loop trough each changeSet in project
                foreach (DataRow changeSet in dtChangeSetsThisProject.Rows)
                {
                    sql = "SELECT COUNT(1) FROM changes WHERE changes.changeset_id = " + changeSet["id"].ToString() + "";
                    DataTable dtCountChanges = GetDataTable(sql);
                    DataRow rowForChangeSet = dtChangeSets.NewRow();

                    rowForChangeSet["committed_on"] = changeSet["committed_on"];
                    rowForChangeSet["committer"] = changeSet["committer"].ToString();
                    rowForChangeSet["changes"] = dtCountChanges.Rows[0][0];
                    rowForChangeSet["Committer_status"] = changeSet["Committer_status"].ToString();
                    dtChangeSets.Rows.Add(rowForChangeSet);
                }
            }
            dtChangeSets.TableName = "ChangeSets";
            return dtChangeSets;
        }

        private DataTable CreateIssueHistory(string projectId, string sqlCommand, DateTime fromDate, DateTime toDate, string trackerIds)
        {
            // object to hold the history table per id
            Dictionary<int, DataTable> historyTable = new Dictionary<int, DataTable>();

            // create parameters
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter param = GetParameter();
            param.ParameterName = String.Format(GetParameterFormat(), "PROJECTID");
            param.Value = projectId;
            parameters.Add(param);

            // get all matching issue ids for current filter settings
            string sql = "SELECT issues.tracker_id AS TrackerID, issues.id, issues.created_on, issues.status_id FROM issues"
                       + " WHERE issues.project_id = " + String.Format(GetParameterFormat(), "PROJECTID") + sqlCommand
                       + " and issues.tracker_id IN(" + trackerIds + ")";

            DataTable dtIssueIds = GetDataTable(sql, parameters.ToArray<IDbDataParameter>(), false);

            // get default status for a ticket
            int newTicketStatusID = 1;
            try
            {

                sql = "SELECT issue_statuses.id FROM issue_statuses WHERE issue_statuses.is_default = '1'";
                DataTable dtDefaultStatus = GetDataTable(sql, null, true);
                DataRow drDefaultStatus = dtDefaultStatus.Rows[0];

                // get the default status for a new ticket
                newTicketStatusID = int.Parse(drDefaultStatus[0].ToString());
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                // might fail if there is no default, assume the first then
            }


            foreach (DataRow dr in dtIssueIds.Rows)
            {
                // fetches the history for the current id
                DataTable currentHistory = CreateIssueHistoryTable((int)dr[1], trackerIds);

                // add it to our history object
                historyTable[(int)dr[1]] = currentHistory;
            }

            DataTable dtIssueStatuses;
            // Get all available statuses
            sql = "SELECT issue_statuses.id, issue_statuses.name, issue_statuses.is_closed, issue_statuses.default_done_ratio FROM issue_statuses";
            dtIssueStatuses = GetDataTable(sql);

            // create the result table
            DataTable theGiantHistory = new DataTable();

            // add date column
            DataColumn dateCol = new DataColumn("Date", typeof(DateTime));
            theGiantHistory.Columns.Add(dateCol);

            // add one column for each status id
            foreach (DataRow dr in dtIssueStatuses.Rows)
            {
                DataColumn dc = new DataColumn(dr["id"].ToString(), typeof(int));
                theGiantHistory.Columns.Add(dc);
            }

            // add meta columns for open and closed issues
            DataColumn openCount = new DataColumn("OpenCount", typeof(int));
            theGiantHistory.Columns.Add(openCount);
            DataColumn solvedCount = new DataColumn("SolvedCount", typeof(int));
            theGiantHistory.Columns.Add(solvedCount);
            DataColumn closedCount = new DataColumn("ClosedCount", typeof(int));
            theGiantHistory.Columns.Add(closedCount);
            DataColumn createdIssues = new DataColumn("CreatedIssues", typeof(int));
            theGiantHistory.Columns.Add(createdIssues);
            DataColumn changedIssues = new DataColumn("ChangedIssues", typeof(int));
            theGiantHistory.Columns.Add(changedIssues);

            // now loop through history
            int startDate = (int)((toDate - fromDate).TotalHours/24);
            for (int days = -startDate; days <= 0; days++)
            {
                DateTime currentDay = toDate.AddDays(days);

                int creationCount = 0;
                int changesCount = 0;

                // this object holds the issue count per issue status for the current day
                Dictionary<int, int> issueCounts = new Dictionary<int, int>();

                // loop through all issues
                foreach (DataRow issueRow in dtIssueIds.Rows)
                {
                    int issueId = int.Parse(issueRow[1].ToString());
                    DateTime creationDate = (DateTime)(issueRow["created_on"]);

                    // will be created in the future -> skip
                    if (creationDate.Date > currentDay.Date)
                    {
                        continue;
                    }

                    // created today - count
                    if (creationDate.Date == currentDay.Date)
                    {
                        creationCount++;
                    }

                    // get current issue's history
                    if (historyTable[issueId].Rows.Count == 0)
                    {
                        // history-less issue (i.e. new and never edited or similar)
                        // create virtual increment and assign current status
                        int currentStatusId = (int)issueRow["status_id"];

                        if (!issueCounts.ContainsKey(currentStatusId))
                        {
                            issueCounts.Add(currentStatusId, 0);
                        }
                        issueCounts[currentStatusId]++;
                        continue;
                    }

                    DataView dvCurrentIssueHistory = new DataView(historyTable[issueId]);

                    int lastStatusId = newTicketStatusID;

                    // sort by end date
                    dvCurrentIssueHistory.Sort = "Enddate ASC";

                    // loop through history entries (aka journal_details)
                    foreach (DataRowView dr in dvCurrentIssueHistory)
                    {
                        DateTime currentStatusStart = (DateTime)dr["Startdate"];
                        DateTime currentStatusEnd = (DateTime)dr["Enddate"];

                        // changed today - count
                        if (currentStatusEnd.Date == currentDay.Date)
                        {
                            changesCount++;
                        }

                        // not in this timeframe - ticket was created "in the future" -> skip
                        if (currentStatusStart.Date > currentDay.Date)
                            break;

                        // fetch last status and remember it
                        if (currentStatusEnd.Date <= currentDay.Date)
                        {
                            lastStatusId = Int32.Parse(dr["Status"].ToString());
                            continue;
                        }
                        break;
                    }

                    // if we reach this point, the next status change will be in the "future" or there is none, thus count this issue
                    if (!issueCounts.ContainsKey(lastStatusId))
                    {
                        issueCounts.Add(lastStatusId, 0);
                    }
                    issueCounts[lastStatusId]++;
                }

                // we now have a Dictionary for the current day, containing all the counts for the ticket statuses
                // create datarow in result table (one row per day)
                DataRow rowForToday = theGiantHistory.NewRow();
                rowForToday["Date"] = currentDay.Date;
                rowForToday["CreatedIssues"] = creationCount;
                rowForToday["ChangedIssues"] = changesCount;
                int openCounter = 0, closedCounter = 0, solvedCounter = 0;

                foreach (int statusId in issueCounts.Keys)
                {
                    // set issue id column of result table to resulting count for this status id
                    rowForToday[statusId.ToString()] = issueCounts[statusId];

                    // find the status id in the statuses table
                    foreach (DataRow dr in dtIssueStatuses.Rows)
                    {
                        if (dr["id"].ToString() == statusId.ToString())
                        {
                            // increment open or closed counter
                            if ((bool)dr["is_closed"])
                                closedCounter += issueCounts[statusId];
                            else
                            {
                                if ((dr["default_done_ratio"] != System.DBNull.Value) && ((int)dr["default_done_ratio"] == 100))
                                {
                                    solvedCounter += issueCounts[statusId];
                                }
                                else
                                    openCounter += issueCounts[statusId];
                            }
                            break;
                        }
                    }
                }

                rowForToday["OpenCount"] = openCounter;
                rowForToday["ClosedCount"] = closedCounter;
                rowForToday["SolvedCount"] = solvedCounter;

                // add the row for this day
                theGiantHistory.Rows.Add(rowForToday);
            }
            theGiantHistory.TableName = "History";
            return theGiantHistory;
        }

        private DataTable CreateIssueHistory(string projectId, string sqlCommand, int startDate, string trackerIds)
        {
            // object to hold the history table per id
            Dictionary<int, DataTable> historyTable = new Dictionary<int, DataTable>();            
            
            DataTable dtIssueIds;
            DataTable dtDefaultStatus;

            // create parameters
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter param = GetParameter();
            param.ParameterName = String.Format(GetParameterFormat(), "PROJECTID");
            param.Value = projectId;
            parameters.Add(param);

            // get all matching issue ids for current filter settings
            string sql = "SELECT issues.tracker_id AS TrackerID, issues.id, issues.created_on, issues.status_id FROM issues"
                       + " WHERE issues.project_id = " + String.Format(GetParameterFormat(), "PROJECTID") + sqlCommand
                       + " and issues.tracker_id IN(" + trackerIds + ")";

            dtIssueIds = GetDataTable(sql, parameters.ToArray<IDbDataParameter>(), false);

            // get default status for a ticket
            int newTicketStatusID = 1;
            try
            {
                sql = "SELECT issue_statuses.id FROM issue_statuses WHERE issue_statuses.is_default = '1'";
                dtDefaultStatus = GetDataTable(sql, null, true);
                DataRow drDefaultStatus = dtDefaultStatus.Rows[0];

                // get the default status for a new ticket
                newTicketStatusID = int.Parse(drDefaultStatus[0].ToString());
            }
            catch (MySql.Data.MySqlClient.MySqlException)
            { 
                // might fail if there is no default, assume the first then
            }

            foreach (DataRow dr in dtIssueIds.Rows)
            {
                // fetches the history for the current id
                DataTable currentHistory = CreateIssueHistoryTable((int)dr[1], trackerIds);

                // add it to our history object
                historyTable[(int)dr[1]] = currentHistory;
            }

            DataTable dtIssueStatuses;
            // Get all available statuses
            sql = "SELECT issue_statuses.id, issue_statuses.name, issue_statuses.is_closed, issue_statuses.default_done_ratio FROM issue_statuses";
            dtIssueStatuses = GetDataTable(sql);

            // create the result table
            DataTable theGiantHistory = new DataTable();

            // add date column
            DataColumn dateCol = new DataColumn("Date", typeof(DateTime));
            theGiantHistory.Columns.Add(dateCol);

            // add one column for each status id
            foreach (DataRow dr in dtIssueStatuses.Rows)
            {
                DataColumn dc = new DataColumn(dr["id"].ToString(), typeof(int));
                theGiantHistory.Columns.Add(dc);
            }

            // add meta columns for open and closed issues
            DataColumn openCount = new DataColumn("OpenCount", typeof(int));
            theGiantHistory.Columns.Add(openCount);
            DataColumn solvedCount = new DataColumn("SolvedCount", typeof(int));
            theGiantHistory.Columns.Add(solvedCount);
            DataColumn closedCount = new DataColumn("ClosedCount", typeof(int));
            theGiantHistory.Columns.Add(closedCount);
            DataColumn createdIssues = new DataColumn("CreatedIssues", typeof(int));
            theGiantHistory.Columns.Add(createdIssues);
            DataColumn changedIssues = new DataColumn("ChangedIssues", typeof(int));
            theGiantHistory.Columns.Add(changedIssues);

            // now loop through history
            for (int days = -startDate; days <= 0; days++)
            {
                DateTime currentDay = DateTime.Now.AddDays(days);

                int creationCount = 0;
                int changesCount = 0;

                // this object holds the issue count per issue status for the current day
                Dictionary<int, int> issueCounts = new Dictionary<int, int>();

                // loop through all issues
                foreach (DataRow issueRow in dtIssueIds.Rows)
                {
                    int issueId = int.Parse(issueRow[1].ToString());
                    DateTime creationDate = (DateTime)(issueRow["created_on"]);

                    // will be created in the future -> skip
                    if (creationDate.Date > currentDay.Date)
                    {
                        continue;
                    }

                    // created today - count
                    if (creationDate.Date == currentDay.Date)
                    {
                        creationCount++;
                    }

                    // get current issue's history
                    if (historyTable[issueId].Rows.Count == 0)
                    {
                        // history-less issue (i.e. new and never edited or similar)
                        // create virtual increment and assign current status
                        int currentStatusId = (int)issueRow["status_id"];

                        if (!issueCounts.ContainsKey(currentStatusId))
                        {
                            issueCounts.Add(currentStatusId, 0);
                        }
                        issueCounts[currentStatusId]++;
                        continue;
                    }

                    DataView dvCurrentIssueHistory = new DataView(historyTable[issueId]);

                    int lastStatusId = newTicketStatusID;

                    // sort by end date
                    dvCurrentIssueHistory.Sort = "Enddate ASC";

                    // loop through history entries (aka journal_details)
                    foreach (DataRowView dr in dvCurrentIssueHistory)
                    {
                        DateTime currentStatusStart = (DateTime)dr["Startdate"];
                        DateTime currentStatusEnd = (DateTime)dr["Enddate"];

                        // changed today - count
                        if (currentStatusEnd.Date == currentDay.Date)
                        {
                            changesCount++;
                        }

                        // not in this timeframe - ticket was created "in the future" -> skip
                        if (currentStatusStart.Date > currentDay.Date)
                            break;

                        // fetch last status and remember it
                        if (currentStatusEnd.Date <= currentDay.Date)
                        {
                            lastStatusId = Int32.Parse(dr["Status"].ToString());
                            continue;
                        }
                        break;
                    }

                    // if we reach this point, the next status change will be in the "future" or there is none, thus count this issue
                    if (!issueCounts.ContainsKey(lastStatusId))
                    {
                        issueCounts.Add(lastStatusId, 0);
                    }
                    issueCounts[lastStatusId]++;
                }

                // we now have a Dictionary for the current day, containing all the counts for the ticket statuses
                // create datarow in result table (one row per day)
                DataRow rowForToday = theGiantHistory.NewRow();
                rowForToday["Date"] = currentDay.Date;
                rowForToday["CreatedIssues"] = creationCount;
                rowForToday["ChangedIssues"] = changesCount;
                int openCounter = 0, closedCounter = 0, solvedCounter = 0;

                foreach (int statusId in issueCounts.Keys)
                {
                    // set issue id column of result table to resulting count for this status id
                    rowForToday[statusId.ToString()] = issueCounts[statusId];

                    // find the status id in the statuses table
                    foreach (DataRow dr in dtIssueStatuses.Rows)
                    {
                        if (dr["id"].ToString() == statusId.ToString())
                        {
                            // increment open or closed counter
                            if ((bool)dr["is_closed"])
                                closedCounter += issueCounts[statusId];
                            else
                            {
                                if ((dr["default_done_ratio"] != System.DBNull.Value) && ((int)dr["default_done_ratio"] == 100))
                                {
                                    solvedCounter += issueCounts[statusId];
                                }
                                else
                                    openCounter += issueCounts[statusId];
                            }
                            break;
                        }
                    }
                }

                rowForToday["OpenCount"] = openCounter;
                rowForToday["ClosedCount"] = closedCounter;
                rowForToday["SolvedCount"] = solvedCounter;

                // add the row for this day
                theGiantHistory.Rows.Add(rowForToday);
            }
            theGiantHistory.TableName = "History";
            return theGiantHistory;
        }

        public DataTable GetDataTable(string sql)
        {
            return GetDataTable(sql, null, false);
        }

        public abstract DataTable GetDataTable(string sql, IDbDataParameter[] parameters, bool raiseException);
        public abstract IDbDataParameter GetParameter();
        public abstract String GetParameterFormat();

        public string GetRedmineHostName()
        {
            DataTable dtHostName = GetDataTable("SELECT settings.value AS HostName FROM settings WHERE settings.name = 'host_name'");
            if (dtHostName.Rows.Count > 0)
            {
                DataRow drHostName = dtHostName.Rows[0];
                return drHostName["HostName"].ToString();
            }
            return "Undefined";
        }

        public DataTable GetRedmineProjects(bool UseAllProjects)
        {
            string sqlProject = "SELECT id, name, parent_id FROM projects";
            if (!UseAllProjects)
            {
                sqlProject += " WHERE parent_id IS null"; 
            }

            DataTable projectTable = GetDataTable(sqlProject); 
            projectTable.Columns.Add(new DataColumn("display_name",typeof(string)));

            foreach (DataRow dr in projectTable.Rows)
            {
                dr["display_name"] = ((dr["parent_id"]==System.DBNull.Value) ? dr["name"] : String.Concat("\x2022 ", dr["name"]));
            }

            return projectTable;
        }

        public DataTable GetRedmineTrackers(string ProjectID)
        {
            //followed query gives all related trackers for choosed project as result
            //the query checks in where wether the project id is in the project_trackers or not if not
            // we have to take the project id from the parent to get all related trackers from parent
            
            string sqlProject = "Select distinct t1.name, t1.id from trackers t1" +
                                " inner join" +
                                " projects_trackers t2 ON t1.id = t2.tracker_id" +
                                " inner join" +
                                " projects t3 on t3.id = t2.project_id" +
                                " Where " +
                                "t3.parent_id is null and t3.id = " + String.Format("{0}", ProjectID) + " or t3.id = "+
                                "If(" + String.Format("{0}", ProjectID) + " in (Select distinct project_id from projects_trackers), " + String.Format("{0}", ProjectID) + "," +
                                    "(Select distinct parent_id from projects where id = " + String.Format("{0}", ProjectID) + "))";

            DataTable trackersTable = GetDataTable(sqlProject);
            trackersTable.Columns.Add(new DataColumn("display_name", typeof(string)));

            foreach (DataRow dr in trackersTable.Rows)
            {
                dr["display_name"] = ((dr["id"] == System.DBNull.Value) ? dr["name"] : String.Concat("\x2022 ", dr["name"]));
            }

            return trackersTable;
        }

        

        public DataView GetVersions(string projectID)
        {
            // SQL Query on Versions
            string sqlProject = "SELECT versions.name, versions.id, versions.project_id FROM versions WHERE versions.project_id = " + String.Format(GetParameterFormat(), "PROJECTID") + "";
            
            // create parameters
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter param = GetParameter();
            parameters.Add(param);
            param.ParameterName = String.Format(GetParameterFormat(), "PROJECTID");
            param.Value = projectID;
            
            DataTable dtVersions = GetDataTable(sqlProject, parameters.ToArray<IDbDataParameter>(), false);
            DataView dvVersions = new DataView(dtVersions);
            dvVersions.Sort = "name ASC";
            return dvVersions;
        }

        public string GetRedmineProjectName(string projectId)
        {
            string sql = "SELECT projects.name FROM projects WHERE id = " + String.Format(GetParameterFormat(), "PROJECTID") + "";
            
            
            // create parameter
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter param = GetParameter();
            parameters.Add(param);
            param.ParameterName = String.Format(GetParameterFormat(), "PROJECTID");
            param.Value = projectId;

            DataTable dtProjectname = GetDataTable(sql, parameters.ToArray<IDbDataParameter>(), false);
            
            return dtProjectname.Rows[0].ItemArray[0].ToString();
        }

        public string GetRedmineVersionName(string id)
        {
            // create parameter
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter param = GetParameter();
            parameters.Add(param);
            param.ParameterName = String.Format(GetParameterFormat(), "ID");
            param.Value = id;

            DataTable dtVersionname = GetDataTable("SELECT versions.name FROM versions WHERE id =" + String.Format(GetParameterFormat(), "ID"));
            return dtVersionname.Rows[0].ItemArray[0].ToString();
        }

        private DataTable CreateIssueHistoryTable(int issueId, string trackerIds)
        {
            // SQL command on the right versions
            string sqlProject = @"SELECT issues.tracker_id AS TrackerID, issues.id AS Issue_ID, issues.created_on AS Startdate, journals.created_on AS Enddate, journal_details.value AS Status 
                                 FROM issues 
                                 INNER JOIN journals ON issues.id = journals.journalized_id 
                                 INNER JOIN journal_details ON journals.id = journal_details.journal_id 
                                 WHERE issues.id = journals.journalized_id AND journal_details.prop_key = 'status_id' AND issues.id = '" + issueId.ToString() + "'"
                                 +" and issues.tracker_id IN(" + trackerIds + ")"; 

            return GetDataTable(sqlProject);
        }

        public string GetStatusNameFromId(int id)
        {
            string sql = String.Format("SELECT issue_statuses.name FROM issue_statuses WHERE id = '{0}'", id);
            DataTable dtId = GetDataTable(sql);

            DataRow dr = dtId.Rows[0];
            return dr["name"].ToString();
        }

        #region IDisposable Member

        ~RedmineDataAccessBase()
        {
            Dispose(false);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
