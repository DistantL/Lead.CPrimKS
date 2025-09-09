// ***********************************************************************
// Assembly         : Lead.CPrim.Interfaces.DB
// Author           : 17181
// Created          : 03-23-2019
//
// Last Modified By : 17181
// Last Modified On : 04-16-2019
// ***********************************************************************
// <copyright file="ISql.cs" company="LeadChina">
//     Copyright ©  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;

namespace Lead.CPrim.Interfaces
{
    /// <summary>
    ///     Interface ISql
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public interface ISql
    {
        /// <summary>
        ///     Gets or sets the name of the current database.
        /// </summary>
        /// <value>The name of the current database.</value>
        /// <remarks>Lead.CPrim</remarks>
        string CurDbName { set; get; }

        /// <summary>
        ///     Gets or sets the name of the current table.
        /// </summary>
        /// <value>The name of the current table.</value>
        /// <remarks>Lead.CPrim</remarks>
        string CurTableName { set; get; }

        /// <summary>
        ///     Gets the database table information list.
        /// </summary>
        /// <value>The database table information list.</value>
        /// <remarks>Lead.CPrim</remarks>
        List<DbTableInfo> DbTableInfoList { get; }

        /// <summary>
        ///     Gets or sets the load language path.
        /// </summary>
        /// <value>The load language path.</value>
        /// <remarks>Lead.CPrim</remarks>
        string LoadLangPath { set; get; }

        /// <summary>
        ///     Gets or sets the load object path.
        /// </summary>
        /// <value>The load object path.</value>
        /// <remarks>Lead.CPrim</remarks>
        string LoadObjPath { set; get; }

        /// <summary>
        ///     Gets or sets the pass word.
        /// </summary>
        /// <value>The pass word.</value>
        /// <remarks>Lead.CPrim</remarks>
        string PassWord { set; get; }

        /// <summary>
        ///     Gets or sets the SQL addr.
        /// </summary>
        /// <value>The SQL addr.</value>
        /// <remarks>Lead.CPrim</remarks>
        string SqlAddr { set; get; }

        /// <summary>
        ///     Gets or sets the SQL port.
        /// </summary>
        /// <value>The SQL port.</value>
        /// <remarks>Lead.CPrim</remarks>
        int SqlPort { set; get; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        /// <remarks>Lead.CPrim</remarks>
        string UserId { set; get; }

        /// <summary>
        ///     Connects the current data base.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ConnectCurDataBase();

        /// <summary>
        ///     Connects the current database table.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ConnectCurDbTable();

        /// <summary>
        ///     Connects the data base.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ConnectDataBase(string dbName);

        /// <summary>
        ///     Connects the database table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ConnectDbTable(string tableName);

        /// <summary>
        ///     Connects the server.
        /// </summary>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ConnectServer();

        /// <summary>
        ///     Connects the table.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ConnectTable(string dbName, string tableName);

        /// <summary>
        ///     Creates the data base.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int CreateDataBase(string dbName);

        /// <summary>
        ///     Creates the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int CreateTable(string tableName, Type type);

        /// <summary>
        ///     Creates the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int CreateTable(string tableName, string param);

        /// <summary>
        ///     Currents the insert row.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int CurInsertRow(DataRow row);

        /// <summary>
        ///     Currents the update row.
        /// </summary>
        /// <param name="colName">Name of the col.</param>
        /// <param name="val">The value.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int CurUpdateRow(string colName, object val, string param);

        /// <summary>
        ///     Deletes all rows.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int DelAllRows(string tbName);

        /// <summary>
        ///     Deletes the single row.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="row">The row.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int DelSingleRow(string tbName, DataRow row);

        /// <summary>
        ///     Deletes the table.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int DelTable(string tableName);

        /// <summary>
        ///     Executes the query SQL.
        /// </summary>
        /// <param name="sqlStr">The SQL string.</param>
        /// <returns>DataTable.</returns>
        /// <remarks>Lead.CPrim</remarks>
        DataTable ExecuteQuerySql(string sqlStr);

        /// <summary>
        ///     Executes the SQL.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ExecuteSql(string sql);

        /// <summary>
        ///     Executes the SQLS.
        /// </summary>
        /// <param name="sqlList">The SQL list.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int ExecuteSqls(List<string> sqlList);

        /// <summary>
        ///     Gets the create table string.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetCreateTableStr(string tableName, Type type);

        /// <summary>
        ///     Gets the create table string.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetCreateTableStr(string tableName, string param);

        /// <summary>
        ///     Gets the current table all data.
        /// </summary>
        /// <returns>DataTable.</returns>
        /// <remarks>Lead.CPrim</remarks>
        DataTable GetCurTableAllData();

        /// <summary>
        ///     Gets the delete all rows string.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetDelAllRowsStr(string tbName);

        /// <summary>
        ///     Gets the delete single row string.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="colName">Name of the col.</param>
        /// <param name="val">The value.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetDelSingleRowStr(string tbName, string colName, object val);

        /// <summary>
        ///     Gets the delete table string.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetDelTableStr(string tableName);

        /// <summary>
        ///     Gets the insert col string.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="colName">Name of the col.</param>
        /// <param name="colType">Type of the col.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetInsertColStr(string tbName, string colName, string colType);

        /// <summary>
        ///     Gets the insert row string.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="row">The row.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetInsertRowStr(string tbName, DataRow row);

        /// <summary>
        ///     Gets the table all data.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <returns>DataTable.</returns>
        /// <remarks>Lead.CPrim</remarks>
        DataTable GetTableAllData(string tbName);

        /// <summary>
        ///     Gets the table data.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="col">The col.</param>
        /// <param name="val">The value.</param>
        /// <returns>DataTable.</returns>
        /// <remarks>Lead.CPrim</remarks>
        DataTable GetTableData(string tbName, string col, string val);

        /// <summary>
        ///     Gets the update row string.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string GetUpdateRowStr(string tbName, Dictionary<string, object> cols, string param);

        /// <summary>
        ///     Inserts the by data table.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="dataTable">The data table.</param>
        /// <returns>System.String.</returns>
        /// <remarks>Lead.CPrim</remarks>
        string InsertByDataTable(string tbName, DataTable dataTable);

        /// <summary>
        ///     Inserts the col.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="colName">Name of the col.</param>
        /// <param name="colType">Type of the col.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int InsertCol(string tbName, string colName, string colType);

        /// <summary>
        ///     Inserts the row.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="row">The row.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int InsertRow(string tbName, DataRow row);

        /// <summary>
        ///     Loads the language.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int LoadLang(string path);

        /// <summary>
        ///     Queries the excute.
        /// </summary>
        /// <param name="sqlCmd">The SQL command.</param>
        /// <returns>System.Object.</returns>
        /// <remarks>Lead.CPrim</remarks>
        object QueryExcute(string sqlCmd);

        /// <summary>
        ///     Updates the row.
        /// </summary>
        /// <param name="tbName">Name of the tb.</param>
        /// <param name="colName">Name of the col.</param>
        /// <param name="val">The value.</param>
        /// <param name="param">The parameter.</param>
        /// <returns>System.Int32.</returns>
        /// <remarks>Lead.CPrim</remarks>
        int UpdateRow(string tbName, string colName, object val, string param);

        /// <summary>
        ///     Updates the tables.
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        /// <remarks>Lead.CPrim</remarks>
        List<string> UpdateTables();
    }

    /// <summary>
    ///     Class DbTableInfo.
    /// </summary>
    /// <remarks>Lead.CPrim</remarks>
    public class DbTableInfo
    {
        /// <summary>
        ///     Gets or sets the name of the database.
        /// </summary>
        /// <value>The name of the database.</value>
        /// <remarks>Lead.CPrim</remarks>
        public string DbName { set; get; }

        /// <summary>
        ///     Gets or sets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        /// <remarks>Lead.CPrim</remarks>
        public string TableName { set; get; }
    }
}